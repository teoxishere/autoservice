using AutoService.Models;
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
            for(double i = 0.8; i< 4.0; i += 0.1)
            {
                EngineCapacity.Add(Math.Round(i,3));
            }
            carCbCapacity.DataSource = EngineCapacity;

            //Years ComboBox
            Years = new List<int>();
            for(int i = 1990; i < 2017; i++)
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
        }
        private void UpdateForm()
        {
           
        }

        private void carBtnAdd_Click(object sender, EventArgs e)
        {
            //Matching Parameters
            Car _carToBe = new Models.Car();
            _carToBe.Body = carCbBody.Text;
            _carToBe.Capacity = Math.Round(Convert.ToDouble(carCbCapacity.Text),3);
            _carToBe.Fuel = carCbFuel.Text;
            _carToBe.Make = carTbMake.Text;
            _carToBe.Model = carTbModel.Text;
            _carToBe.Internal_Code = carTbOem.Text;
            _carToBe.Year = Convert.ToInt16(carCbYear.Text);
            _carToBe.Power =Math.Round(Convert.ToDouble(carTbPower.Text),1);
            _carToBe.Price = Math.Round(Convert.ToDouble(carTbPret.Text),3);

            //Add car to DataBase
            db.Cars.Add(_carToBe);
            db.SaveChanges();

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

      
    }
    
}
