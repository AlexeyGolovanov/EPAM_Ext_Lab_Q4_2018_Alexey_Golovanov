namespace UserRepositoryTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task9.Models;
    using Task9.Repos;
    using Task9.Interfaces;

    [TestClass]
    public class UserRepositoryTests
    {
        private string connectionString = @"Server=DESKTOP-JDEOSGT;Database=Forum;Integrated Security=True;";

        [TestMethod]
        public void GetById()
        {
            
            IUserRepository repo = new UserRepository(connectionString);

            User user = repo.Get(1);

            Assert.AreNotEqual(user,null);
        }

        [TestMethod]
        public void DeleteTest()
        {
            IUserRepository repo = new UserRepository(connectionString);

            int uniqueId = 4;
            repo.Delete(uniqueId);

            User user = new User(uniqueId, "name", Role.Plebs, "qwer", "tstEmail@1.com", DateTime.Now, Country.Russia, "Male", "Name", "Surname", new DateTime(1996, 01, 28));

            Assert.IsTrue(repo.Save(user));

            Assert.IsTrue(repo.Delete(user.UserId));

            Assert.AreEqual(repo.Get(user.UserId), null);
        }

        [TestMethod]
        public void SaveTest()
        {
            IUserRepository repo = new UserRepository(connectionString);

            int uniqueId = 4;
            repo.Delete(uniqueId);

            User user = new User(uniqueId, "name", Role.Plebs, "qwer", "tstEmail@1.com", DateTime.Now, Country.Russia, "Male", "Name", "Surname", new DateTime(1996, 01, 28));

            Assert.IsTrue(repo.Save(user));

            repo.Delete(uniqueId);
        }

        [TestMethod]
        public void GetAllTest()
        {
            IUserRepository repo = new UserRepository(this.connectionString);
            List<User> users = repo.GetAll();

            Assert.AreNotEqual(users.Count, 0);

            foreach (var u in users)
            {
                Trace.WriteLine(u.UserId + " " + u.Username);
            }
        }

        [TestMethod]
        public void GetAllUsersNumberTest()
        {
            int amount = 3;
            UserRepository repo = new UserRepository(connectionString);
            List<User> users = repo.GetAll(amount);

            if (users.Count != amount)
            {
                Assert.Fail();
            }

            foreach (var u in users)
            {
                Trace.WriteLine(u.UserId + " " + u.Username);
            }
        }

    }
}
