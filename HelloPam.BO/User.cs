using System;

namespace HelloPam.BO
{
    public enum ProfileOptions
    {
        Admin,
        Visitor
    }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public byte[] Picture { get; set; }
        public ProfileOptions? Profile { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public User()
        {

        }

        public User(int id, string username, string password, string fullname,
            byte[] picture, ProfileOptions? profile, bool? status, DateTime createdAt)
        {
            Id = id;
            Username = username;
            Password = password;
            Fullname = fullname;
            Picture = picture;
            Profile = profile;
            Status = status;
            CreatedAt = createdAt;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id == user.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
