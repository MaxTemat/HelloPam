using HelloPam.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace HelloPam.DAL
{
    public class MDbConnection
    {
        /// <summary>
        /// proprite de connexion a une base de donnees
        /// </summary>
        protected readonly IDbConnection connection;
        /// <summary>
        /// creation d'un objet MDbconnection
        /// </summary>
        /// <param name="connection">represente un objet de connexion qui implemente l'interface IDbConnection</param>
        public MDbConnection(IDbConnection connection)
        {
            this.connection = connection;
        }
        /// <summary>
        /// permet d'ouvrir une connexion a une base de donnees
        /// </summary>
        /// <returns>true: si l'ouverture a reussi
        /// false: sinon
        /// </returns>
        public virtual bool Open()
        {
            try
            {
                this.connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// permet de fermer une connexion a une base de donnees
        /// </summary>
        /// <returns>true: si la fermeture a reussi
        /// false: sinon
        /// </returns>
        public virtual bool Close()
        {
            try
            {
                this.connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// permet de determiner si une connexion a la base de donnees est ouverte
        /// </summary>
        /// <returns>
        /// true: si la connexion est ouverte
        /// false: sinon
        /// </returns>
        public virtual bool IsOpened()
        {
            if (this.connection.State == ConnectionState.Open) return true;
            else return false;
        }
        /// <summary>
        /// permet d'effectuer une requete d'ecriture(insert, update, merge...) sur une base de donnees
        /// </summary>
        /// <param name="query">correspond a la requete a effectue</param>
        /// <param name="parameters">correspond aux differents parametres necessaire a l'execution de la requete</param>
        /// <param name="isStoredProcedure">specifie si la requete est une procedure ou non</param>
        /// <returns>
        /// retourne le nombre de lignes affectees par l'execution de la requete
        /// </returns>
        public virtual int Execute(string query, IEnumerable<IDataParameter> parameters = null, bool isStoredProcedure = false)
        {
            CommandType type = CommandType.Text;
            if (isStoredProcedure)
                type = CommandType.StoredProcedure;
            IDbCommand command = this.connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = type;
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }
            }
            return command.ExecuteNonQuery();
        }
        /// <summary>
        /// converti un IDataReader en <see cref="List{T}"/>
        /// </summary>
        /// <typeparam name="T">type d'objets contenus dans la liste</typeparam>
        /// <param name="reader">IDataReader qui sera conerti en <see cref="List{T}"/> </param>
        /// <returns></returns>
        protected List<User> ToList(IDataReader reader)
        {
            List<User> list = new List<User>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string username=reader.GetString(1);
                string password = reader.GetString(2);
                string fullname = reader.GetString(3);
                byte[] picture = (reader[4] == DBNull.Value ? null : (byte[])reader[4]);
                ProfileOptions profile = (ProfileOptions)reader.GetInt32(5);
                bool status = Convert.ToBoolean(reader.GetInt32(6));
                DateTime createdAt = reader.GetDateTime(7);
                User user = new User(id, username, password, fullname, picture, profile, status, createdAt);
                list.Add(user);
            }
            return list;
        }
        /// <summary>
        /// permet d'effectuer une requete de lecture(select) sur une base de donnees
        /// </summary>
        /// <param name="query">correspond a la requete a effectue</param>
        /// <param name="parameters">correspond aux differents parametres necessaire a l'execution de la requete</param>
        /// <param name="isStoredProcedure">specifie si la requete est une procedure ou non</param>
        /// <param name="behavior">fournit une description des resultats de la requete et ses effets sur la base de donnees</param>
        public virtual IDataReader Read(string query, IEnumerable<IDataParameter> parameters = null,
            bool isStoredProcedure = false, CommandBehavior behavior = CommandBehavior.Default)
        {
            CommandType type = CommandType.Text;
            if (isStoredProcedure)
                type = CommandType.StoredProcedure;
            IDbCommand command = this.connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = type;
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }
            }
            IDataReader reader = command.ExecuteReader(behavior);
            return reader;
        }
        /// <summary>
        /// permet d'obtenir le resultat d'une requete sous forme de liste d'objets
        /// </summary>
        /// <typeparam name="T">correspond a une classe ayant un constructeur sans parametres</typeparam>
        /// <param name="query">correspond a la requete a effectue</param>
        /// <param name="parameters">correspond aux differents parametres necessaire a l'execution de la requete</param>
        /// <param name="isStoredProcedure">specifie si la requete est une procedure ou non</param>
        /// <param name="behavior">fournit une description des resultats de la requete et ses effets sur la base de donnees</param>
        /// <returns>retourne une liste d'objets au type specifie</returns>
        public virtual List<User> Read<T>(string query, IEnumerable<IDataParameter> parameters = null,
            bool isStoredProcedure = false, CommandBehavior behavior = CommandBehavior.Default)
        {
            IDataReader reader = this.Read(query, parameters, isStoredProcedure, behavior);
            return this.ToList(reader);
        }
    }
}
