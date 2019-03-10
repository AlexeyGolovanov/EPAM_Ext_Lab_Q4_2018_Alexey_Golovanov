namespace Task9.Services
{
    using System.Collections.Generic;
    using Interfaces;
    using Models;

    public class UserService : IUserService
    {
        private IUserRepository userRepo;

        public UserService(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public User Get(int id)
        {
            return this.userRepo.Get(id);
        }

        public List<User> GetAll()
        {
            return this.userRepo.GetAll();
        }

        public bool Save(User entity)
        {
            return this.userRepo.Save(entity);
        }

        public bool Delete(int id)
        {
            return this.userRepo.Delete(id);
        }
    }
}
