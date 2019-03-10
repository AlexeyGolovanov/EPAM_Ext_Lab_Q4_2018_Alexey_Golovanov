namespace Task9.Repos
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using Interfaces;
    using Models;

    public class UserRepository : IUserRepository
    {
        private string connectionString;
        private string connectionDbType;

        public UserRepository(string connectionString, string connectionDbType = "System.Data.SqlClient")
        {
            this.connectionString = connectionString;
            this.connectionDbType = connectionDbType;
        }

        public User Get(int id)
        {
            DbProviderFactory providerFactory = DbProviderFactories.GetFactory(this.connectionDbType);

            using (IDbConnection connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                IDbCommand command = connection.CreateCommand();

                command.CommandText = $"SELECT * FROM dbo.Users WHERE UserId = {id}";

                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User user = new User(
                                (int)reader["UserId"],
                                (string)reader["Username"],
                                (Role)((int)reader["Role"]),
                                (string)reader["Password"],
                                (string)reader["Email"],
                                (DateTime)reader["RegDate"],
                                (Country)((int)reader["Country"]),
                                (string)reader["Gender"],
                                (string)reader["FirstName"],
                                (string)reader["LastName"],
                                (DateTime)reader["BirthDate"]);

                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public List<User> GetAll()
        {
            DbProviderFactory providerFactory = DbProviderFactories.GetFactory(this.connectionDbType);

            using (IDbConnection connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM dbo.Users";

                List<User> allUsers = new List<User>();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User(
                            (int)reader["UserId"],
                            (string)reader["Username"],
                            (Role)((int)reader["Role"]),
                            (string)reader["Password"],
                            (string)reader["Email"],
                            (DateTime)reader["RegDate"],
                            (Country)((int)reader["Country"]),
                            (string)reader["Gender"],
                            (string)reader["FirstName"],
                            (string)reader["LastName"],
                            (DateTime)reader["BirthDate"]);

                        allUsers.Add(user);
                    }
                }

                return allUsers;
            }
        }

        public List<User> GetAll(int num)
        {
            DbProviderFactory providerFactory = DbProviderFactories.GetFactory(this.connectionDbType);

            using (IDbConnection connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                IDbCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@num";
                param.Value = num;
                command.Parameters.Add(param);

                command.CommandText = "[dbo].[GetAllUsers]";

                List<User> users = new List<User>();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User(
                            (int)reader["UserId"],
                            (string)reader["Username"],
                            (Role)((int)reader["Role"]),
                            (string)reader["Password"],
                            (string)reader["Email"],
                            (DateTime)reader["RegDate"],
                            (Country)((int)reader["Country"]),
                            (string)reader["Gender"],
                            (string)reader["FirstName"],
                            (string)reader["LastName"],
                            (DateTime)reader["BirthDate"]);

                        users.Add(user);
                    }
                }

                return users;
            }
        }

        public bool Save(User entity)
        {
            DbProviderFactory providerFactory = DbProviderFactories.GetFactory(this.connectionDbType);

            using (IDbConnection connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                IDbCommand command = connection.CreateCommand();

                if (this.Get(entity.UserId) != null)
                {
                    command.CommandText = string.Format(
                        "UPDATE dbo.Users SET" +
                        "Username = '{0}'," +
                        "Role = '{1}', " +
                        "Password = '{2}', " +
                        "Email = '{3}', " +
                        "RegDate = '{4}', " +
                        "Country = '{5}', " +
                        "Gender = '{6}', " +
                        "FirstName = '{7}', " +
                        "LastName = '{8}', " +
                        "BirthDate = '{9}'" +
                        "WHERE UserId = '{10}'",
                        entity.Username,
                        (int)entity.Role,
                        entity.Password,
                        entity.Email,
                        entity.RegDate.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        (int)entity.Country,
                        entity.Gender,
                        entity.FirstName,
                        entity.LastName,
                        entity.BirthDate.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        entity.UserId);

                    var result = command.ExecuteNonQuery();

                    if (result == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    command.CommandText = string.Format(
                    "INSERT INTO dbo.Users" +
                    "(UserId," +
                    "Username," +
                    "Role, " +
                    "Password, " +
                    "Email, " +
                    "RegDate, " +
                    "Country, " +
                    "Gender, " +
                    "FirstName, " +
                    "LastName, " +
                    "BirthDate)" +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')",
                    entity.UserId,
                    entity.Username,
                    (int)entity.Role,
                    entity.Password,
                    entity.Email,
                    entity.RegDate,
                    (int)entity.Country,
                    entity.Gender,
                    entity.FirstName,
                    entity.LastName,
                    entity.BirthDate);

                    var result = command.ExecuteNonQuery();

                    if (result == 0)
                    {
                        return false;
                    }

                    return true;
                }
            }
        }

        public bool Delete(int id)
        {
            DbProviderFactory providerFactory = DbProviderFactories.GetFactory(this.connectionDbType);

            using (IDbConnection connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                IDbCommand command = connection.CreateCommand();

                if (this.Get(id) != null)
                {
                    command.CommandText = string.Format("DELETE FROM dbo.Users WHERE UserId = '{0}'", id);

                    var result = command.ExecuteNonQuery();

                    if (result == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
