using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Data;
using TrackerLibrary.DataAccess;

namespace TrackerGUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if(ValidateForm())
            {
                PrizeData data = new PrizeData(
                    placeNameValue.Text, 
                    placeNumberValue.Text, 
                    prizeAmountValue.Text, 
                    prizePercentageValue.Text);

                GlobalConfig.Connection.CreatePrize(data);

                placeNameValue.Text = "";
                placeNumberValue.Text = "";
                prizeAmountValue.Text = "0"; 
                prizePercentageValue.Text = "0";
            }
            else
            {
                MessageBox.Show("This form has invalid information.");
            }

        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberIsNumber = int.TryParse(placeNumberValue.Text, out placeNumber);

            if (placeNumberIsNumber == false)
            {
                output = false;
            }

            if(placeNumber < 1)
            {
                output = false;
            }

            if (placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountIsValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool prizePercentageIsValid = double.TryParse(prizePercentageValue.Text, out prizePercentage);

            if(prizeAmountIsValid == false || prizePercentageIsValid == false)
            {
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <=0)
            {
                output = false;
            }

            if(prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }
    }
}
