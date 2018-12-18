using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiag
{
    public class BanRecord
    {
        private bool banStatus;
        private DateTime startDate;
        private DateTime endDate;
        private string ban_id;

        public Regular bannedUser
        {
            get => default(Regular);
            set
            {
            }
        }

        public Ruler whoBanned
        {
            get => default(Ruler);
            set
            {
            }
        }
    }
}