using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xrpfloat
{
    public partial class Form1 : Form
    {

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.TopMost = true;
            this.Top =  0;
            this.Left = -3;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TickerSearch.UpdateTicker(this.label1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TickerSearch.UpdateTicker(this.label1);

            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Exit", new EventHandler(Exit_Click));
            this.label1.ContextMenu = cm;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
