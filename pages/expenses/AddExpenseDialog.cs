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

        private Expense oldExpense;
        private bool editMode = false;

        public delegate void Del();
        private Del RefreshMainForm;

        public AddExpenseDialog(EventClass eventClass, Del refresh)
        {
            InitializeComponent();

            this.SelectedEvent = eventClass;
            this.RefreshMainForm = refresh;

            Init();

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

        }

        public AddExpenseDialog(EventClass eventClass, Del refresh, Expense expense)
        {
            InitializeComponent();

            this.SelectedEvent = eventClass;
            this.RefreshMainForm = refresh;
            this.oldExpense = expense;
            this.editMode = true;

            Init();

            // Suppression de la première page
            tabControl1.TabPages.RemoveAt(0);

            // Chargement des infos de la dépense
            boxTitle.Text = expense.description;
            boxDescription.Text = expense.comment;
            date.Value = expense.date;
            boxAmount.Text = expense.sum.ToString();
            psPayer.SelectedParticipants = new List<int>() { expense.creatorCode };
            psRecipients.SelectedParticipants = expense.recipients;
               
        }

        private void Init()
        {
            // Cacher les onglets
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            // Styles
            List<Label> labels = new List<Label>() { lblDescription, lblEndDate, lblAmount, lblTitle, txtSuccessfulDescription };
            foreach (Label lbl in labels)
            {
                ProbPotesDialog.ApplyLabelStyle(lbl);
            }

            List<Label> titles = new List<Label>() { txtTitle1, txtTitle2, txtTitle3, txtTitleSuccess, txtTitle0 };
            foreach (Label title in titles)
            {
                ProbPotesDialog.ApplyTitleStyle(title);
            }

            List<TextBox> boxes = new List<TextBox>() { boxDescription, boxTitle, boxAmount };
            foreach (TextBox box in boxes)
            {
                ProbPotesDialog.ApplyTextBoxStyle(box);
            }

            List<DateTimePicker> dates = new List<DateTimePicker>() { date };
            foreach (DateTimePicker date in dates)
            {
                ProbPotesDialog.ApplyDatePickerStyle(date);
            }

            List<Label> warnings = new List<Label>() { txtWarningCreator, txtWarningTitle, txtWarningMontant };
            foreach (Label lbl in warnings)
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

            List<Label> icons = new List<Label>() { iconDate, iconDescription, iconTitle };
            foreach (Label icon in icons)
            {
                icon.ForeColor = Colors.black;
            }

            iconSuccessful.ForeColor = Colors.blue;

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

        private void PayerClick(int pCpode)
        {
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
                if (value == (editMode ? 1 : 2))
                {

                    txtWarningTitle.Visible = boxTitle.Text == "";
                    txtWarningMontant.Visible = boxAmount.Text == "";
                    if (boxTitle.Text != "" && boxAmount.Text != "")
                    {
                        // Ne pas afficher les participants qui ne font pas parti de l'évènement et celui qui paie la 
                        psPayer.SetExcludedParticipant(GetExcludedParticipant());
                        tabControl1.SelectedIndex = value;
                    }
                } else if (value == (editMode ? 2 : 3))
                {
                    txtWarningCreator.Visible = psPayer.SelectedParticipants.Count == 0;
                    if (psPayer.SelectedParticipants.Count > 0)
                    {

                        // Ne pas afficher les participants qui ne font pas parti de l'évènement et celui qui paie la dépense
                        List<int> excluded = new List<int>() { psPayer.SelectedParticipants.First() };
                        excluded.AddRange(GetExcludedParticipant());
                        psRecipients.SetExcludedParticipant(excluded);

                        tabControl1.SelectedIndex = value;
                    }
                } else if (value == (editMode ? 3 : 4))
                {
                    // AJOUT DE LA DEPENSE

                    Expense newExpense = new Expense(
                        editMode ? oldExpense.code : DatabaseManager.Events.GetExpenseCount() + 1, 
                        SelectedEvent.Code, 
                        boxTitle.Text,
                        Convert.ToDecimal(boxAmount.Text),
                        psRecipients.SelectedParticipants,
                        psPayer.SelectedParticipants.First(),
                        date.Value.Date,
                        boxDescription.Text
                        );

                    bool result = editMode ? SelectedEvent.Expenses.UpdateExpense(newExpense) : SelectedEvent.Expenses.AddExpense(newExpense);

                    // SI REUSSITE 
                    if (result)
                    {
                        txtTitleSuccess.Text = editMode ? "Dépense modifiée" : "Dépense ajoutée";
                        txtSuccessfulDescription.Text = newExpense.description + " enregistré dans l'évènement " + SelectedEvent.Title;
                        tabControl1.SelectedIndex = value;
                        RefreshMainForm?.DynamicInvoke();
                    } else
                    {
                        MessageBox.Show("Impossible d'enregistrer la dépense");
                    }
                }
                else
                {
                    tabControl1.SelectedIndex = value;
                }
            }
        }

        private List<int> GetExcludedParticipant()
        {
            List<int> excluded = new List<int>();
            foreach (Participant p in DatabaseManager.Participants.Participants)
            {
                if (!SelectedEvent.Guests.Contains(p.Code) && SelectedEvent.CreatorCode != p.Code)
                    excluded.Add(p.Code);
            }
            return excluded;
        }

        public int PageCount
        {
            get => tabControl1.TabCount;
        }

        public bool ShowBackBtn => true;

        public bool ShowNextBtn => editMode || (Index != 0 && Index != 2);

        public ProbPotesDialog ParentController { 
            set
            {
                ParentDialog = value;
                if (SelectedEvent != null && !editMode)
                {
                    ParentDialog.Navigate(1);
                }
            }
         }

        public void FocusBox()
        {
            boxTitle.Select();
        }

        private void boxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifie si il y a un point et si oui il remplace un point en virgule
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            e.Handled = !CheckChar(e.KeyChar, (TextBox)sender);

        }


      // fonction qui permet de déterminer si un caractère est valide pour un champ de saisies de nombre floattant
    private bool CheckChar(char xChar, TextBox box)
        {
            // mets le boolean a faux par défault on dit que les caractères ne sont pas valide
            bool isValid = false;
            // si le caractère est un chiffre
            if (char.IsDigit(xChar))
            {
                // alors on accepte
                isValid = true;
            }
            // si c'est une virgule
            else if (xChar == ',')
            {
                // on accepte le caractere si la textBox ne contient pas de virgule
                isValid = !box.Text.Contains(',');
            }
            // si c'est un controle
            else if (char.IsControl(xChar))
            {
                // alors on accepte
                isValid = true;
            }
            // on retourne 
            return isValid;
        }

        // fonction qui reformater le montant lors de la perte du focus
        private void boxAmount_Leave(object sender, EventArgs e)
        {
            //recupération de la texBox
            TextBox box = (TextBox)sender;
            //si la textbox commence par une virgule
            if (box.Text.StartsWith(","))
            {
                // on remplace le texte par 0 et ce qu'il y avait dans la texBox
                box.Text = "0" + box.Text;
            }
            // si la longueur une fois trim c'est 0 

            if (box.Text.Trim().Length == 0)
            {
                //on mets 0 dans la box afin qu'elle en soit pas vide
                box.Text = "0";
            }
            // on transforme le texte en double
            double montant = double.Parse(box.Text);
            //on fait un arrondis au centième
            montant = Math.Round(montant, 2);
            // on remet le texte avec la valeurs arrondis
            box.Text = montant.ToString();
        }

 
    }
}
