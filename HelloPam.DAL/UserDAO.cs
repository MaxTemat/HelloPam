using HelloPam.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPam.DAL
{
    public class UserDAO
    {
        private MDbConnection connection;
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=HelloPam;Integrated Security=true;";
        public UserDAO()
        {
            this.connection = new MDbConnection(new SqlConnection(connectionString));
        }
        public void Add(User user)
        {
            try
            {
                this.connection.Open();
                this.connection.Execute("Sp_User_Insert", this.GetParameters(user), true);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void Set(User user)
        {
            try
            {
                this.connection.Open();
                this.connection.Execute("Sp_User_Update", this.GetParameters(user), true);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void Delete(int id)
        {
            try
            {
                this.connection.Open();
                this.connection.Execute("Sp_User_Delete", this.GetParameters(new User { Id = id }), true);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public User Get(int id)
        {
            try
            {
                this.connection.Open();
                return this.connection.Read<User>("Sp_User_Select", this.GetParameters(new User { Id = id }), true)[0];
            }
            finally
            {
                this.connection.Close();
            }
        }
        public User Login(string username, string password)
        {
            try
            {
                this.connection.Open();
                return this.connection.Read<User>("Sp_User_Login", this.GetParameters(new User { Username = username, Password = password }), true)[0];
            }
            finally
            {
                this.connection.Close();
            }
        }
        public IEnumerable<User> Find(User user)
        {
            try
            {
                this.connection.Open();
                return this.connection.Read<User>("Sp_User_Select", this.GetParameters(user), true);
                
            }
            finally
            {
                this.connection.Close();
            }
        }
        private IEnumerable<IDataParameter> GetParameters(User user)
        {
            this.connection.Open();
            DbProviderFactory factory = DbProviderFactories.GetFactory((DbConnection)new SqlConnection(connectionString));
            DbParameter p1 = factory.CreateParameter();
            DbParameter p2 = factory.CreateParameter();
            DbParameter p3 = factory.CreateParameter();
            DbParameter p4 = factory.CreateParameter();
            DbParameter p5 = factory.CreateParameter();
            DbParameter p6 = factory.CreateParameter();
            DbParameter p7 = factory.CreateParameter();
            DbParameter p8 = factory.CreateParameter();

            p1.ParameterName = "@Id";
            p1.DbType = DbType.Int32;
            p1.Value = (user == null || user.Id == 0 ? (object)DBNull.Value : user.Id);

            p2.ParameterName = "@Username";
            p2.DbType = DbType.String;
            p2.Value = (user == null || string.IsNullOrEmpty(user.Username) ? (object)DBNull.Value : user.Username);

            p3.ParameterName = "@Password";
            p3.DbType = DbType.String;
            p3.Value = (user == null || string.IsNullOrEmpty(user.Password) ? (object)DBNull.Value : user.Password);

            p4.ParameterName = "@Fullname";
            p4.DbType = DbType.String;
            p4.Value = (user == null || string.IsNullOrEmpty(user.Fullname) ? (object)DBNull.Value : user.Fullname);

            p5.ParameterName = "@Picture";
            p5.DbType = DbType.Binary;
            p5.Value = (user == null || user.Picture == null ? (object)DBNull.Value : user.Picture);

            p6.ParameterName = "@Profile";
            p6.DbType = DbType.Int32;
            p6.Value = (user == null || user.Profile == null ? (object)DBNull.Value : user.Profile);

            p7.ParameterName = "@Status";
            p7.DbType = DbType.Boolean;
            p7.Value = (user == null || user.Status == null ? (object)DBNull.Value : user.Status);

            p8.ParameterName = "@CreatedAt";
            p8.DbType = DbType.DateTime;
            p8.Value = user.CreatedAt;
            return new IDataParameter[] { p1, p2, p3, p4, p5, p6, p7, p8 };
        }
    }
}
