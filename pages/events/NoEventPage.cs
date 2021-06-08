using ProbPotes.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.pages.events
{
    public partial class NoEventPage : UserControl
    {
        public NoEventPage()
        {
            InitializeComponent();

            txtTitle.Font = new Font(Fonts.book, 20);
            txtTitle.ForeColor = Colors.grey;
        }
    }
}
