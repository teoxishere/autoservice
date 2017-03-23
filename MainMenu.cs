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
        private List<Make> _makes;
        private List<Model> _models;
        private List<Models.Version> _versions;
        private List<Engine> _engines;
        private List<Part> _parts;
        private List<Int32> _years;

        private Context db = new Context();

        private Make _selectedMake;
        private Model _selectedModel;
        private Models.Version _selectedVersion;
        private Engine _selectedEngine;
        private Part _selectedPart;
        private int  _selectedYears;
        public MainMenu()
        {
            InitializeComponent();
        }

        

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //Loading Makes to CB
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
        }
        
        private void cbMake_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbMake.SelectedIndex == 0)
            {
                _selectedMake = null;
                _models = null;
                _versions = null;
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
            }
        }
        private void cbModel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbModel.SelectedIndex == 0)
            {
                _versions = null;
                _selectedVersion = null;
                cbVersion.DataSource = _versions;
            }
            else
            {
                _selectedModel = cbModel.SelectedValue as Model;
                _versions = db.Versions
                    .Where(v => v.ModelId == _selectedModel.Id)
                    .OrderBy(v => v.Year)
                    .ToList();
                _versions.Insert(0, new Models.Version
                {
                    Name = "-"
                });
                cbVersion.DataSource = _versions;
            }
        }
        /*
       private void cbVersion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbVersion.SelectedIndex == 0)
            {
                _versions = null;
                _selectedVersion = null;
                cbVersion.DataSource = _versions;
                cbYear.DataSource = _versions;
            }
            else
            {
                _selectedVersion = cbVersion.SelectedValue as Models.Version;
                _versions = db.Versions
                    .Where(v => v.ModelId == _selectedModel.Id)
                    .Where(v=>v.Year)
                    .OrderBy(v => v.Year)
                    .ToList();
                _versions.Insert(0, new Models.Version
                {
                    Name = "-"
                });
                cbVersion.DataSource = _versions;
            }
        }
        */


    }
}
