using Newtonsoft.Json;
using PostApp.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PostApp.Net
{
    public class DataRetriever
    {
        public DataRetriever()
        {
        }

        public List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();

            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("http://jsonplaceholder.typicode.com/posts");

                if (!string.IsNullOrEmpty(json))
                {
                    posts = JsonConvert.DeserializeObject<Post[]>(json).ToList();
                }
            }

            return posts;
        }

        public List<Comment> GetComments(int? id)
        {
            List<Comment> comments = new List<Comment>();

            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("http://jsonplaceholder.typicode.com/posts/" + id + "/comments");

                if (!string.IsNullOrEmpty(json))
                {
                    comments = JsonConvert.DeserializeObject<Comment[]>(json).ToList();
                }
            }

            return comments;
        }

        public User GetUserInformation(int? id)
        {
            User userinfo = new User();

            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("http://jsonplaceholder.typicode.com/users/" + id);

                if (!string.IsNullOrEmpty(json))
                {
                    userinfo = JsonConvert.DeserializeObject<User>(json);

                }
            }

            return userinfo;
        }

    }
}
