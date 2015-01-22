using System.Collections.Generic;
using BLL.DomainModel.Entities;
using BLL.Repositories;

namespace BLL.Services
{
    public class UserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }
        public User FindUserById(int userId)
        {
            return repository.FindById(userId);
        }

        public IEnumerable<User> FindUsersByProjectId(int projectId)
        {
            return repository.FindByProjectId(projectId);
        }

        public User FindUserByLogin(string login)
        {
            return repository.FindUserByLogin(login);
        }
        public IEnumerable<User> FindAllUsers()
        {
            return repository.FindAll();
        }
        public void DeleteUser(int id)
        {
            repository.Delete(id);
        }
        public void SaveUser(User user)
        {
            repository.Save(user);
        }
    }
}
