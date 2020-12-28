using System;
using SQLite;
using Xamarin.Forms;

namespace Mayordomo.DataBases
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
