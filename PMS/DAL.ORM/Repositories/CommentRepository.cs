using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BLL.DomainModel.Entities;
using BLL.Repositories;
using DAL.ORM.Convertions;
using ORM.Model;

namespace DAL.ORM.Repositories
{
    public class CommentRepository: ICommentRepository
    {
        public Comment FindById(int id)
        {
            using (var context = new PmsDbContext())
            {
                return context.Comments.FirstOrDefault(it => it.Id == id).ToEntityComment();
            }
        }

        public IEnumerable<Comment> FindAll()
        {
            using (var context = new PmsDbContext())
            {
                return context.Comments.Select(c => c.ToEntityComment());
            }
        }

        public IEnumerable<Comment> FindByTaskId(int taskId)
        {
            using (var context = new PmsDbContext())
            {
                return context.Comments.Where(c => c.TaskId == taskId).Select(c => c.ToEntityComment());
            }
        }

        public void Delete(int commentId)
        {
            using (var context = new PmsDbContext())
            {
                var comment = context.Comments.FirstOrDefault(c => c.Id == commentId);
                if (comment == null) return;
                context.Comments.Remove(comment);
                context.SaveChanges();
            }
        }

        public void Save(Comment comment)
        {
            using (var context = new PmsDbContext())
            {
                var oldComment = context.Comments.FirstOrDefault(c => c.Id == comment.Id);
                if (oldComment != null)
                {
                    oldComment.Description = comment.Description;

                    context.Entry(oldComment).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    context.Comments.Add(comment.ToOrmComment());
                }
                context.SaveChanges(); 
            }
        }
    }
}
