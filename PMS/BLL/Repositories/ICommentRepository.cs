using System.Collections.Generic;
using BLL.DomainModel.Entities;

namespace BLL.Repositories
{
    public interface ICommentRepository
    {
        //todo: remove unused
        Comment FindById(int id);
        IEnumerable<Comment> FindAll();

        IEnumerable<Comment> FindByTaskId(int taskId);

        void Delete(int commentId);

        void Save(Comment comment);
    }
}
