using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//importar
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ClientesController : ApiController
    {
        Negocios2017Entities1 bd = new Negocios2017Entities1();

        // GET: listado para clientes
        public IEnumerable<USP_LISTAR_CLIENTES_Result> Get()
        {
            //return bd.Database.SqlQuery<tb_clientes>("USP_LISTAR_CLIENTES");
            //return bd.tb_clientes.ToList();
            return bd.USP_LISTAR_CLIENTES();
        }

        public IEnumerable<USP_LISTAR_PAIS_Result> GetPaises()
        {
            //return bd.tb_paises.ToList();
            return bd.USP_LISTAR_PAIS();
        }

        // GET: obtener un cliente mediante su id
        public tb_clientes Get(string id)
        {
            return bd.tb_clientes.ToList().Where(c => c.IdCliente == id).FirstOrDefault();
        }

        // POST: agregaremos registro ala tabla tb_clientes
        public void Post(tb_clientes reg)
        {
            try
            {
                /*tb_clientes obj = new tb_clientes();
                obj.IdCliente = reg.IdCliente;
                obj.NombreCia = reg.NombreCia;
                obj.Direccion = reg.Direccion;
                obj.idpais    = reg.idpais;
                obj.Telefono  = reg.Telefono;
                //agrego los objetos ala tabla clientes
                bd.tb_clientes.Add(obj);
                bd.SaveChanges();*/

                bd.USP_CREAR_CLIENTES(reg.IdCliente,reg.NombreCia,reg.Direccion,reg.idpais,reg.Telefono);
                bd.SaveChanges();

            }
            catch(Exception e)
            {
                
            }
        }

        // PUT: actualizar el cliente
        public void Put(tb_clientes reg)
        {
            try
            {
                /*
                //capturo el stado
                bd.Entry(reg).State = System.Data.EntityState.Modified;
                //guardo los cambios
                bd.SaveChanges();*/

                bd.USP_ACTUALIZAR_CLIENTES(reg.IdCliente, reg.NombreCia, reg.Direccion, reg.idpais, reg.Telefono);
                bd.SaveChanges();
            }
            catch (Exception)
            {
                
            }
        }

        // DELETE: eliminar un registro de tb_clientes
        public void Delete(string id)
        {
            /*tb_clientes obj = Get(id);
            bd.tb_clientes.Remove(obj);
            bd.SaveChanges();*/

            bd.USP_ELIMINAR_CLIENTES(id);
            bd.SaveChanges();
        }

      

    }
}
