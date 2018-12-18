using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiag
{
    public class message
    {
        private string text;
        private DateTime date;
        private bool secured;
        private string id;

        public Theme Theme
        {
            get => default(Theme);
            set
            {
            }
        }

        public User Owner
        {
            get => default(User);
            set
            {
            }
        }
    }
}