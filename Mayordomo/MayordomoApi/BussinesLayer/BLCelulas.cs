using MayordomoApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MayordomoApi.BussinesLayer
{
    public class BLCelulas
    {
        public async Task<Response<bool>> InsertCelula(CelulaVM c)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                using (var db = new MayordomoApi.Models.CandeleroEntities())
                {
                    var user = db.spInsCelulas(c.Nombre, c.Address, c.NombrePersona, c.Latitude, c.Longitude);
                    if (user == -1)
                    {

                        response.Result = true;
                        response.Message = "Se agrego correctamente";
                        response.Count = 1;
                    }
                    else
                    {
                        response.Result = false;
                        response.Message = "No se pudo agregar";
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
        public async Task<Response<bool>> UpdateCelula(CelulaVM c)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                using (var db = new MayordomoApi.Models.CandeleroEntities())
                {
                    var user = db.spUpdCelulas(c.IdCelula, c.Nombre, c.Address, c.NombrePersona, c.Latitude, c.Longitude);
                    if (user == -1)
                    {

                        response.Result = true;
                        response.Message = "Se actulizo correctamente";
                        response.Count = 1;
                    }
                    else
                    {
                        response.Result = false;
                        response.Message = "No se pudo actualizar";
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
        public async Task<Response<bool>> DeleteCelula(Guid IdCelula)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                using (var db = new MayordomoApi.Models.CandeleroEntities())
                {
                    var user = db.spDelCelulas(IdCelula);
                    if (user == -1)
                    {

                        response.Result = true;
                        response.Message = "Se elimino correctamente";
                        response.Count = 1;
                    }
                    else
                    {
                        response.Result = false;
                        response.Message = "No se pudo eliminar";
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
        public async Task<Response<List<CelulaVM>>> SelectCelula()
        {
            Response<List<CelulaVM>> response = new Response<List<CelulaVM>>();
            try
            {
                List<CelulaVM> list = new List<CelulaVM>();
                using (var db = new MayordomoApi.Models.CandeleroEntities())
                {
                    var query = db.spSelCelulas().ToList();
                    foreach(var item in query)
                    {
                        list.Add(new CelulaVM
                        {
                            IdCelula = item.IdCelula,
                            Address = item.Address,
                            Latitude = item.Latitude,
                            Longitude = item.Longitude,
                            Nombre = item.Nombre,
                            NombrePersona = item.NombrePersona,
                            Status = item.Status
                        });
                    }
                }
                response.Result = list;
                response.Count = list.Count;
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

        public async Task<Response<List<TypeMemberVM>>> SelectTypeMember()
        {
            Response<List<TypeMemberVM>> response = new Response<List<TypeMemberVM>>();
            try
            {
                List<TypeMemberVM> list = new List<TypeMemberVM>();
                using (var db = new MayordomoApi.Models.CandeleroEntities())
                {
                    var query = db.spSelTypeMember().ToList();
                    foreach (var item in query)
                    {
                        list.Add(new TypeMemberVM
                        {
                            IdMember = item.IdMember,
                            Name = item.Name,
                            Status = item.Status
                        });
                    }
                }
                response.Result = list;
                response.Count = list.Count;
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
    }
}