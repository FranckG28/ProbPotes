using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProbPotes.tests
{
    public partial class testBDD : Form
    {
        public testBDD()
        {
            InitializeComponent();
        }

        private void testBDD_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Directory.GetCurrentDirectory());
        }
    }
}
