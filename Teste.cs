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
    public partial class Teste : Form
    {
        /*
        private List<Make> _makes;
        private List<Model> _models;
        private List<Models.Version> _versions;

        private Context db = new Context();

        private Make _selectedMake;
        private Model _selectedModel;
        private Models.Version _selectedVersion;
        */

        public Teste()
        {
            InitializeComponent();

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {/*
            _makes = db
                .Makes
                .OrderBy(m => m.Name)
                .ToList();
            _makes.Insert(0, new Make
            {
                Name = "-",
                Id = -1
            });
            cbMarci.DataSource = _makes;
            */
        }

        private void cbMarci_SelectedValueChanged(object sender, EventArgs e)
        {/*
            if (cbMarci.SelectedIndex == 0)
            {
                _selectedMake = null;
                _models = null;
                _versions = null;
                cbVersion.DataSource = _versions;
                cbModel.DataSource = _models;
            }
            else
            {
                _selectedMake = cbMarci.SelectedValue as Make;
                _models = db.Models.Where(m => m.MakeId == _selectedMake.Id)
                    .OrderBy(m => m.Name)
                    .ToList();
                _models.Insert(0, new Model
                {
                    Name = "-"
                });
                cbModel.DataSource = _models;
            }*/
        }

        private void cbModel_SelectedValueChanged(object sender, EventArgs e)
        {/*
            if (cbModel.SelectedIndex == 0)
            {
                _versions = null;
                _selectedVersion = null;
                cbVersion.DataSource = _versions;
            } else
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
            }*/
        }
    }
}
