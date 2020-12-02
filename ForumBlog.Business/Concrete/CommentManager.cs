using ForumBlog.Business.Interface;
using ForumBlog.DataAccess.Interface;
using ForumBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.Business.Concrete
{
    public class CommentManager : GenericManager<Comment>, ICommentService
    {
        private readonly IGenericDal<Comment> _genericDal;
        public CommentManager(IGenericDal<Comment> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
