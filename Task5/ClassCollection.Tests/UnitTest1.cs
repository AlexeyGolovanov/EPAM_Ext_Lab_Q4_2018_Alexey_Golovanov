namespace ClassCollection.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1 //todo pn не мнемоничное имя
    {
        [TestMethod]
        public void TestGetUserFull()
        {
            Repos<User> repos = new Repos<User>();
            int id = 111;
            string username = "Name";

            repos.Save(new User(111, "Name"));
            User checkingUser = new User(id, username);
            User realUser = repos.Get(0);

            Assert.AreEqual(checkingUser.Id, realUser.Id);
            Assert.AreEqual(checkingUser.Username, realUser.Username);
        }

        [TestMethod]
        public void TestGetUserId()
        {
            Repos<User> repos = new Repos<User>();
            int id = 111;

            repos.Save(new User(111));
            User checkingUser = new User(id);
            User realUser = repos.Get(0);

            Assert.AreEqual(checkingUser.Id, realUser.Id);
            Assert.IsNull(realUser.Username);
        }

        [TestMethod]
        public void TestGetUserName()
        {
            Repos<User> repos = new Repos<User>();
            string username = "Name";

            repos.Save(new User("Name"));
            User checkingUser = new User(username);
            User realUser = repos.Get(0);

            Assert.AreEqual(checkingUser.Id, realUser.Id);
            Assert.AreEqual(checkingUser.Username, realUser.Username);
        }

        [TestMethod]
        public void TestGetAllUsers()
        {
            Repos<User> repos = new Repos<User>();
            List<User> us = new List<User>();

            for (int i = 0; i < 5; i++)
            {
                us.Add(new User(i, "Name" + i));
                repos.Save(new User(i, "Name" + i));
            }

            foreach (User u in repos.GetAll())
            {
                Console.WriteLine(u);
            }

            var n = 0;
            foreach (User s in repos.GetAll())
            {
                Assert.AreEqual(us[n].Id, s.Id);
                Assert.AreEqual(us[n].Username, s.Username);
                n++;
            }
        }

        [TestMethod]
        public void TestSaveUser()
        {
            Repos<User> repos = new Repos<User>();
            repos.Save(new User(111, "Name"));
            int id = 111;
            string username = "Name";

            Assert.AreEqual(id, repos.Get(0).Id);
            Assert.AreEqual(username, repos.Get(0).Username);
        }

        [TestMethod]
        public void TestDeleteUserFull()
        {
            Repos<User> repos = new Repos<User>();

            repos.Save(new User(111, "Name"));

            Assert.IsTrue(repos.Delete(0));
        }

        [TestMethod]
        public void TestDeleteUserId()
        {
            Repos<User> repos = new Repos<User>();

            repos.Save(new User(111));

            Assert.IsTrue(repos.Delete(0));
        }

        [TestMethod]
        public void TestDeleteUserName()
        {
            Repos<User> repos = new Repos<User>();

            repos.Save(new User("Name"));

            Assert.IsTrue(repos.Delete(0));
        }

        [TestMethod]
        public void TestDeleteUserEmpty()
        {
            Repos<User> repos = new Repos<User>();

            repos.Save(new User());

            Assert.IsTrue(repos.Delete(0));
        }

        [TestMethod]
        public void TestDeleteUserNull()
        {
            Repos<User> @base = new Repos<User>();

            Assert.IsFalse(@base.Delete(0));
        }  
    }
}
