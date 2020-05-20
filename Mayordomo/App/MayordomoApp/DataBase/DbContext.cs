using System;
using MayordomoApp.Models.User;
using SQLite;
using Xamarin.Forms;

namespace MayordomoApp.DataBase
{
    public class DbContext
    {
        #region Singleton
        private static DbContext _instance = null;
        public static DbContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbContext();
                }
                return _instance;
            }
        }
        #endregion


        #region Constructor
        private readonly SQLiteConnection connection;
        public DbContext()
        {
            try
            {
                var dbPath = DependencyService.Get<IPathBase>().PathFile();
                connection = new SQLiteConnection(dbPath, true);
                connection.CreateTable<UserModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region User
        public void InsertUser(UserModel user)
        {
            try
            {
                connection.DeleteAll<UserModel>();
                connection.Insert(user);
            }
            catch (Exception ex)
            {

            }
        }
        public UserModel GetUser()
        {
            try
            {
                return connection.Table<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void DeleteUser()
        {
            try
            {
                connection.DeleteAll<UserModel>();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
}
