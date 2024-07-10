using System;
using System.Reflection;
using System.Windows.Forms;

namespace PlainCheckApp
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            label2.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = linkLabel1.Text; 
            System.Diagnostics.Process.Start(url);
        }
    }
}
