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
        private bool mLink = false;

        public ProfileForm()
        {
            InitializeComponent();
        }

        string InputBox(string title, bool multiline = false)
        {
            string res = String.Empty;

            var form = new TextDataForm(title, $"{title}:", (string r) => { res = r; }, multiline);
            form.ShowDialog();

            return res;
        }

        bool IsCurrent()
        {
            return mCore.Current == mCore.Rendered && !mLink;
        }

        void RenderInfo()
        {
            var cur = mCore.Rendered; // mCore.Current;

            InitialsTextBox.Text = cur.Initials;
            BirthdayDateTimePicker.Value = cur.Birthday;
            GenderComboBox.SelectedIndex = Person.GenderToIndex(cur.Gender);
            MaritalStatusComboBox.SelectedIndex = Person.MaritalStatusToIndex(cur.MaritalStatus);
            SchoolTextBox.Text = cur.School;
            UniversityTextBox.Text = cur.University;

            bool b = mCore.Current == mCore.Rendered; // IsCurrent();

            InitialsTextBox.Enabled = b;
            BirthdayDateTimePicker.Enabled = b;
            GenderComboBox.Enabled = b;
            MaritalStatusComboBox.Enabled = b;
            SchoolTextBox.Enabled = b;
            UniversityTextBox.Enabled = b;

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

            mLink = false;
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
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new Size(size, size),
                    Text = a.ToString(),
                };

                label.Tag = a;
                label.MouseClick += DynamicElement_MouseClick;

                flp.Controls.Add(label);
            }
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            // mSystem.LoadUsers();
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
            // mSystem.UnloadUsers();
            e.Cancel = false;
        }

        private void AddPostLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var name = InputBox("Введите имя человека");

            if (name != String.Empty)
            {
                mCore.Current.AddPost(new Post(name));
                RenderInfo();
            }
        }

        private void AddPictureLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var name = InputBox("Введите имя человека");

            if (name != String.Empty)
            {
                mCore.Current.AddPicture(new Picture(name));
                RenderInfo();
            }
        }

        private void AddFriendLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var name = InputBox("Введите имя человека");

            if (name != String.Empty)
            {
                try
                {
                    var person = mCore.FindByName(name);
                    mCore.Current.AddFriend(person);
                    RenderInfo();
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
            }
        }

        private void ProfileForm_SizeChanged(object sender, EventArgs e)
        {
            RenderInfo();
        }

        private void InitialsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (IsCurrent())
                mCore.Current.Initials = InitialsTextBox.Text;
        }

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (IsCurrent())
                mCore.Current.Birthday = BirthdayDateTimePicker.Value;
        }

        private void GenderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsCurrent())
                mCore.Current.Gender = Person.IndexToGender(GenderComboBox.SelectedIndex);
        }

        private void MaritalStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsCurrent())
                mCore.Current.MaritalStatus = Person.IndexToMaritalStatus(MaritalStatusComboBox.SelectedIndex);
        }

        private void SchoolTextBox_TextChanged(object sender, EventArgs e)
        {
            if (IsCurrent())
                mCore.Current.School = SchoolTextBox.Text;
        }

        private void UniversityTextBox_TextChanged(object sender, EventArgs e)
        {
            if (IsCurrent())
                mCore.Current.University = UniversityTextBox.Text;
        }

        private void ExitLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Relogin();
        }

        private void DynamicElement_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                object tag = ((Control)sender).Tag;

                if (e.Button == MouseButtons.Left)
                {
                    if (tag is Person)
                    {
                        mCore.Rendered = tag as Person;
                        mLink = true;
                        RenderInfo();
                    }
                }
                else if (e.Button == MouseButtons.Middle && IsCurrent())
                {
                    if (tag is Person)
                        mCore.Current.RemoveFriend(tag as Person);
                    else if (tag is Picture)
                        mCore.Current.RemovePicture(tag as Picture);
                    else if (tag is Post)
                        mCore.Current.RemovePost(tag as Post);
                    else
                    {
                        MessageBox.Show("Программа еще не умеет работать с данным типом элементов.");
                        return;
                    }

                    RenderInfo();
                }
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Некорректный элемент.");
            }
        }
    }
}
