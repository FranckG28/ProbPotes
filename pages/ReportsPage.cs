using ProbPotes.components;
using ProbPotes.managers;
using ProbPotes.models;
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

        private EventManager eventManager;

        public ReportsPage()
        {
            InitializeComponent();

            eventManager = new EventManager();

            List<EventClass> eventList = eventManager.GetEvents();

            foreach(EventClass e in eventList)
            {
                EventPreview ctrl = new EventPreview(e);
                flowLayoutPanel1.Controls.Add(ctrl);
            }
            
        }
    }
}
