using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DomainModel.Entities;

namespace Web.Models.DTO
{
    public class ProjectMemberDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ProjectMemberDto(User user)
        {
            UserId = user.Id;
            UserName = string.Format("{0} {1}", user.FirstName, user.LastName);
        }
    }

    public class ProjectMembersDto
    {
        public int ProjectId { get; set; }
        public IEnumerable<int> ProjectMembers { get; set; }
        public IEnumerable<ProjectMemberDto> Users { get; set; }

        public ProjectMembersDto(IEnumerable<int> projectMembers, IEnumerable<ProjectMemberDto> users, int projectId)
        {
            ProjectMembers = projectMembers;
            Users = users;
            ProjectId = projectId;
        }

    }
}