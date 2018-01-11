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
    public partial class TextDataForm : Form
    {
        Action<string> mAct;

        public TextDataForm(string caption, string title, Action<string> act, bool multiline = false)
        {
            InitializeComponent();

            Text = caption;
            TitleLabel.Text = title;
            mAct = act;
            InfoTextBox.Multiline = multiline;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            mAct(InfoTextBox.Text);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            mAct(String.Empty);
            Close();
        }
    }
}
