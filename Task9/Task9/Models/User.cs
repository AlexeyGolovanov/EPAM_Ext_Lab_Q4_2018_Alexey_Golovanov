namespace Task9.Models
{
    using System;

    public class User
    {
        public User()
        {
            this.Username = string.Empty;
            this.Role = 0;
            this.Password = string.Empty;
            this.Email = string.Empty;
            this.RegDate = DateTime.MinValue;
            this.Country = 0;
            this.Gender = string.Empty;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.BirthDate = DateTime.MinValue;
        }

        public User(
            int id, 
            string username, 
            Role role, 
            string password, 
            string email, 
            DateTime regDate,
            Country country, 
            string gender, 
            string firstName, 
            string lastName, 
            DateTime birthDate)
        {
            this.UserId = id;
            this.Username = username;
            this.Role = role;
            this.Password = Hash.HashPassword(password);
            //this.Password = password;
            this.Email = email;
            this.RegDate = regDate;
            this.Country = country;
            this.Gender = gender;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
        }

        public int UserId { get; set; }

        public string Username { get; set; }

        public Role Role { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegDate { get; set; }

        public Country Country { get; set; }

        public string Gender { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
