using ProbPotes.managers;
using ProbPotes.models;
using ProbPotes.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.components.expenses
{
    public partial class ExpenseReportTile : UserControl
    {

        private Expense expense;
        private HoverController hover;

        public ExpenseReportTile()
        {
            InitializeComponent();
            Init();
        }

        public ExpenseReportTile(Expense expense)
        { 
            InitializeComponent();
            Init();
            Expense = expense;
        }

        private void Init()
        {
            // Création de l'effet de survol
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightGrey, Colors.lightBlue2, Colors.blue);
            HoverColor hoverForeBlue = new HoverColor(new List<Control>() { txtTitle, txtCreator }, true, Colors.blue, Colors.blue, Colors.white);
            HoverColor hoverForeBlack = new HoverColor(new List<Control>() { txtRecipients, iconRecipients, txtLblParticipants, txtLblDescription, iconDescription }, true, Colors.black, Colors.black, Colors.white);
            HoverColor hoverPriceFg = new HoverColor(new List<Control>() { txtPrice }, true, Colors.white, Colors.white, Colors.white);
            HoverColor hoverPriceBg = new HoverColor(new List<Control>() { txtPrice }, false, Colors.blue, Colors.blue, Colors.lightBlue);
            HoverColor hoverGreyBg = new HoverColor(new List<Control>() { pnlLine, pnlLine2 }, false, Colors.lightGrey, Colors.lightGrey, Colors.white);
            HoverColor hoverGreyFg = new HoverColor(new List<Control>() { txtDescription }, true, Colors.grey, Colors.grey, Colors.white);

            hover = new HoverController(new List<HoverColor>() {hoverBg, hoverForeBlue, hoverForeBlack, hoverPriceFg, hoverPriceBg, hoverGreyBg, hoverGreyFg }, this);

            // Icones :
            iconRecipients.Text = char.ConvertFromUtf32(0xE716);
            iconDescription.Text = char.ConvertFromUtf32(0XE8C4);

            // Polices :
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtTitle.Font = new Font(Fonts.bold, 14);
                txtDescription.Font = new Font(Fonts.regular, 11);
                txtPrice.Font = new Font(Fonts.bold, 15);
                txtRecipients.Font = new Font(Fonts.book, 10);
                txtCreator.Font = new Font(Fonts.regular, 10);
                txtLblParticipants.Font = new Font(Fonts.bold, 10);
                txtLblDescription.Font = new Font(Fonts.bold, 10);
            }

        }

        public Expense Expense
        {
            get => expense;
            set
            {
                expense = value;
                if (expense != null)
                {
                    Participant creator = DatabaseManager.Participants.GetParticipant(expense.creatorCode);
                    txtTitle.Text = expense.description;
                    txtDescription.Text = expense.comment;
                    txtPrice.Text = expense.sum.ToString()+" €";
                    txtCreator.Text = "par " + creator.FirstName + " " + creator.Name.ToUpper() + " le " + expense.date.ToShortDateString();

                    // Génération d'une liste des participants 
                    txtRecipients.Text = DatabaseManager.Participants.GetStringFromList(expense.recipients);
                }
            }
        }
    }
}
