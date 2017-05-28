using AutoService.Models;
using AutoService.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService
{
    public partial class MainMenu : Form
    {
        //Car Tab Pre-defined choices
        private List<string> FuelType;
        private List<string> BodyType;
        private List<Double> EngineCapacity;
        private List<int> Years;

        //Piese Components
        private List<string> _pieseInternalCodes = new List<string>();
        private List<string> _pieseModels = new List<string>();
        private List<string> _pieseMakes = new List<string>();

        //SearchTab Components
        private List<string> _searchMakes = new List<string>();
        private List<string> _searchModels = new List<string>();
        private List<int> _searchYears = new List<int>();
        private List<double> _searchEngine = new List<double>();
        private List<string> _searchParts = new List<string>();
        private List<Car> resultCars = new List<Car>();
        public List<Part> resultParts = new List<Part>();

        private List<User> _allUsers = new List<User>();

        //Objects Sent to other frames
        private Part _selectedPart = new Part();
        private Car _selectedCar = new Car();

        public Context db = new Context();

        /*
        private Make _selectedMake;
        private Model _selectedModel;
        private Models.Version _selectedVersion;
        private Engine _selectedEngine;
        private Part _selectedPart;
        private int?  _selectedYears;
        */
        public MainMenu()
        {
            InitializeComponent();
        }



        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            var tbr = new List<TabPage>();
            // Iterate over all tabs
            for (var i = 0; i < tabControl1.TabCount; i++)
            {
                var tabPage = tabControl1.TabPages[i];
                switch (i)
                {
                    case 0:
                        // Cautare

                        break;

                    case 1:
                        if (UserService.LoggedInUser.Role == Enums.RolesEnum.Guest)
                        {
                            tbr.Add(tabPage);
                        }
                        break;

                    case 2:
                        if (UserService.LoggedInUser.Role != Enums.RolesEnum.Admin &&
                             UserService.LoggedInUser.Role != Enums.RolesEnum.SuperAdmin)
                        {
                            tbr.Add(tabPage);
                        }
                        break;

                    case 3:
                        if (UserService.LoggedInUser.Role == Enums.RolesEnum.Guest)
                        {
                            tbr.Add(tabPage);
                        }
                        break;

                    case 4:
                        if (UserService.LoggedInUser.Role != Enums.RolesEnum.SuperAdmin)
                        {
                            tbr.Add(tabPage);
                        }
                        break;
                }

            }

            foreach (var todel in tbr)
            {
                tabControl1.TabPages.Remove(todel);
            }


            // Show the user
            label35.Text = UserService.LoggedInUser.Username;
            //Custom body types to combobox
            BodyType = new List<string>();
            BodyType.Add("Berlina");
            BodyType.Add("Break");
            BodyType.Add("SUV");
            BodyType.Add("Hatchback");
            BodyType.Add("Cabrio");
            carCbBody.DataSource = BodyType;

            //Fuel types to ComboBox
            FuelType = new List<string>();
            FuelType.Add("Diesel");
            FuelType.Add("Benzina-GPL");
            carCbFuel.DataSource = FuelType;

            //Engine Capacity ComboBox;

            EngineCapacity = db.Cars
                               .Select(c => c.Capacity)
                               .ToList();
            /*     EngineCapacity = new List<Double>();
                 for (double i = 0.8; i < 4.0; i += 0.1)
                 {
                     EngineCapacity.Add(Math.Round(i, 3));
                 }
             */
            carCbCapacity.DataSource = EngineCapacity;

            //Years ComboBox
            Years = new List<int>();
            for (int i = 1990; i <= 2017; i++)
            {
                Years.Add(i);
            }
            carCbYear.DataSource = Years;
            _searchMakes = db.Cars
                   .Select(c => c.Make)
                   .Distinct()
                   .OrderBy(m => m)
                   .ToList();

            //Loading Search Tab

            searchCbMake.SelectedIndexChanged -= searchCbMake_SelectedIndexChanged;
            searchCbMake.DataSource = _searchMakes;
            searchCbMake.SelectedIndex = -1;
            searchCbMake.SelectedIndexChanged += searchCbMake_SelectedIndexChanged;

            ReCheck(tbSearch.Text);
        }


        private void searchCbMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchCbMake.SelectedIndex > -1 && !string.IsNullOrEmpty(searchCbMake.SelectedValue as string))
            {
                // populate models
                var selectedMake = searchCbMake.SelectedValue as string;
                _searchModels = db
                    .Cars
                    .Where(c => c.Make.Equals(selectedMake))
                    .Select(c => c.Model)
                    .Distinct()
                    .OrderBy(m => m)
                    .ToList();

                searchCbModel.SelectedIndexChanged -= searchCbModel_SelectedIndexChanged;
                searchCbModel.DataSource = _searchModels;
                searchCbModel.SelectedIndex = -1;
                searchCbModel.SelectedIndexChanged += searchCbModel_SelectedIndexChanged;

                _searchYears = db
                    .Cars
                    .Where(c => c.Make.Equals(selectedMake))
                    .Select(c => c.Year)
                    .Distinct()
                    .OrderBy(y => y)
                    .ToList();
                searchCbYear.DataSource = _searchYears;
                searchCbYear.SelectedIndex = -1;
                ReCheck(tbSearch.Text);
            }
        }
        private void searchCbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchCbModel.SelectedIndex > -1 && !string.IsNullOrEmpty(searchCbModel.SelectedValue as string))
            {

                var selectedModel = searchCbModel.SelectedValue as string;
                var selectedMake = searchCbMake.SelectedValue as string;

                _searchYears = db
                    .Cars
                    .Where(c => c.Make.Equals(selectedMake) && c.Model.Equals(selectedModel))
                    .Select(c => c.Year)
                    .Distinct()
                    .OrderBy(y => y)
                    .ToList();

                searchCbYear.DataSource = _searchYears;
                searchCbYear.SelectedIndex = -1;
            }
        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReCheck(tbSearch.Text);
        }
        private void UpdateForm()
        {

        }
        // Add Car Button --Logg here!
        private void carBtnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(carTbMake.Text))
            {
                MessageBox.Show("Introduceti Marca masinii!");
            } else if (string.IsNullOrEmpty(carTbOem.Text)) {
                MessageBox.Show("Introduceti codul masinii!");
            } else if (string.IsNullOrEmpty(carTbPret.Text))
            {
                MessageBox.Show("Introduceti pretul!!!");
            } else if (string.IsNullOrEmpty(carTbPower.Text))
            {
                MessageBox.Show("Introduceti puterea masinii!");
            } else if (string.IsNullOrEmpty(carTbModel.Text))
            {
                MessageBox.Show("Introduceti modelul masinii!");
            }
            else {
                //Matching Parameters
                var _carToBe = new Car
                {
                    Body = carCbBody.Text,
                    Capacity = Math.Round(Convert.ToDouble(carCbCapacity.Text), 3),
                    Fuel = carCbFuel.Text,
                    Make = carTbMake.Text,
                    Model = carTbModel.Text,
                    Internal_Code = carTbOem.Text,
                    Year = Convert.ToInt16(carCbYear.Text),
                    Power = Math.Round(Convert.ToDouble(carTbPower.Text), 1),
                    Price = Math.Round(Convert.ToDouble(carTbPret.Text), 3),
                    Content = ImageServices.imageToByteArray(pictureBox1.Image)

                };

                //Add car to DataBase
                db.Cars.Add(_carToBe);
                db.SaveChanges();
                FillUpMyCarTable();
                ClearGUI();

                LoggingService.Log(Enums.ActionsEnum.Adaugare_Masina, _carToBe.Price, "S-a adaugat masina " + _carToBe.Make + " " + _carToBe.Model + " " + _carToBe.Year);

                MessageBox.Show("Masina adaugata cu succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearGUI()
        {
            //Clear GUI
            carTbPret.Text = "";
            carTbMake.Text = "";
            carTbModel.Text = "";
            carTbOem.Text = "";
            carTbPower.Text = "";
            carCbBody.SelectedIndex = 0;
            carCbCapacity.SelectedIndex = 0;
            carCbFuel.SelectedIndex = 0;
            carCbYear.SelectedIndex = 0;
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab.Text.ToLower() == "adaugare piese")
            {
                // Piese screen
                pictureBox2.Image = Image.FromFile("../Pics/logo2.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;

                // Get all makes
                _pieseMakes = db
                    .Cars
                    .Select(c => c.Make)
                    .Distinct()
                    .OrderBy(m => m)
                    .ToList();
                partCbMake.SelectedIndexChanged -= partCbMake_SelectedIndexChanged;
                partCbMake.DataSource = _pieseMakes;
                partCbMake.SelectedIndex = -1;
                partCbMake.SelectedIndexChanged += partCbMake_SelectedIndexChanged;
            }
            else if (tabControl1.SelectedTab.Text.ToLower() == "rapoarte")
            {
                // Rapoarte
                dateTimePicker2.ValueChanged -= dateTimePicker2_ValueChanged;
                dateTimePicker2.Value = DateTime.Now;
                dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-1);
                // dateTimePicker1.Value = DateTime.Now.AddMonths(-1);

                dateTimePicker2.MaxDate = DateTime.Now.AddMinutes(300);
                // dateTimePicker1.MaxDate = DateTime.Now;
                dateTimePicker1.MaxDate = dateTimePicker2.Value;
                dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;

                dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                GetReports();

                var noOfCarsinSystem = db.Cars
                                        .Select(c => c.Make)
                                        .Count();
                lbNrTotalMasini.Text = noOfCarsinSystem.ToString();

                var noOfPartsInSystem = db.Parts
                                         .Where(p => p.Quantity > 0 || p.InStock == true)
                                         .Select(p => p.Quantity)
                                         .Count();
                lbNrTotalPiese.Text = noOfPartsInSystem.ToString();

                var valueOfCarsInSystem = db.Cars
                                           .Select(c => c.Price)
                                           .Sum();
                lbValoareMasini.Text = valueOfCarsInSystem.ToString();

                var valueOfPartsInSystem = db.Parts
                                            .Where(p => p.Quantity > 0)
                                            .Select(p => new
                                            {
                                                value = p.Price * p.Quantity
                                            })
                                            .ToList();
                //lblValoarePiese.Text = valueOfPartsInSystem.Sum(x=>Convert.ToInt64(x)).ToString();
                                            
            }
            else if (tabControl1.SelectedTab.Text.ToLower() == "cautare")
            {
                //Search Screen
                _searchMakes = db.Cars
                    .Select(c => c.Make)
                    .Distinct()
                    .OrderBy(m => m)
                    .ToList();
                searchCbMake.SelectedIndexChanged -= searchCbMake_SelectedIndexChanged;
                searchCbMake.DataSource = _searchMakes;
                searchCbMake.SelectedIndex = -1;
                searchCbMake.SelectedIndexChanged += searchCbMake_SelectedIndexChanged;
                ReCheck(tbSearch.Text);
            }
            else if (tabControl1.SelectedTab.Text.ToLower() == "utilizatori")
            {
                // Users grid
                _allUsers = db.Users.OrderBy(u => u.Username).ToList();
                dataListView2.DataSource = _allUsers;

                dataListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                dataListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
           
            else if (tabControl1.SelectedTab.Text.ToLower() == "adaugare masini")
            {
                pictureBox1.Image = Image.FromFile("../Pics/logo2.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                FillUpMyCarTable();

            }

        }

        private void partCbMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            // has selected a make from parts screen
            if (partCbMake.SelectedIndex > -1 && !string.IsNullOrEmpty(partCbMake.SelectedValue as string))
            {
                // populate models
                var selectedMake = partCbMake.SelectedValue as string;
                _pieseModels = db
                    .Cars
                    .Where(c => c.Make.Equals(selectedMake))
                    .Select(c => c.Model)
                    .Distinct()
                    .OrderBy(m => m)
                    .ToList();

                partCbModel.SelectedIndexChanged -= partCbModel_SelectedIndexChanged;
                partCbModel.DataSource = _pieseModels;
                partCbModel.SelectedIndex = -1;
                partCbModel.SelectedIndexChanged += partCbModel_SelectedIndexChanged;

                _pieseInternalCodes = db
                    .Cars
                    .Where(c => c.Make.Equals(selectedMake))
                    .Select(c => c.Internal_Code)
                    .Distinct()
                    .OrderBy(y => y)
                    .ToList();
                partCbInternalCode.DataSource = _pieseInternalCodes;
                partCbInternalCode.SelectedIndex = -1;
            }
        }

        private void partCbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // has selected a make from parts screen
            if (partCbModel.SelectedIndex > -1 && !string.IsNullOrEmpty(partCbModel.SelectedValue as string))
            {

                var selectedModel = partCbModel.SelectedValue as string;
                var selectedMake = partCbMake.SelectedValue as string;

                _pieseInternalCodes = db
                    .Cars
                    .Where(c => c.Make.Equals(selectedMake) && c.Model.Equals(selectedModel))
                    .Select(c => c.Internal_Code)
                    .Distinct()
                    .OrderBy(y => y)
                    .ToList();

                partCbInternalCode.DataSource = _pieseInternalCodes;
                lbParts.DataSource = resultParts;
                partCbInternalCode.SelectedIndex = -1;
                ReCheck(tbSearch.Text);
            }
        }
        //Add Part Button
        private void button1_Click(object sender, EventArgs e)
        {
            AddOrSellPart(true);
           
        }

        private void AddOrSellPart(bool inStock)
        {
            if (partCbMake.SelectedValue != null && partCbInternalCode.SelectedValue != null && !string.IsNullOrWhiteSpace(partTbName.Text) && !string.IsNullOrWhiteSpace(partTbPrice.Text))
            {
                //      get the car(s) with respect to the filters (3)
                var carsQuery = db.Cars.AsQueryable();
                var selectedMake = partCbMake.SelectedValue.ToString();
                carsQuery = carsQuery.Where(c => c.Make.Equals(selectedMake));

                if (partCbModel.SelectedValue != null)
                {
                    var selectedModel = partCbModel.SelectedValue.ToString();
                    carsQuery = carsQuery.Where(c => c.Model.Equals(selectedModel));
                }
                if (partCbInternalCode.SelectedValue != null)
                {
                    var selectedCode = partCbInternalCode.SelectedValue.ToString();
                    carsQuery = carsQuery.Where(c => c.Internal_Code.Equals(selectedCode));
                }
                var allReturnedCars = carsQuery.Distinct()
                    .OrderBy(c => c.Make)
                    .ThenBy(c => c.Model)
                    .ThenBy(c => c.Year)
                    .ThenBy(c => c.Internal_Code)
                    .ToList();

                var partToBe = new Part
                {
                    Name = partTbName.Text,
                    Quantity = double.Parse(partTbQty.Text),
                    BarCode = "gen",
                    Details = partTbDetails.Text,
                    Price = double.Parse(partTbPrice.Text),
                    Oem_Code = partTbOem.Text,
                    InStock = inStock,
                    Color = partCbColor.Text

                };
                //Check if the part is already in stock. If it is, add qty
                var isThePartInStock = db.Parts
                    .Where(p => p.Name.Equals(partToBe.Name))
                    .Where(p => p.Price == partToBe.Price)
                    .Where(p => p.Oem_Code.Equals(partToBe.Oem_Code))
                    .FirstOrDefault();
                if (isThePartInStock != null)
                {
                    partToBe.Quantity += db.Parts
                        .Where(p => p.Name.Equals(partToBe.Name))
                        .Where(p => p.Price == partToBe.Price)
                        .Where(p => p.Oem_Code.Equals(partToBe.Oem_Code))
                        .Select(p => p.Quantity)
                        .FirstOrDefault();
                    isThePartInStock.Quantity = partToBe.Quantity;
                }
                else
                {
                    partToBe.Cars = allReturnedCars;
                    db.Parts.Add(partToBe);
                }
                db.SaveChanges();

                if (inStock)
                {
                    LoggingService.Log(Enums.ActionsEnum.Adaugare_Piesa, partToBe.Price, "S-a adaugat piesa " + partToBe.Name + " la masinile: " +
                                      string.Join(",", allReturnedCars.Select(c => c.Make + " " + c.Model + " " + c.Year).ToList())
                                      );
                    if (isThePartInStock != null)
                    {
                        MessageBox.Show("Piesa exista deja, stoc ul a fost marit.");
                    }
                    else
                    {
                        MessageBox.Show("Piesa adaugata cu succes la " + allReturnedCars.Count + " masini.");
                    }
                }

                else
                {
                    LoggingService.Log(Enums.ActionsEnum.Vanzare_Piesa, partToBe.Price, "S-a vandut piesa " + partToBe.Name);
                    MessageBox.Show("Piesa vanduta cu succes !" + allReturnedCars.Count + " masini.");
                }
                PartGUIReset();
            }
            else
            {
                MessageBox.Show("Toate campurile cu * trebuie completate!");
            }
        }

        private void PartGUIReset()
        {
            partCbMake.SelectedIndex = -1;
            partCbModel.SelectedIndex = -1;
            partCbInternalCode.SelectedIndex = -1;
            partTbDetails.Text = "";
            partTbName.Text = "";
            partTbOem.Text = "";
            partTbPrice.Text = "";
            partTbQty.Text = "";
            partCbColor.Text = "";
        }

        private void label26_Click(object sender, EventArgs e)
        {
            partCbMake.SelectedIndexChanged -= partCbMake_SelectedIndexChanged;
            partCbMake.SelectedIndex = -1;
            partCbMake.SelectedIndexChanged += partCbMake_SelectedIndexChanged;
        }

        private void label27_Click(object sender, EventArgs e)
        {
            partCbModel.SelectedIndexChanged -= partCbModel_SelectedIndexChanged;
            partCbModel.SelectedIndex = -1;
            partCbModel.SelectedIndexChanged += partCbModel_SelectedIndexChanged;
        }

        private void label28_Click(object sender, EventArgs e)
        {
            partCbInternalCode.SelectedIndex = -1;
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-1);
            }
            dateTimePicker1.MaxDate = dateTimePicker2.Value;
            GetReports();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetReports();
        }

        private void GetReports()
        {
            var logEntries = db
                .LogEntries
                .Where(le => le.Date > dateTimePicker1.Value && le.Date <= dateTimePicker2.Value)
                .Select(l => new
                {
                    Actiune = l.Action,
                    Data = l.Date,
                    Operatiune = l.Description,
                    Cost = l.Price
                })
                .OrderByDescending(le => le.Data)
                .ToList();
            //dataListView1.Clear();
            dataListView1.DataSource = logEntries;
        }

        private void searchCbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMake = searchCbMake.SelectedValue as string;
            var selectedModel = searchCbModel.SelectedValue as string;

            _searchEngine = db.Cars
                            .Where(c => c.Make.Equals(selectedMake) && c.Model.Equals(selectedModel))
                            .Select(ca => ca.Capacity)
                            .Distinct()
                            .OrderBy(ca => ca)
                            .ToList();
            searchCbEngine.DataSource = _searchEngine;
            searchCbEngine.SelectedIndex = -1;
            ReCheck(tbSearch.Text);
        }
        //SearchBar with respect 4 filters!!!
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            ReCheck(tbSearch.Text);
        }
        public void ReCheck(string searchString)
        {
            string make = null, model = null;
            double engine = double.MinValue;
            bool engineSelected = false;
            int year = int.MinValue;
            bool yearSelected = false;

            if (searchCbMake.SelectedValue != null)
            {
                make = searchCbMake.SelectedValue.ToString();
            }
            if (searchCbModel.SelectedValue != null)
            {
                model = searchCbModel.SelectedValue.ToString();
            }
            if (searchCbYear.SelectedValue != null)
            {
                yearSelected = int.TryParse(searchCbYear.SelectedValue.ToString(), out year);
            }
            if (searchCbEngine.SelectedValue != null)
            {
                engineSelected = double.TryParse(searchCbEngine.SelectedValue.ToString(), out engine);
            }

            var partQuery = db.Cars.Include("Parts")
                .Where(x => make == null || (make != null && x.Make.Equals(make)))
                .Where(x => model == null || (model != null && x.Model.Equals(model)))
                .Where(x => !yearSelected || (yearSelected && x.Year.Equals(year)))
                .Where(x => !engineSelected || (engineSelected && x.Capacity.Equals(engine)))
                .SelectMany(x => x.Parts).Where(x => x.Name.StartsWith(searchString) || x.Oem_Code.StartsWith(searchString)).ToList();

            lbParts.DataSource = partQuery.Where(x => x.InStock == true && x.Quantity > 0).Select(x => x.Name).Distinct().ToList();

            PopulateCarListByParts();

        }

        private void searchCbEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReCheck(tbSearch.Text);
        }
        //Mouse Click on Part List
        private void lbParts_MouseClick(object sender, MouseEventArgs e)
        {
            PopulateCarListByParts();
        }

        private void PopulateCarListByParts()
        {
            if (lbParts.SelectedValue != null)
            {
                var _listPart = lbParts.SelectedValue.ToString();
                resultCars = db.Parts.Include("Cars").Where(x => x.Name.Equals(_listPart) && x.Quantity>0).SelectMany(x => x.Cars.ToList()).ToList();
                lbResult.DataSource = resultCars;
            }
            else
            {
                lbResult.DataSource = null;
            }

        }


        //To Implement --------------------------&&&&&&&&&&&&&&
        private void lbResult_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbResult.SelectedValue != null)
            {
                _selectedCar = (Car)lbResult.SelectedValue;
                var sp = lbParts.SelectedValue.ToString();
                var _selectedPart = _selectedCar.Parts.Where(x => x.Name.Equals(sp)).FirstOrDefault();
                // _selectedPart = (Part)lbParts.SelectedItem;
                new PartInfoForm(_selectedCar, _selectedPart, db).Show();

                try
                {

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    MessageBox.Show("A crapat sa moara mama!");
                    Dispose();
                }
            }
        }
        //SELL PART BUTTON HERE !!
        private void button2_Click(object sender, EventArgs e)
        {
            AddOrSellPart(false);
         
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var newUser = new User
            {
                Role = Enums.RolesEnum.Guest
            };
            db.Users.Add(newUser);
            _allUsers.Add(newUser);
            dataListView2.DataSource = _allUsers;
        }

        private void dataListView2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                db.SaveChanges();
                dataListView2.DataSource = _allUsers;
                MessageBox.Show("Salvat.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Utilizatorul este invalid.");
            }
        }

        private void dataListView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                var selectedRow = dataListView2.SelectedItem;
                if (selectedRow != null && selectedRow.RowObject != null)
                {
                    var user = selectedRow.RowObject as User;
                    if (user != null)
                    {
                        if (user.Role == Enums.RolesEnum.SuperAdmin)
                        {
                            var areThereAnySaWithoutMe = db.Users
                                .Where(u => u.Id != user.Id && u.Role == Enums.RolesEnum.SuperAdmin)
                                .Any();
                            if (!areThereAnySaWithoutMe)
                            {
                                MessageBox.Show("Trebuie sa lasati minim un SuperAdmin in sistem.");
                                return;
                            }
                        }
                        _allUsers.Remove(user);
                        db.Users.Remove(user);
                        dataListView2.DataSource = _allUsers;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var cart = new CartForm(this);
            cart.ShowDialog(this);
        }
        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Image";
            dialog.Filter = " jpg files (*.jpg)|*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dialog.FileName);
                // pictureBox1.ImageLocation =dialog.FileName; 
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            FillUpMyCarTable();
        }

       


        private void FillUpMyCarTable()
        {
            var allMyCars = db.Cars.Include("Parts")
                            .Select(c => new
                            {
                                Marca = c.Make,
                                Model = c.Model,
                                Capacitate = c.Capacity,
                                Putere = c.Power,
                                Pret = c.Price,
                                Cod = c.Internal_Code,
                                An = c.Year,
                                Parti = c.Parts.Select(p => new {
                                    PretPiese = p.Price * p.Quantity,
                                })
                            })
                            .ToList();
            /*                      
           */

            dataListView3.DataSource = allMyCars;


            //resize shit
            dataListView3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            dataListView3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

      
        private void partBtnImage_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Image";
            dialog.Filter = " jpg files (*.jpg)|*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dialog.FileName);
                // pictureBox1.ImageLocation =dialog.FileName; 
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

     
    }
}


