using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace Roca
{
    public partial class frmBrowser : Form
    {
        public frmBrowser()
        {
            InitializeComponent();
            webBrowser1.Navigate("https://www.google.com/");
        }

        protected TitleBarTabs ParentTabs 
        {
            get 
            {
                return (ParentForm as TitleBarTabs);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(richTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com/");
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btnRefresh.Image = imgRefresh.Image;
            richTextBox1.Text = webBrowser1.Url.AbsoluteUri;
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            btnRefresh.Image = imgspinner.Image;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && richTextBox1.Text.Trim().Length>0) 
            {
                if (richTextBox1.Text.Contains(".")) 
                {
                    webBrowser1.Navigate(richTextBox1.Text.Trim());
                }
                else 
                {
                    webBrowser1.Navigate("https://www.google.com/search?q="+ richTextBox1.Text.Trim().Replace(" ", "+") + "&rlz=1C1ONGR_enUS943US943&oq=space+space&aqs=opera..69i57j0l5j69i61j69i60.3126j0j7&sourceid=chrome&ie=UTF-8");
                }
            }
        }
    }
}
