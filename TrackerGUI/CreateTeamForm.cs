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

namespace TrackerGUI
{
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonData p = new PersonData();

                p.FirstName = firstNameValue.Text;
                p.Lastname = lastNameValue.Text;
                p.Email = mailValue.Text;
                p.PhoneNumber = phoneValue.Text;

                GlobalConfig.Connection.CreatePerson(p);

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                mailValue.Text = "";
                phoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("Du måste fylla i data i alla fält. Försök igen!");
            }
        }

        private bool ValidateForm()
        {
            if (firstNameValue.Text.Length == 0)
            {
                return false;
            }

            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }

            if (mailValue.Text.Length == 0)
            {
                return false;
            }

            if(phoneValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
