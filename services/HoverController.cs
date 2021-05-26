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

        protected List<Control> bgControls;
        protected List<Control> fgControls;

        public Color bg_default;
        public Color bg_hover;
        public Color bg_pressed;

        public Color fg_default;
        public Color fg_hover;
        public Color fg_pressed;

        protected bool isHover = false;
        protected bool isPressed = false;

        public HoverController(List<Control> bg, List<Control> fg, UserControl parent)
        {
            bgControls = bg;
            fgControls = fg;

            foreach(Control ctrl in bg)
            {
                ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
                ctrl.MouseEnter += new System.EventHandler(this.MouseEnter);
                ctrl.MouseLeave += new System.EventHandler(this.MouseLeave);
                ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            }

            foreach (Control ctrl in fg)
            {
                ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
                ctrl.MouseEnter += new System.EventHandler(this.MouseEnter);
                ctrl.MouseLeave += new System.EventHandler(this.MouseLeave);
                ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            }

            parent.Load += new EventHandler(this.Load);

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
            if (isPressed)
            {
                SetForeground(fg_pressed);
                SetBackground(bg_pressed);

            }
            else if (isHover)
            {
                SetForeground(fg_hover);
                SetBackground(bg_hover);
            }
            else
            {
                SetForeground(fg_default);
                SetBackground(bg_default);
            }
        }


        #region Events

        private void MouseDown(object sender, MouseEventArgs e)
        {
            Pressed = true;
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
            Pressed = false;
        }

        #endregion


        #region Changement de couleur

        protected void SetForeground(Color color)
        {
            foreach (Control ctrl in fgControls)
            {
                ctrl.ForeColor = color;
            }
        }

        protected void SetBackground(Color color)
        {
            foreach(Control ctrl in bgControls)
            {
                ctrl.BackColor = color;
            }
            foreach(Control ctrl in fgControls)
            {
                ctrl.BackColor = Color.Transparent;
            }
        }

        #endregion

    }
}
