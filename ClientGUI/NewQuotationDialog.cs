using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Client;

namespace ClientGUI
{
    public partial class NewQuotationDialog : Form
    {
        OrderType Type { get; set; }

        float Quotation { get; set; }

        public ClientApp App { get; set; }
        
        public NewQuotationDialog(OrderType type, float currentQuot)
        {
            InitializeComponent();
            Type = type;
            Quotation = currentQuot;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void confirmQuotation_Click(object sender, EventArgs e)
        {
            float newQuotation = float.Parse(quotationTextBox.Text);

            if (Type == OrderType.Purchase && App.GetPurchaseOrders().Count > 0 &&  newQuotation >= Quotation)
            {
                App.UpdateServerQuotation(newQuotation);
            }
            else if (Type == OrderType.Purchase && App.GetSaleOrders().Count > 0 && float.Parse(quotationTextBox.Text) <= Quotation)
            {
                App.UpdateServerQuotation(newQuotation);
            }

            this.Close();
        }
    }
}
