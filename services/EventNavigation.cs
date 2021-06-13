﻿using ProbPotes.managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.models
{
    class EventNavigation
    {

        public DataSet data;
        public BindingSource eventBs;
        public BindingSource participantsBs;
        public BindingNavigator bn;

        private ParticipantManager participants = new ParticipantManager();

        public EventNavigation(DataSet data, BindingSource eventBs, BindingSource participantsBs, BindingNavigator bn)
        {
            this.data = data;
            this.eventBs = eventBs;
            this.participantsBs = participantsBs;
            this.bn = bn;
        }

        public void PreviousButton()
        {
            eventBs.MovePrevious();
        }
        public void NextButton()
        {
            eventBs.MoveNext();
        }
        public void FirstButton()
        {
            eventBs.MoveFirst();
            participantsBs.MoveFirst();
        }
        public void LastButton()
        {
            eventBs.MoveLast();
            participantsBs.MoveLast();
        }

        public int EventCount
        {
            get => data.Tables["Evenements"].Rows.Count;
        }

        public int Index
        {
            get => eventBs.Position+1;
        }

        public Participant Creator
        {
            get
            {
                // Recherche du code du créateur :
                DataRow[] eventResult = data.Tables["Evenements"].Select("codeEvent = " + Index);

                // Recherche du participant :
                return participants.GetParticipant((int)eventResult.First()["codeCreateur"]);
            }
        }

        public List<Participant> ParticipantList
        {
            get
            {
                // Recherche des numéros de participant :
                DataRow[] participantCodes = data.Tables["Invites"].Select("codeEvent = " + Index);

                List<Participant> guests = new List<Participant>();

                // Recherches des participants correspondants :
                foreach (DataRow row in participantCodes)
                {
                    guests.Add(DatabaseManager.Participants.GetParticipant((int)row["codePart"]));
                }

                return guests;
            }
        }

        public EventClass Event
        {
            get
            {
                // Recherche des numéros de participant :
                return DatabaseManager.Events.GetEvent(Index);
            }
        }

    }
}
