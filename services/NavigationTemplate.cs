using ProbPotes.components;
using ProbPotes.managers;
using ProbPotes.pages;
using ProbPotes.pages.events;
using ProbPotes.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.models
{
    public class NavigationTemplate
    {

        public NavBarItem navItem;
        public String title;
        public Pages id;

        public PageTemplate.AddButtonDelegate addAction;

        public NavigationTemplate(NavBarItem nav, Pages id, String title, PageTemplate.AddButtonDelegate addAction)
        {
            this.navItem = nav;
            this.title = title;
            this.id = id;
            this.addAction = addAction;
        }

        public PageTemplate GetPage()
        {
            PageTemplate page = new PageTemplate();
            page.Title = title;
            page.Icon = navItem.Icon;
            
            switch (id)
            {
                case Pages.Home:
                    page.Content = new HomePage();
                    break;
                case Pages.Events:
                    if (DatabaseManager.Events.Events != null && DatabaseManager.Events.Events.Count > 0)
                    {
                        page.Content = new EventsPage();
                    } else
                    {
                        page.Content = new NoEventPage();
                    }
                    break;
                case Pages.Expenses:
                    page.Content = new ExpensesPage();
                    break;
                case Pages.Participants:
                    page.Content = new ParticipantsPage();
                    break;
                case Pages.Reports:
                    page.Content = new ReportsPage();
                    break;
            }

            if (addAction != null) {
                page.AddButtonAction = addAction;
            }
            navItem.Selected = true;
            return page;
        }

        public void Unselect()
        {
            navItem.Selected = false;
        }

    }
}
