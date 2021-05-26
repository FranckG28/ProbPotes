using ProbPotes.components;
using ProbPotes.pages;
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
        public Control content;
        public String title;
        public Pages id;

        public NavigationTemplate(NavBarItem nav, Control content, Pages id, String title)
        {
            this.content = content;
            this.navItem = nav;
            this.title = title;
            this.id = id;
        }

        public PageTemplate GetPage()
        {
            PageTemplate page = new PageTemplate();
            page.Title = title;
            page.Icon = navItem.Icon;
            page.Content = content;
            navItem.Selected = true;
            return page;
        }

        public void Unselect()
        {
            navItem.Selected = false;
        }

    }
}
