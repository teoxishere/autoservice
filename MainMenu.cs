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
            //Loading Makes to CB
            /*
            _makes = db
              .Makes
              .OrderBy(m => m.Name)
              .ToList();
           _makes.Insert(0, new Make
            {
                Name = "-",
                Id = -1
            });
            cbMake.DataSource = _makes;
            cbMake.Text = "-";
            //Loading Models to CB
            _models = db.Models
                .OrderBy(m => m.Name)
                .ToList();
            _models.Insert(0, new Model
            {
                Name = "-",
                Id = -1
            });
            cbModel.DataSource = _models;
            cbModel.Text = "-";

            //Loading Versions to CB
            _versions = db.Versions
                .OrderBy(v => v.Name)
                .ToList();
            cbVersion.DataSource = _versions;
            cbVersion.Text = "-";

            //Loading Years to CB
            _years = db.Versions
                    .Select(v => v.Year)
                    .ToList();
            cbYear.DataSource = _years;
            cbYear.Text = "-";

            //Loading Engines to CB
            _engines = db.Engines
                    .OrderBy(en => en.Name)
                    .ToList();                    
            cbEngine.DataSource = _engines;
           cbEngine.Text = "-";

            _parts = db.Parts
                .OrderBy(p => p.Name)
                .ToList();
            lbParts.DataSource = _parts;
            */
        }

        private void cbMake_SelectedValueChanged(object sender, EventArgs e)
        {
            /*
            if (cbMake.SelectedIndex == 0)
            {
                _selectedMake = null;
                _models = null;
               
                cbVersion.DataSource = _versions;
                cbModel.DataSource = _models;
                
            }
            else
            {
                _selectedMake = cbMake.SelectedValue as Make;
                _models = db.Models.Where(m => m.MakeId == _selectedMake.Id)
                    .OrderBy(m => m.Name)
                    .ToList();
                _models.Insert(0, new Model
                {
                    Name = "-"
                });
                cbModel.DataSource = _models;
            } */

        }
        private void cbModel_SelectedValueChanged(object sender, EventArgs e)
        {
            /*
            if (cbModel.SelectedIndex == 0)
            {
                _versions = null;
                _models = null;
                cbModel.DataSource = _models;
                cbVersion.DataSource = _versions;
            
            }

            else
            {
                _selectedModel = cbModel.SelectedValue as Model;
                _versions = db.Versions
                    .Where(v => v.ModelId == _selectedModel.Id)
                    .OrderBy(v => v.Year)
                    .ToList();
              /*  _versions.Insert(0, new Models.Version
                {
                    Name = "-"
                });

                cbVersion.DataSource = _versions;
                cbVersion.Text = "-";
            } */

        }

        private void cbVersion_SelectedValueChanged(object sender, EventArgs e)
        {
            /*
            if (cbVersion.SelectedIndex == 0)
            {
                _versions = null;
                _selectedVersion = null;
           
                cbVersion.DataSource = _versions;
               

            }
            else
            {
                _selectedModel = cbModel.SelectedValue as Model;
                //_selectedVersion = cbVersion.SelectedValue as Models.Version;
                _years = db.Versions
                    .Where(ModelVersion=>ModelVersion.Model.Id==_selectedModel.Id)
                    .Select(v=>v.Year)
                    .ToList();
                cbYear.DataSource = _years;
            }
            */
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateForm();
        }
        private void UpdateForm()
        {
            /* cbEngine.SelectedIndex = 0;
             cbMake.SelectedIndex = 0;
             cbModel.SelectedIndex = 0;
             cbVersion.SelectedIndex = 0;
             cbYear.SelectedIndex = 0;
             
            _makes = db
             .Makes
             .OrderBy(m => m.Name)
             .ToList();
            /*_makes.Insert(0, new Make
            {
                Name = "-",
                Id = -1
            });
            cbMake.DataSource = _makes;
            cbMake.Text = "-";

            //Loading Models to CB
            _models = db.Models
                .OrderBy(m => m.Name)
                .ToList();
           /* _models.Insert(0, new Model
            {
                Name = "-",
                Id = -1
            });
            cbModel.DataSource = _models;
            cbModel.Text = "-";

            //Loading Versions to CB
            _versions = db.Versions
                .OrderBy(v => v.Name)
                .ToList();
            cbVersion.DataSource = _versions;
            cbVersion.Text = "-";

            //Loading Years to CB
            _years = db.Versions
                    .Select(v => v.Year)
                    .ToList();
            cbYear.DataSource = _years;
            cbYear.Text = "-";

            //Loading Engines to CB
            _engines = db.Engines
                    .OrderBy(en => en.Name)
                    .ToList();
            cbEngine.DataSource = _engines;
            cbEngine.Text = "-";

            _parts = db.Parts
                .OrderBy(p => p.Name)
                .ToList();
            lbParts.DataSource = _parts;
        }*/
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
    
}
