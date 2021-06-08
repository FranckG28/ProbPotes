using ProbPotes.components;
using ProbPotes.managers;
using ProbPotes.models;
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

namespace ProbPotes.pages
{
    public partial class ReportsPage : UserControl
    {

        public ReportsPage()
        {
            InitializeComponent();

            label1.Font = new Font(Fonts.regular, 13);

            List<EventClass> eventList = DatabaseManager.Events.Events;

            foreach(EventClass e in eventList)
            {
                EventPreview ctrl = new EventPreview(e);
                flowLayoutPanel1.Controls.Add(ctrl);
            }
            
        }
    }
}
