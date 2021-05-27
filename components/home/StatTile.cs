﻿using ProbPotes.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.components.home
{
    public partial class StatTile : UserControl
    {

        HoverController hover;

        public StatTile()
        {
            InitializeComponent();

            // Initialisation des polices :
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtNumber.Font = new Font(Fonts.bold, 25);
                txtDescription.Font = new Font(Fonts.regular, 14);
            }

            // Initialisation des effets de survol :
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightBlue, Colors.blue, Colors.green);
            HoverColor hoverFg = new HoverColor(new List<Control>() { txtDescription, txtIcon, txtNumber }, true, Colors.blue, Colors.white, Colors.white); 

            hover = new HoverController(new List<HoverColor>() { hoverBg, hoverFg }, this);

    }

        public Pages DestinationPage;

        private int iconInt = 0xE711;

        public int Icon
        {
            get => iconInt;
            set
            {
                iconInt = value;
                txtIcon.Text = char.ConvertFromUtf32(value);
            }
        }

        public String Number
        {
            get => txtNumber.Text;
            set => txtNumber.Text = value;
        }

        public String Description
        {
            get => txtDescription.Text;
            set => txtDescription.Text = value;
        }

        private void StatTile_Click(object sender, EventArgs e)
        {
                // Recuperation du controlleur de la navigation
                NavigationController navigation = ((MainForm) this.FindForm()).navigation;

                navigation.NavigateTo(DestinationPage);
        }

    }
}
