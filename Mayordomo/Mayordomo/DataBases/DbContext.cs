﻿using System;
using System.IO;
using Mayordomo.Models.Authenticate;
using Mayordomo.Models.User;
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
                connection.CreateTable<TokenResponse>();
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
                var query = connection.Table<UserModel>().FirstOrDefault();
                return query;
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

        #region Token
        public void InsertToken(TokenResponse token)
        {
            try
            {
                connection.DeleteAll<TokenResponse>();
                connection.Insert(token);
            }
            catch(Exception ex)
            {

            }
        }
        public TokenResponse GetToken()
        {
            try
            {
                var query = connection.Table<TokenResponse>().FirstOrDefault();
                return query;
            }
            catch(Exception ex)
            {
                return new TokenResponse();
            }
        }
        public void DeleteToken()
        {
            try
            {
                connection.DeleteAll<TokenResponse>();
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
