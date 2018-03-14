using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SocialNet
{
    public partial class ProfileForm : Form
    {
        private Core mCore = new Core();

        public ProfileForm()
        {
            InitializeComponent();
        }

        string InputBox(string title, string[] autoComplete = null, bool multiline = false)
        {
            string res = String.Empty;

            var form = new TextDataForm(title, $"{title}:", (string r) => { res = r; }, autoComplete, multiline);
            form.ShowDialog();

            return res;
        }

        void RenderInfo()
        {
            LockControls();

            var cur = mCore.Profile; // Current;

            InitialsTextBox.Text = cur.Initials;
            BirthdayDateTimePicker.Value = cur.Birthday;
            GenderComboBox.SelectedIndex = Person.GenderToIndex(cur.Gender);
            MaritalStatusComboBox.SelectedIndex = Person.MaritalStatusToIndex(cur.MaritalStatus);
            SchoolTextBox.Text = cur.School;
            UniversityTextBox.Text = cur.University;

            RenderBoxes(cur.Friends, FriendsLayout);
            RenderBoxes(cur.Pictures, PicturesLayout);
            RenderBoxes(cur.Posts, PostsLayout);

            var updates = cur.Updates;

            UpdatesListBox.Items.Clear();

            if (updates != null)
                foreach (var a in cur.Updates)
                    UpdatesListBox.Items.Add(a.Info);
            else
                UpdatesListBox.Items.Add("Никто из Ваших друзей еще ничего не сделал.");
        }

        void RenderBoxes<T>(IEnumerable<T> collection, FlowLayoutPanel flp)
        {
            var size = flp.Height;

            flp.Controls.Clear();

            foreach (var a in collection)
            {
                var label = new Label
                {
                    AutoSize = false,
                    Text = a.ToString(),
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new Size(size, size),
                };

                label.MouseClick += (object sender, MouseEventArgs e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (a is Person)
                            mCore.Profile = (object)a as Person;
                    }
                    else
                    {
                        if (IsThisProfile())
                            mCore.MouseEvent(a, e);
                    }

                    RenderInfo();

                };

                flp.Controls.Add(label);
            }
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            mCore.LoadUsers();
            Relogin();
        }

        private void Relogin()
        {
            var loginForm = new LoginForm(mCore);

            loginForm.ShowDialog();
            RenderInfo();
        }

        private void ProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mCore.UnloadUsers();
            e.Cancel = false;
        }

        private void AddPostLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var name = InputBox("Введите текст публикации");

            if (name != String.Empty)
            {
                mCore.Current.AddPost(new Post(name));
                RenderInfo();
            }
        }

        private void AddPictureLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var name = InputBox("Введите заголовок изображения");

            if (name != String.Empty)
            {
                mCore.Current.AddPicture(new Picture(name));
                RenderInfo();
            }
        }

        private void AddFriendLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool friendAdded = false;

            while (!friendAdded)
            {
                var name = InputBox("Введите имя человека", mCore.Names.ToArray());

                if (name != String.Empty)
                {
                    try
                    {
                        var person = mCore.FindByName(name);
                        mCore.Current.AddFriend(person);
                        RenderInfo();
                        friendAdded = true;
                    }
                    catch (UserNotRegisteredException)
                    {
                        MessageBox.Show(
                            "Пользователь не найден.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation
                        );
                    }
                    catch (AlreadyFriendsException)
                    {
                        MessageBox.Show(
                            "Пользователь уже Ваш друг.",
                            "Информация",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void ProfileForm_SizeChanged(object sender, EventArgs e)
        {
            RenderInfo();
        }

        private void ExitLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Relogin();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            var c = mCore.Current;

            if (InitialsTextBox.Text != mCore.Current.Initials)
                c.Initials = InitialsTextBox.Text;

            if (BirthdayDateTimePicker.Value != c.Birthday)
                c.Birthday = BirthdayDateTimePicker.Value;

            var gender = Person.IndexToGender(GenderComboBox.SelectedIndex);

            if (gender != c.Gender)
                c.Gender = gender;

            var ms = Person.IndexToMaritalStatus(MaritalStatusComboBox.SelectedIndex);

            if (ms != c.MaritalStatus)
                c.MaritalStatus = ms;

            if (SchoolTextBox.Text != c.School)
                c.School = SchoolTextBox.Text;

            if (UniversityTextBox.Text != c.University)
                c.University = UniversityTextBox.Text;
        }

        private void LockControls()
        {
            var enabled = IsThisProfile();

            InitialsTextBox.Enabled = enabled;
            BirthdayDateTimePicker.Enabled = enabled;
            GenderComboBox.Enabled = enabled;
            MaritalStatusComboBox.Enabled = enabled;
            SchoolTextBox.Enabled = enabled;
            UniversityTextBox.Enabled = enabled;
            ApplyButton.Enabled = enabled;

            AddFriendLabel.Enabled = enabled;
            AddPictureLabel.Enabled = enabled;
            AddPostLabel.Enabled = enabled;
        }

        private bool IsThisProfile()
        {
            return mCore.Current == mCore.Profile;
        }
    } 
}
