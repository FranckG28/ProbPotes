using ProbPotes.components;
using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.services
{

    public enum Pages
    {
        Home, 
        Expenses,
        Events,
        Participants,
        Reports
    }


    public class NavigationController
    {

        public List<NavigationTemplate> pages;

        private NavigationTemplate selected;

        private Panel view;

        public NavigationController(Panel panel)
        {
            pages = new List<NavigationTemplate>();
            view = panel;
        }

        public void AddNavigation(NavBarItem nav, Control page, Pages id, string title = "") 
        {
            if (title == "")
            {
                title = nav.Title;
            }
            NavigationTemplate navTemplate = new NavigationTemplate(nav, page, id, title);
            nav.page = navTemplate;
            nav.action = NavigateTo;
            pages.Add(navTemplate);
            if (pages.Count == 1)
            {
                NavigateTo(navTemplate);
            }
        }

        private void NavigateTo(NavigationTemplate destination)
        {
            view.Controls.Clear();
            ResetSelected();
            view.Controls.Add(destination.GetPage());
            selected = destination;
        }

        public void NavigateTo(Pages page)
        {
            IEnumerable<NavigationTemplate> query = pages.Where(p => p.id == page);
            NavigateTo(query.First());
        }

        private void ResetSelected()
        {
            foreach(NavigationTemplate nav in pages)
            {
                nav.Unselect();
            }
        }

    }
}
