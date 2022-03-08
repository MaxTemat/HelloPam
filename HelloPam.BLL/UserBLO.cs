using HelloPam.BO;
using HelloPam.DAL;
using System.Linq;
using System;
using System.Collections.Generic;

namespace HelloPam.BLL
{
    public class UserBLO
    {
        private readonly UserDAO userDAO;
        public UserBLO()
        {
            this.userDAO = new UserDAO();
        }
        public void CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User");
            user.CreatedAt = DateTime.Now;
            if (user.Status == null)
                throw new ArgumentNullException("User Status cannot be Null !");
            if (user.Profile == null)
                throw new ArgumentNullException("User Profile cannot be Null !");
            userDAO.Add(user);
        }
        public void EditUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User");
            user.CreatedAt = DateTime.Now;
            if (user.Status == null)
                throw new ArgumentNullException("User Status cannot be Null !");
            if (user.Profile == null)
                throw new ArgumentNullException("User Profile cannot be Null !");
            userDAO.Set(user);
        }
        public void DeleteUser(int id)
        {
            userDAO.Delete(id);
        }
        public User GetUser(int id)
        {
            return userDAO.Get(id);
        }
        public User AuthenticateUser(string username, string password)
        {
            var user = userDAO.Login(username, password);
            if (user == null)
                throw new KeyNotFoundException("Username or password is incorrect");
            if (user.Status == false)
                throw new UnauthorizedAccessException("Your account is disabled !");
            return user;
        }
        public IEnumerable<User> FindUser(User user)
        {
            return userDAO.Find(user).OrderByDescending(X => X.CreatedAt).ToList();
        }
    }
}
