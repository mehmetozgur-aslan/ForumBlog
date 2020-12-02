using ForumBlog.DataAccess.Interface;
using ForumBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.DataAccess.Concrete.EntityFrameworkCore.Repository
{
    public class EfCommentRepository : EfGenericRepository<Comment>, ICommentDal
    {
    }
}
