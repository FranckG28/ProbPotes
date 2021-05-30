using ProbPotes.components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.services
{
    public class HoverController
    {

        public List<HoverColor> Colors;

        private UserControl parent;
        
        protected bool isHover = false;
        protected bool isPressed = false;

        public HoverController(List<HoverColor> colors, UserControl parent)
        {
            this.Colors = colors;
            this.parent = parent;

            // Ajout des evènements de souris sur tous les controles :
            foreach(HoverColor color in colors)
            {
                foreach (Control ctrl in color.Controls)
                {
                    AddEventsToChildrens(ctrl);
                }
            }

            // Initialisation des couleurs :
            parent.Load += new EventHandler(this.Load);

        }

        private void AddEventsToChildrens(Control ctrl)
        {
            // Ajout de l'évènement à ce controle
            AddEvents(ctrl);

            // Si ce controle a des enfants :
            if (ctrl.Controls.Count != 0)
            {
                // Appel récursif de cette fonction pour tout ses enfants
                foreach(Control ctrlChild in ctrl.Controls)
                { 
                    AddEventsToChildrens(ctrlChild);
                }
            }
        }

        private void AddEvents(Control ctrl)
        {
            ctrl.MouseEnter += new System.EventHandler(this.MouseEnter);
            ctrl.MouseLeave += new System.EventHandler(this.MouseLeave);
            ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
        }

        private void Load(object sender, EventArgs e)
        {
            Refresh();
        }

        public bool Hover
        {
            get => isHover;
            set
            {
                isHover = value;
                Refresh();
            }
        }

        public bool Pressed
        {
            get => isPressed;
            set
            {
                isPressed = value;
                Refresh();
            }
        }

        public virtual void Refresh()
        {
           foreach(HoverColor hoverColor in Colors)
            {
                if (isPressed)
                {
                    hoverColor.SetPressed();
                }
                else if (isHover)
                {
                    hoverColor.SetHover();
                }
                else
                {
                    hoverColor.SetDefault();
                }
            }
        }

        #region Events

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (!(((Control)sender).Parent is IconButton && !(parent is IconButton))) {
                Pressed = true;
            }
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            Hover = true;
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            Hover = false;
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (!(((Control)sender).Parent is IconButton && !(parent is IconButton)))
            {
                Pressed = false;
            }
        }

        #endregion

    }
}
