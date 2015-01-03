using System.Collections.Generic;
using BLL.DomainModel.Entities;

namespace BLL.Repositories
{
    public interface IUserRepository
    {
        User FindById(int id);
        IEnumerable<User> FindAll();
        IEnumerable<User> FindByProjectId(int projectId);

        void Delete(int userId);

        void Save(User user);
   
    }
}
