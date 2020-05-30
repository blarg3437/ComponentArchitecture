using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor.Windows
{
    public partial class ConfirmSelection : Form
    {
        public delegate void confirmed(bool option);
        public event confirmed Submitted;
        public ConfirmSelection(string message = "confirm")
        {
            InitializeComponent();
            label1.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //no
            Submitted(false);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //yes
            Submitted(true);
            Close();
        }
    }
}
