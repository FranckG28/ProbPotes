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

namespace ProbPotes.pages
{
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();

            // Ajout des liens :
            tileEvents.DestinationPage = Pages.Events;
            tileExpenses.DestinationPage = Pages.Expenses;
            tileParticipants.DestinationPage = Pages.Participants;
            tileTotal.DestinationPage = Pages.Reports;

            // Définition des polices :
            txtAddExpenseTitle.Font = new Font(Fonts.medium, 25);
            txtAddExpenseDescription.Font = new Font(Fonts.regular, 13);

            // Définition des couleurs :
            iconAddExpense.ForeColor = Colors.black;
            txtAddExpenseTitle.ForeColor = Colors.black;
            txtAddExpenseDescription.ForeColor = Colors.grey;

            // Définition des icones :
            iconAddExpense.Text = char.ConvertFromUtf32(0xE719);


            //TEMPORAIRE : Ajout d'un évènement de test
            EventClass evenement = new EventClass(20, "MonEvent", 20, true, "Commentaire de l'event", DateTime.Now.AddDays(-2), DateTime.Now, new List<int>() { 10, 20, 50, 6056 }, new List<Expense>());
            eventPreview1.EventClass = evenement;
        }

    }
}
