using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialNet
{
    public partial class LoginForm : Form
    {
        private Person mPerson;
        private Core mCore;

        public LoginForm(Core core)
        {
            InitializeComponent();
            mCore = core;

            UpdateUsers();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var login = CreateLoginTextBox.Text;
            var password = CreatePasswordTextBox.Text;

            if (login != String.Empty && password != String.Empty)
            {

                mPerson = new Person(login, password)
                {
                    Initials = InitialsTextBox.Text,
                    Birthday = BirthdayDateTimePicker.Value,
                    MaritalStatus = Person.IndexToMaritalStatus(MaritalStatusComboBox.SelectedIndex),
                    School = SchoolTextBox.Text,
                    University = UniversityTextBox.Text,
                    Gender = Person.IndexToGender(GenderComboBox.SelectedIndex),
                };

                mCore.Register(mPerson);

                Tabs.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(
                    "Логин/пароль должны состоять хотя бы из одного символа.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );                
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                mCore.Login(LoginTextBox.Text, PasswordTextBox.Text);
                Close();
            }
            catch  (UserNotRegisteredException)
            {
                MessageBox.Show(
                    "Некорректные логин/пароль.", 
                    "Ошибка", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            MaritalStatusComboBox.SelectedIndex = 0;
            GenderComboBox.SelectedIndex = 0;
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUsers();
        }

        private void UpdateUsers()
        {
            var source = new AutoCompleteStringCollection();
            source.AddRange(mCore.Usernames.ToArray());
            LoginTextBox.AutoCompleteCustomSource = source;

            UsernameListbox.Items.Clear();
            UsernameListbox.Items.AddRange(mCore.Usernames.ToArray());
            PasswordListbox.Items.Clear();
            PasswordListbox.Items.AddRange(mCore.Passwords.ToArray());
        }
    }
}
