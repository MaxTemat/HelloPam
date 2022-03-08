using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HelloPam.WebApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public string Profile { get; set; }
        public string Picture { get; set; }
        public IEnumerable<SelectListItem> Profiles { get; set; }
        public UserModel()
        {

        }

        public UserModel(int id, string username, string fullname, string password, 
            string confirmPassword, DateTime createdAt, string status, string profile, string picture)
        {
            Id = id;
            Username = username;
            Fullname = fullname;
            Password = password;
            ConfirmPassword = confirmPassword;
            CreatedAt = createdAt;
            Status = status;
            Profile = profile;
            Picture = picture;
        }

        public UserModel(int id, string username, string fullname, string password, string confirmPassword,
            DateTime createdAt, string status, string profile, string picture,
            IEnumerable<SelectListItem> profiles) : this(id, username, fullname, password, confirmPassword, createdAt, status, profile, picture)
        {
            Profiles = profiles;
        }
    }
}