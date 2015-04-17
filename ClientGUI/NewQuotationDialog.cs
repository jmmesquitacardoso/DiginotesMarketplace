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
using System.Globalization;

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
            CultureInfo info = new CultureInfo("en-US");
            float newQuotation = float.Parse(quotationTextBox.Text, info);

            if (Type == OrderType.Purchase && newQuotation >= Quotation)
            {
                App.UpdateServerQuotation(newQuotation);
                this.Close();
            }
            else if (Type == OrderType.Sale && newQuotation <= Quotation)
            {
                App.UpdateServerQuotation(newQuotation);
                this.Close();
            }
            else
            {
                errorLabel.Text = "Invalid Value";
            }

        }
    }
}
