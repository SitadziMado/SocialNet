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
        private Core mSystem = new Core();

        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            mSystem.LoadUsers();
        }

        private void ProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mSystem.UnloadUsers();
            e.Cancel = false;
        }
    }
}
