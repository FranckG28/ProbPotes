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
using ProbPotes.services;

namespace ProbPotes.pages.events
{
    public partial class AddEventDialog : UserControl, IDialogPage
    {
        private ProbPotesDialog ParentDialog;

        private EventClass oldEvent;
        private bool editMode = false;

        public AddEventDialog(Del refresh)
        {
            InitializeComponent();

            this.RefreshMainForm = refresh;

            Init();
            
        }

        public AddEventDialog(Del refresh, EventClass eventClass)
        {
            InitializeComponent();

            this.RefreshMainForm = refresh;
            this.editMode = true;
            this.oldEvent = eventClass;

            Init();

            // Réinsérer les données de l'évènement :
            boxTitle.Text = oldEvent.Title;
            boxDescription.Text = oldEvent.Description;
            dateStart.Value = oldEvent.StartDate;
            dateEnd.Value = oldEvent.EndDate;
            psCreator.SelectedParticipants = new List<Participant>() { DatabaseManager.Participants.GetParticipant(oldEvent.CreatorCode) };
            List<Participant> participants = new List<Participant>();
            foreach(int i in oldEvent.Guests)
            {
                participants.Add(DatabaseManager.Participants.GetParticipant(i));
            }
            psGuests.SelectedParticipants = participants;

            txtTitleSuccess.Text = "Évènement modifié";
        }

        private void Init()
        {
            // Cacher les onglets
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            // Styles
            List<Label> labels = new List<Label>() { lblDescription, lblEndDate, lblStartDate, lblTitle, txtSuccessfulDescription, txtTip };
            foreach (Label lbl in labels)
            {
                ProbPotesDialog.ApplyLabelStyle(lbl);
            }

            List<Label> titles = new List<Label>() { txtTitle1, txtTitle2, txtTitle3, txtTitleSuccess };
            foreach (Label title in titles)
            {
                ProbPotesDialog.ApplyTitleStyle(title);
            }

            List<TextBox> boxes = new List<TextBox>() { boxDescription, boxTitle };
            foreach (TextBox box in boxes)
            {
                ProbPotesDialog.ApplyTextBoxStyle(box);
            }

            List<DateTimePicker> dates = new List<DateTimePicker>() { dateEnd, dateStart };
            foreach (DateTimePicker date in dates)
            {
                ProbPotesDialog.ApplyDatePickerStyle(date);
            }

            List<Label> warnings = new List<Label>() { txtWarningCreator, txtWarningTitle };
            foreach (Label lbl in warnings)
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
            iconSuccessful.ForeColor = Colors.blue;

            List<Label> icons = new List<Label>() { iconDate, iconDescription, iconTitle };
            foreach (Label icon in icons)
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
                }
                else if (value == 2)
                {
                    txtWarningCreator.Visible = psCreator.SelectedParticipants.Count == 0;
                    if (psCreator.SelectedParticipants.Count > 0)
                    {
                        psGuests.SetExcludedParticipant(new List<Participant>() { psCreator.SelectedParticipants.First() });
                        tabControl1.SelectedIndex = value;
                    }
                }
                else if (value == 3)
                {
                    // AJOUT DE L'EVENEMENT

                    // Création de la liste des codes invités
                    List<int> guests = new List<int>();
                    foreach (Participant p in psGuests.SelectedParticipants)
                    {
                        guests.Add(p.Code);
                    }

                    EventClass newEvent = new EventClass(
                        editMode ? oldEvent.Code : DatabaseManager.Events.Events.Count + 1,
                        boxTitle.Text,
                        psCreator.SelectedParticipants.First().Code,
                        editMode ? oldEvent.SoldeOn : false,
                        boxDescription.Text,
                        dateStart.Value.Date,
                        dateEnd.Value.Date,
                        guests
                        );

                    bool result = editMode ? DatabaseManager.Events.UpdateEvent(newEvent) : DatabaseManager.Events.AddEvent(newEvent);

                    // SI REUSSITE 
                    if (result)
                    {
                        // TODO : ENVOYER UN EMAIL A TOUT LE MONDE !!!! OU juste les nouveaux si modificaiton
                        Email email = new Email();
                        Boolean mailSend= email.sendMail("destinataire", "objet du msg", "msg du mail");//JSP COMMENT FAIRE LA BOUCLE MAIS LA METHODE MAIL C'EST CELLE CI
                        txtSuccessfulDescription.Text = "L'évènement " + newEvent.Title + " a bien été enregistré !";
                        tabControl1.SelectedIndex = value;
                        RefreshMainForm?.DynamicInvoke();
                    }
                    else
                    {
                        MessageBox.Show("Impossible d'enregistrer l'évènement");
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

        public delegate void Del();
        public Del RefreshMainForm;
    }
}
