using System;
using System.Collections;
using aspnet_core_dotnet_core.Data;
using aspnet_core_dotnet_core.repo;

namespace aspnet_core_dotnet_core.Services
{
    public class CommentService
    {
        private CommentsRepository commentsRepository = new CommentsRepository();

        public Comments[] getAllComments(int movieId, string email)
        {
            ArrayList comments = commentsRepository.SearchCommentsByMovieId(movieId, email);
           

            if (comments!= null)
            {

                Comments[] Comment = new Comments[comments.Count];
                for (int i = 0; i < comments.Count; i++)
                {
                    Comment[i] = (Comments)comments[i];
                }
                return Comment;
            }

            return new Comments[1];
        }

        internal void postComment(int movieId,string email, string comment)
        {
            commentsRepository.insertComment(movieId, email, comment);
           }
    }
}