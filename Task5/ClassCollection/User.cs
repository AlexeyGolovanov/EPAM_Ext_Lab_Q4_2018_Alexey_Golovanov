namespace ClassCollection
{
    public class User
    {
        public User()
        {
            this.Id = -1;
            this.Username = null;
        }

        public User(int id, string name)
        {
            this.Id = id;
            this.Username = name;
        }

        public User(string name)
        {
            this.Id = -1;
            this.Username = name;
        }

        public User(int id)
        {
            this.Id = id;
            this.Username = null;
        }

        public int Id { get; private set; }

        public string Username { get; private set; }
    }
}
