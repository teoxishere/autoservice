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
    public partial class PartEdit : Form
    {
        private Part _selectedPart;
        private Context db;
        
        public PartEdit()
        {
            InitializeComponent();
        }
        public PartEdit(Part _selectedPart, Context db)
        {
           
            InitializeComponent();
            this.db = db;
            this._selectedPart = _selectedPart;
            label6.Text = _selectedPart.Name;
            textBox5.Text = _selectedPart.Details;
            textBox3.Text = _selectedPart.Price.ToString();
            textBox4.Text =_selectedPart.Quantity.ToString();
            label7.Text = _selectedPart.Oem_Code;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool parsePrice=false, parseQty=false;
            var price = double.MinValue;
            var qty = int.MinValue;
            if (textBox3.Text != null && double.TryParse(textBox3.Text, out price) && textBox4.Text != null && int.TryParse(textBox4.Text, out qty)) {
                var partToEdit = db.Parts
                                    .Where(p => p.Name.Equals(_selectedPart.Name) || p.Oem_Code.Equals(_selectedPart.Oem_Code))
                                    .FirstOrDefault();

                // partToEdit.Price = double.TryParse(textBox3.Text, out price);
                    
                    partToEdit.Price = double.Parse(textBox3.Text);
                if (int.Parse(textBox4.Text) > 0)
                {
                    partToEdit.Quantity = int.Parse(textBox4.Text);
                    partToEdit.InStock = true;
                }else
                {
                    partToEdit.Quantity = 0;
                    partToEdit.InStock = false;
                }
                    partToEdit.Details = textBox5.Text;
                    db.SaveChanges();
                    MessageBox.Show("Editarea a avut succes!");
                    this.Close();
            }else
            {
                MessageBox.Show("Valori incorecte in campurile Pret si Cantitate!");
            }
        }
    }
}
