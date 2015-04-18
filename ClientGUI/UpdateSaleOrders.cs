using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;
using Common;
using System.Collections;

namespace ClientGUI
{
    public partial class UpdateSaleOrders : Form
    {
        public ClientApp App { get; set; }
        public ArrayList SaleOrders { get; set; }

        private int ComboBoxValue { get; set; }

        private int SelectedItemId { get; set; }

        public UpdateSaleOrders()
        {
            InitializeComponent();
        }

        public void InitializeComboBoxValues()
        {
            for (int i = 0, l = SaleOrders.Count; i < l; i++)
            {
                if (((SaleOrder)SaleOrders[i]).Amount != 0)
                {
                    saleComboBox.Items.Add(((SaleOrder)SaleOrders[i]).Id);
                }
            }
        }

        private void saleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ComboBoxValue = Int32.Parse(saleComboBox.SelectedItem.ToString());

            for (int i = 0, l = SaleOrders.Count; i < l; i++)
            {
                if (((SaleOrder)SaleOrders[i]).Id == ComboBoxValue)
                {
                    SelectedItemId = ((SaleOrder)SaleOrders[i]).Id;
                    diginotesNumberLabel.Text = "" + ((SaleOrder)SaleOrders[i]).Amount;
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            App.UpdateSaleOrder(SelectedItemId, Int32.Parse(newNumberTextBox.Text));
            this.Hide();
        }
    }
}
