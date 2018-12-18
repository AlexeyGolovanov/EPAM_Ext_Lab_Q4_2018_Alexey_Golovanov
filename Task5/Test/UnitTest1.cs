using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetUser_with_id_and_name()
        {
            Base<User> @base = new Base<User>();
            int ID = 12;
            string NAME = "Frank";
            @base.Save(new User(12, "Frank"));
            User usCheck = new User(ID, NAME);
            User usAct = @base.Get(0);


            Assert.AreEqual(usCheck.id, usAct.id);
            Assert.AreEqual(usCheck.name, usAct.name);
        }

        [TestMethod]
        public void TestGetUser_with_id()
        {
            Base<User> @base = new Base<User>();
            int ID = 12;

            @base.Save(new User(12));
            User usCheck = new User(ID);
            User usAct = @base.Get(0);


            Assert.AreEqual(usCheck.id, usAct.id);
            Assert.IsNull(usAct.name);
        }

        [TestMethod]
        public void TestGetUser_with_name()
        {
            Base<User> @base = new Base<User>();
            string NAME = "Frank";
            @base.Save(new User("Frank"));
            User usCheck = new User(NAME);
            User usAct = @base.Get(0);


            Assert.AreEqual(usCheck.id, usAct.id);
            Assert.AreEqual(usCheck.name, usAct.name);
        }

        [TestMethod]
        public void TestDeleteUser_with_id_and_name()
        {
            Base<User> @base = new Base<User>();
            @base.Save(new User(12, "Frank"));

            Assert.IsTrue(@base.Delete(0));
        }

        [TestMethod]
        public void TestDeleteUser_with_id()
        {
            Base<User> @base = new Base<User>();


            @base.Save(new User(12));



            Assert.IsTrue(@base.Delete(0));
        }

        [TestMethod]
        public void TestDeleteUser_with_name()
        {
            Base<User> @base = new Base<User>();
            @base.Save(new User("Frank"));



            Assert.IsTrue(@base.Delete(0));
        }

        [TestMethod]
        public void TestDeleteEmptyUser()
        {
            Base<User> @base = new Base<User>();
            @base.Save(new User());



            Assert.IsTrue(@base.Delete(0));
        }
        [TestMethod]
        public void TestDeleteNull()
        {
            Base<User> @base = new Base<User>();
            Assert.IsFalse(@base.Delete(0));
        }


        [TestMethod]
        public void TestGetAllUsers()
        {
            Base<User> @base = new Base<User>();
            List<User> us = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                us.Add(new User(i, "Frank" + i));
                @base.Save(new User(i, "Frank" + i));
            }

            foreach (User s in @base.GetAll())
            {

                Console.WriteLine(s);
            }

            int j = 0;
            foreach (User s in @base.GetAll())
            {

                Assert.AreEqual(us[j].id, s.id);
                Assert.AreEqual(us[j].name, s.name);
                j++;
            }

        }

        [TestMethod]
        public void TestSaveUser()
        {
            Base<User> @base = new Base<User>();
            @base.Save(new User(12, "Frank"));
            int ID = 12;
            string NAME = "Frank";

            Assert.AreEqual<int>(ID, @base.Get(0).id);
            Assert.AreEqual<string>(NAME, @base.Get(0).name);
        }
    }
}
