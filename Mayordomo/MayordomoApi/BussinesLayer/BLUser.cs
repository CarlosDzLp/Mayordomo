using MayordomoApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MayordomoApi.BussinesLayer
{
    public class BLUser
    {
        public async Task<Response<UserVM>> DoLogin(string email, string password)
        {
            Response<UserVM> response = new Response<UserVM>();
            try
            {
                using(var db = new MayordomoApi.Models.CandeleroEntities())
                {
                    var user = db.spSelLogin(email, password).FirstOrDefault();
                    if (user != null)
                    {
                        var us = new UserVM();
                        us.UserType = user.UserType;
                        us.Status = user.Status;
                        us.Photo = user.Photo;
                        us.Name = user.Name;
                        us.LastName = user.LastName;
                        us.IdUser = user.IdUser;
                        us.Email = user.Email;
                        us.Address = user.Address;
                        response.Result = us;
                        response.Message = string.Empty;
                        response.Count = 1;
                    }
                    else
                    {
                        response.Result = null;
                        response.Message = "No existe el usuario";
                        response.Count = 0;
                    }
                }
                return response;
            }
            catch(Exception ex)
            {
                response.Result = null;
                response.Message = ex.Message;
                response.Count = 0;
                return response;
            }
        }
        public async Task<Response<bool>>ValidateEmail(string email)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                using (var db = new MayordomoApi.Models.CandeleroEntities())
                {
                    var user = db.spSelValidateEmail(email).FirstOrDefault();
                    if (user != null)
                    {
                        response.Result = true;
                        response.Message = string.Empty;
                        response.Count = 1;
                    }
                    else
                    {
                        response.Result = false;
                        response.Message = "No existe el email";
                        response.Count = 0;
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                response.Count = 0;
                return response;
            }
        }
        public async Task<Response<List<UserVM>>> AllUser()
        {
            Response<List<UserVM>> response = new Response<List<UserVM>>();
            try
            {
                List<UserVM> list = new List<UserVM>();
                using (var db = new MayordomoApi.Models.CandeleroEntities())
                {
                    var user = db.spSelUser().ToList();
                    if (user != null)
                    {
                        foreach(var item in user)
                        {
                            var us = new UserVM();
                            us.UserType = item.UserType;
                            us.Status = item.Status;
                            us.Photo = item.Photo;
                            us.Name = item.Name;
                            us.LastName = item.LastName;
                            us.IdUser = item.IdUser;
                            us.Email = item.Email;
                            us.Address = item.Address;
                            list.Add(us);
                        }
                        response.Result = list;
                        response.Message = string.Empty;
                        response.Count = list.Count;
                    }
                    else
                    {
                        response.Result = list;
                        response.Message = "No hay usuarios";
                        response.Count = 0;
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Message = ex.Message;
                response.Count = 0;
                return response;
            }
        }
        public async Task<Response<bool>> ActivateAccountUser(Guid IdUser)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                using (var db = new MayordomoApi.Models.CandeleroEntities())
                {
                    var user = db.spActivateAccount(IdUser);
                    if (user == -1)
                    {
                        
                        response.Result = true;
                        response.Message = "Se activo correctamente";
                        response.Count = 1;
                    }
                    else
                    {
                        response.Result = false;
                        response.Message = "No se pudo activar";
                        response.Count = 0;
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                response.Count = 0;
                return response;
            }
        }
        public async Task<Response<bool>> DeleteAccount(Guid IdUser)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                using (var db = new MayordomoApi.Models.CandeleroEntities())
                {
                    var user = db.spDeleteAccount(IdUser);
                    if (user == -1)
                    {

                        response.Result = true;
                        response.Message = "Se elimino la cuenta correctamente";
                        response.Count = 1;
                    }
                    else
                    {
                        response.Result = false;
                        response.Message = "No se pudo eliminar la cuenta";
                        response.Count = 0;
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                response.Count = 0;
                return response;
            }
        }
        public async Task<Response<bool>> InsertUser(UserVM u)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                using (var db = new MayordomoApi.Models.CandeleroEntities())
                {
                    var user = db.spInsUser(u.Name, u.LastName, u.Address, u.Email, u.Password, u.Photo);
                    if (user == -1)
                    {

                        response.Result = true;
                        response.Message = "Se activo correctamente";
                        response.Count = 1;
                    }
                    else
                    {
                        response.Result = false;
                        response.Message = "No se pudo activar";
                        response.Count = 0;
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                response.Count = 0;
                return response;
            }
        }
    }
}