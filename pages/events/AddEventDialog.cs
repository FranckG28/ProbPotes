﻿using ProbPotes.components;
using ProbPotes.services;
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

namespace ProbPotes.pages.events
{
    public partial class AddEventDialog : UserControl, IDialogPage
    {
        private ProbPotesDialog ParentDialog;

        public AddEventDialog()
        {
            InitializeComponent();

            // Cacher les onglets
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            // Styles
            List<Label> labels = new List<Label>() { lblDescription, lblEndDate, lblStartDate, lblTitle, txtSuccessfulDescription };
            foreach(Label lbl in labels)
            {
                ProbPotesDialog.ApplyLabelStyle(lbl);
            }

            List<Label> titles = new List<Label>() { txtTitle1, txtTitle2, txtTitle3, txtTitleSuccess };
            foreach(Label title in titles)
            {
                ProbPotesDialog.ApplyTitleStyle(title);
            }

            List<TextBox> boxes = new List<TextBox>() { boxDescription, boxTitle };
            foreach(TextBox box in boxes)
            {
                ProbPotesDialog.ApplyTextBoxStyle(box);
            }

            List<DateTimePicker> dates = new List<DateTimePicker>() { dateEnd, dateStart };
            foreach (DateTimePicker date in dates)
            {
                ProbPotesDialog.ApplyDatePickerStyle(date);
            }

            List<Label> warnings = new List<Label>() { txtWarningCreator, txtWarningTitle };
            foreach(Label lbl in warnings)
            {
                lbl.ForeColor = Colors.red;
                lbl.Font = new Font(Fonts.book, 12);
                lbl.Visible = false;
            }

            // Icones
            iconDate.Text = char.ConvertFromUtf32(59271);
            iconTitle.Text = char.ConvertFromUtf32(59151);
            iconDescription.Text = char.ConvertFromUtf32(59959);
            iconSuccessful.Text = char.ConvertFromUtf32(0xE73E);

            List<Label> icons = new List<Label>() {iconDate, iconDescription, iconTitle };
            foreach(Label icon in icons)
            {
                icon.ForeColor = Colors.black;
            }

        }

        public bool CanGoBack
        {
            get => tabControl1.SelectedIndex > 0;
        }

        public bool CanGoForward
        {
            get => tabControl1.SelectedIndex < tabControl1.TabCount - 1;
        }

        public int Index
        {
            get => tabControl1.SelectedIndex;
            set
            {

                if (value == 1)
                {
                    txtWarningTitle.Visible = boxTitle.Text == "";
                    if (boxTitle.Text != "")
                    {
                        tabControl1.SelectedIndex = value;
                    }
                } else if (value == 2)
                {
                    txtWarningCreator.Visible = psCreator.SelectedParticipants.Count == 0;
                    if (psCreator.SelectedParticipants.Count > 0)
                    {
                        tabControl1.SelectedIndex = value;
                    }
                } else if (value == 3)
                {
                    // AJOUT DE L'EVENEMENT

                    // SI REUSSITE 
                    if (true)
                    {
                        tabControl1.SelectedIndex = value;
                    }
                }
                else
                {
                    tabControl1.SelectedIndex = value;
                }
            }
        }

        public int PageCount
        {
            get => tabControl1.TabCount;
        }

        public bool ShowBackBtn => true;

        public bool ShowNextBtn => true;

        public ProbPotesDialog ParentController { set => ParentDialog = value; }

        public void FocusBox()
        {
            boxTitle.Select();
        }
    }
}
