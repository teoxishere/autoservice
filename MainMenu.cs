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
        /*private List<Make> _makes;
        private List<Model> _models;
        private List<Models.Version> _versions;
        private List<Engine> _engines;
        private List<Part> _parts;
        private List<int> _years;*/
        private List<string> FuelType;
        private List<string> BodyType;
        private List<Double> EngineCapacity;
        private List<int> Years;

        private List<int> _pieseYears = new List<int>();
        private List<string> _pieseModels = new List<string>();
        private List<string> _pieseMakes = new List<string>();

        private Context db = new Context();

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
            FuelType.Add("Benzina");
            FuelType.Add("GPL");
            carCbFuel.DataSource = FuelType;

            //Engine Capacity ComboBox;
            EngineCapacity = new List<Double>();
            for (double i = 0.8; i < 4.0; i += 0.1)
            {
                EngineCapacity.Add(Math.Round(i, 3));
            }
            carCbCapacity.DataSource = EngineCapacity;

            //Years ComboBox
            Years = new List<int>();
            for (int i = 1990; i <= 2017; i++)
            {
                Years.Add(i);
            }
            carCbYear.DataSource = Years;
        }

        private void cbMake_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        private void cbModel_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbVersion_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateForm();
            //ClearGUI();
        }
        private void UpdateForm()
        {

        }

        private void carBtnAdd_Click(object sender, EventArgs e)
        {
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
                Price = Math.Round(Convert.ToDouble(carTbPret.Text), 3)
            };

            //Add car to DataBase
            db.Cars.Add(_carToBe);
            db.SaveChanges();

            ClearGUI();

            LoggingService.Log(Enums.ActionsEnum.AddCar, "S-a adaugat masina " + _carToBe.Make + " " + _carToBe.Model + " " + _carToBe.Year);

            MessageBox.Show("Masina adaugata cu succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (tabControl1.SelectedIndex == 1)
            {
                // Piese screen

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
            } else if (tabControl1.SelectedIndex == 2)
            {
                // Rapoarte
                dateTimePicker2.ValueChanged -= dateTimePicker2_ValueChanged;
                dateTimePicker2.Value = DateTime.Now;
                dateTimePicker1.Value = DateTime.Now.AddMonths(-1);

                dateTimePicker2.MaxDate = DateTime.Now;
                dateTimePicker1.MaxDate = DateTime.Now;
                dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;

                dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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

                _pieseYears = db
                    .Cars
                    .Where(c => c.Make.Equals(selectedMake))
                    .Select(c => c.Year)
                    .Distinct()
                    .OrderBy(y => y)
                    .ToList();
                partCbYear.DataSource = _pieseYears;
                partCbYear.SelectedIndex = -1;
            }
        }

        private void partCbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // has selected a make from parts screen
            if (partCbModel.SelectedIndex > -1 && !string.IsNullOrEmpty(partCbModel.SelectedValue as string))
            {

                var selectedModel = partCbModel.SelectedValue as string;
                var selectedMake = partCbMake.SelectedValue as string;

                _pieseYears = db
                    .Cars
                    .Where(c => c.Make.Equals(selectedMake) && c.Model.Equals(selectedModel))
                    .Select(c => c.Year)
                    .Distinct()
                    .OrderBy(y => y)
                    .ToList();

                partCbYear.DataSource = _pieseYears;
                partCbYear.SelectedIndex = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get the car(s) with respect to the filters (3)
            var carsQuery = db.Cars.AsQueryable();
            if (partCbMake.SelectedValue != null)
            {
                var selectedMake = partCbMake.SelectedValue.ToString();
                carsQuery = carsQuery.Where(c => c.Make.Equals(selectedMake));
            }
            if (partCbModel.SelectedValue != null)
            {
                var selectedModel = partCbModel.SelectedValue.ToString();
                carsQuery = carsQuery.Where(c => c.Model.Equals(selectedModel));
            }
            if (partCbYear.SelectedValue != null)
            {
                var yearAsInt = int.Parse(partCbYear.SelectedValue.ToString());
                carsQuery = carsQuery.Where(c => c.Year == yearAsInt);
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
                Oem_Code = partTbOem.Text
            };
            partToBe.Cars = allReturnedCars;
            db.Parts.Add(partToBe);
            db.SaveChanges();

            LoggingService.Log(Enums.ActionsEnum.AddPart, "S-a adaugat piesa " + partToBe.Name + " la masinile: " + 
                string.Join(",", allReturnedCars.Select(c => c.Make + " " + c.Model + " " + c.Year).ToList())
                );
            MessageBox.Show("Piesa adaugata cu succes la " + allReturnedCars.Count + " masini.");
            PartGUIReset();
        }

        private void PartGUIReset()
        {
            // TODO
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
            partCbYear.SelectedIndex = -1;
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
                .Where(le => le.Date >= dateTimePicker1.Value && le.Date <= dateTimePicker2.Value)
                .OrderByDescending(le => le.Date)
                .ToList();
            dataListView1.Clear();
            dataListView1.DataSource = logEntries;
        }
    }

}
