using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiag
{
    public class Theme
    {
        private string name;
        private DateTime creationDate;
        private bool secured;
        private bool closed;
        private string id;

        public Section Section
        {
            get => default(Section);
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