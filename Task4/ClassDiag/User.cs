using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiag
{
    public abstract class User
    {
        private string user_id;
        private string email;
        private string username;
        private string password;
        private DateTime registration_date;
        private int avatar_image;
        private DateTime birthDate;

        public Countries Country
        {
            get => default(Countries);
            set
            {
            }
        }

        public Gender Gender
        {
            get => default(Gender);
            set
            {
            }
        }

        public void ChangeOwnProps()
        {
            throw new System.NotImplementedException();
        }

        public void AddTheme()
        {
            throw new System.NotImplementedException();
        }

        public void AddMessage()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteOwnMsg()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteOwnTheme()
        {
            throw new System.NotImplementedException();
        }
    }
}