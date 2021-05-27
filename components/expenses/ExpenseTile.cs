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
    public partial class ExpenseTile : UserControl
    {

        private Expense expense;
        private HoverController hover;

        public ExpenseTile()
        {
            InitializeComponent();
            Init();
        }

        public ExpenseTile(Expense expense)
        { 
            InitializeComponent();
            Init();
            Expense = expense;
        }

        private void Init()
        {
            // Création de l'effet de survol
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightBlue, Colors.blue, Colors.green);
            HoverColor hoverForeBlue = new HoverColor(new List<Control>() { txtTitle, txtCreator }, true, Colors.blue, Colors.white, Colors.white);
            HoverColor hoverForeBlack = new HoverColor(new List<Control>() { txtDescription, txtRecipients, iconRecipients }, true, Colors.black, Colors.white, Colors.white);
            HoverColor hoverPriceFg = new HoverColor(new List<Control>() { txtPrice }, true, Colors.white, Colors.white, Colors.white);
            HoverColor hoverPriceBg = new HoverColor(new List<Control>() { txtPrice }, false, Colors.blue, Colors.lightBlue, Colors.lightBlue);

            hover = new HoverController(new List<HoverColor>() {hoverBg, hoverForeBlue, hoverForeBlack, hoverPriceFg, hoverPriceBg }, this);

            // Icones :
            iconRecipients.Text = char.ConvertFromUtf32(0xE716);

            // Polices :
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtTitle.Font = new Font(Fonts.bold, 16);
                txtDescription.Font = new Font(Fonts.regular, 11);
                txtPrice.Font = new Font(Fonts.bold, 16);
                txtRecipients.Font = new Font(Fonts.book, 12);
                txtCreator.Font = new Font(Fonts.regular, 12);
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
                    txtTitle.Text = expense.description;
                    txtDescription.Text = expense.comment;
                    txtPrice.Text = expense.sum.ToString()+" €";
                    txtCreator.Text = "par " + expense.creatorCode.ToString();

                    // Génération d'une liste des participants 
                    string participantList = "";
                    foreach(int participant in expense.recipients)
                    {
                        participantList += participant.ToString() + ", ";
                    }
                    txtRecipients.Text = participantList;
                }
            }
        }
    }
}
