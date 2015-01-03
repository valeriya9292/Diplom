using System.Collections.Generic;
using BLL.DomainModel.Entities;
using BLL.Repositories;

namespace BLL.Services
{
    public class CommentService
    {
        private readonly ICommentRepository repository;

        public CommentService(ICommentRepository repository)
        {
            this.repository = repository;
        }

        Comment FindCommentById(int id)
        {
            return repository.FindById(id);
        }

        IEnumerable<Comment> FindAllComments()
        {
            return repository.FindAll();
        }

        IEnumerable<Comment> FindCommentsByTaskId(int taskId)
        {
            return repository.FindByTaskId(taskId);
        }

        void DeleteComment(int commentId)
        {
            repository.Delete(commentId);
        }

        void SaveComment(Comment comment)
        {
            repository.Save(comment);
        }
    }
}
