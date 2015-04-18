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
    public partial class UpdatePurchaseOrders : Form
    {
        public ClientApp App { get; set; }
        public ArrayList PurchaseOrders { get; set; }

        private int ComboBoxValue { get; set; }

        private int SelectedItemId { get; set; }

        public UpdatePurchaseOrders()
        {
            InitializeComponent();
        }

        public void InitializeComboBoxValues()
        {
            for (int i = 0, l = PurchaseOrders.Count; i < l; i++)
            {
                if (((PurchaseOrder)PurchaseOrders[i]).Amount != 0)
                {
                    purchaseComboBox.Items.Add(((PurchaseOrder)PurchaseOrders[i]).Id);
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            App.UpdatePurchaseOrder(SelectedItemId, Int32.Parse(newNumberTextBox.Text));
            this.Hide();
        }

        private void purchaseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ComboBoxValue = Int32.Parse(purchaseComboBox.SelectedItem.ToString());

            for (int i = 0, l = PurchaseOrders.Count; i < l; i++) 
            {
                if (((PurchaseOrder)PurchaseOrders[i]).Id == ComboBoxValue) 
                {
                    SelectedItemId = ((PurchaseOrder)PurchaseOrders[i]).Id;
                    diginotesNumberLabel.Text = "" + ((PurchaseOrder)PurchaseOrders[i]).Amount;
                }
            }
        }
    }
}
