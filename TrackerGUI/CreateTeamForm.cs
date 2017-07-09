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
        private List<PersonData> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonData> selectedTeamMembers = new List<PersonData>();

        public CreateTeamForm()
        {
            InitializeComponent();
         //   CreateSampleData();
            SetUpLists();
        }

         private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonData { FirstName = "Emir", Lastname = "Misic" });
            availableTeamMembers.Add(new PersonData { FirstName = "Sandra", Lastname = "Sahlen" });

            selectedTeamMembers.Add(new PersonData { FirstName = "Sheila", Lastname = "Misic" });
            selectedTeamMembers.Add(new PersonData { FirstName = "Emma", Lastname = "Karlsson" });
        }

        private void SetUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;

            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";

        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonData p = new PersonData();

                p.FirstName = firstNameValue.Text;
                p.Lastname = lastNameValue.Text;
                p.EmailAddress = mailValue.Text;
                p.PhoneNumber = phoneValue.Text;

                p = GlobalConfig.Connection.CreatePerson(p);

                selectedTeamMembers.Add(p);

                SetUpLists();

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

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonData p = (PersonData)selectTeamMemberDropDown.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                SetUpLists();
            }

        }

        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonData p = (PersonData)teamMembersListBox.SelectedItem;

            if (p != null)
            {

                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                SetUpLists();
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamData t = new TeamData();

            t.TeamName = teamNameValue.Text;
            t.TeamMembers = selectedTeamMembers;

            t = GlobalConfig.Connection.CreateTeam(t);

            // TODO om vi inte stänger formen efter att vi skapat laget, reseta den
        }
    }
}
