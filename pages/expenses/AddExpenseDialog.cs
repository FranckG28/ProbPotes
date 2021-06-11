using ProbPotes.components;
using ProbPotes.managers;
using ProbPotes.models;
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
    public partial class AddExpenseDialog : UserControl, IDialogPage
    {

        private EventClass SelectedEvent;
        private ProbPotesDialog ParentDialog;
        private Participant Payer;

        public AddExpenseDialog(EventClass eventClass)
        {
            InitializeComponent();

            this.SelectedEvent = eventClass;

            // Cacher les onglets
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            // Styles
            List<Label> labels = new List<Label>() { lblDescription, lblEndDate, lblAmount, lblTitle, txtSuccessfulDescription};
            foreach(Label lbl in labels)
            {
                ProbPotesDialog.ApplyLabelStyle(lbl);
            }

            List<Label> titles = new List<Label>() { txtTitle1, txtTitle2, txtTitle3, txtTitleSuccess, txtTitle0 };
            foreach(Label title in titles)
            {
                ProbPotesDialog.ApplyTitleStyle(title);
            }

            List<TextBox> boxes = new List<TextBox>() { boxDescription, boxTitle, boxAmount };
            foreach(TextBox box in boxes)
            {
                ProbPotesDialog.ApplyTextBoxStyle(box);
            }

            List<DateTimePicker> dates = new List<DateTimePicker>() { date };
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

            lblEuro.Font = new Font(Fonts.medium, 14);
            lblEuro.ForeColor = Colors.grey;

            // Icones
            iconDate.Text = char.ConvertFromUtf32(59161);
            iconTitle.Text = char.ConvertFromUtf32(59151);
            iconDescription.Text = char.ConvertFromUtf32(59959);
            iconSuccessful.Text = char.ConvertFromUtf32(0xE73E);

            List<Label> icons = new List<Label>() {iconDate, iconDescription, iconTitle };
            foreach(Label icon in icons)
            {
                icon.ForeColor = Colors.black;
            }

            iconSuccessful.ForeColor = Colors.blue;

            // Affichage de la liste des évènements
            List<EventClass> eventList = DatabaseManager.Events.Events;
            eventList.Reverse();
            foreach (EventClass e in eventList)
            {
                if (!e.SoldeOn)
                {
                    EventPreview ep = new EventPreview();
                    ep.EventClass = e;
                    ep.ClickAction = EventClick;
                    pnlEvents.Controls.Add(ep);
                }
            }

            // Ajout de l'évènement PayerClick à la selection du payeur
            psPayer.SelectAction = PayerClick;

        }

        private void SetEvent(EventClass e)
        {
            this.SelectedEvent = e;
            if (e != null && ParentDialog != null)
            {
                ParentDialog.Title = "Ajouter une dépense à " + e.Title;
            }
        }

        private void EventClick(EventClass e)
        {
            SetEvent(e);
            ParentDialog.Navigate(Index + 1);
        }

        private void PayerClick(Participant p)
        {
            Payer = p;
            Debug.WriteLine(p.FirstName);
            ParentDialog.Navigate(Index+1);
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
                if (value == 2)
                {

                    txtWarningTitle.Visible = boxTitle.Text == "";
                    if (boxTitle.Text != "")
                    {
                        // Ne pas afficher les participants qui ne font pas parti de l'évènement et celui qui paie la 
                        psPayer.SetExcludedParticipant(GetExcludedParticipant());
                        tabControl1.SelectedIndex = value;
                    }
                } else if (value == 3)
                {
                    txtWarningCreator.Visible = psPayer.SelectedParticipants.Count == 0;
                    if (psPayer.SelectedParticipants.Count > 0)
                    {

                        // Ne pas afficher les participants qui ne font pas parti de l'évènement et celui qui paie la dépense
                        List<Participant> excluded = new List<Participant>() { psPayer.SelectedParticipants.First() };
                        excluded.AddRange(GetExcludedParticipant());
                        psRecipients.SetExcludedParticipant(excluded);

                        tabControl1.SelectedIndex = value;
                    }
                } else if (value == 4)
                {
                    // AJOUT DE LA DEPENSE

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

        private List<Participant> GetExcludedParticipant()
        {
            List<Participant> excluded = new List<Participant>();
            foreach (Participant p in DatabaseManager.Participants.Participants)
            {
                if (!SelectedEvent.Guests.Contains(p.Code))
                    excluded.Add(p);
            }
            return excluded;
        }

        public int PageCount
        {
            get => tabControl1.TabCount;
        }

        public bool ShowBackBtn => true;

        public bool ShowNextBtn => Index != 0 && Index != 2;

        public ProbPotesDialog ParentController { 
            set
            {
                ParentDialog = value;
                if (SelectedEvent != null)
                {
                    ParentDialog.Navigate(1);
                }
            }
         }

        public void FocusBox()
        {
            boxTitle.Select();
        }

        // TODO: Ajouter vérification des champs

    }
}
