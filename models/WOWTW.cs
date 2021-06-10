using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.models
{
    class WOWTW
    {

        public Participant Participant;
        public Dictionary<int, Decimal> GiveTo;
        public Dictionary<int, Decimal> ReceiveFrom;

        public WOWTW(Participant p, Dictionary<int, Decimal> giveTo, Dictionary<int, Decimal> receiveFrom)
        {
            Participant = p;
            GiveTo = giveTo;
            ReceiveFrom = receiveFrom;
        }

    }
}
