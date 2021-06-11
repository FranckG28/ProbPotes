using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.models
{
    public class WOWTW
    {

        public int ParticipantId;
        public Dictionary<int, Decimal> GiveTo;
        public Dictionary<int, Decimal> ReceiveFrom;

        public WOWTW(int p, Dictionary<int, Decimal> giveTo, Dictionary<int, Decimal> receiveFrom)
        {
            ParticipantId = p;
            GiveTo = giveTo;
            ReceiveFrom = receiveFrom;
        }

    }
}
