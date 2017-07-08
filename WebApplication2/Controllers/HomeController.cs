using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//importar
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        ClientesController bd = new ClientesController();
        //para la paginacion se requiere a Negocios2017Entities
        Negocios2017Entities1 negocios = new Negocios2017Entities1();
        public ActionResult Index(int? pag = null)
        {
            //recupero la cantidad de registro y almaceno el numero de registro
            int cliente = negocios.tb_clientes.Count();
            ViewBag.paginacion = cliente % paginacion != 0 ? cliente / paginacion + 1 : cliente / paginacion;

            //definimos la paginacion actual y el registro de inicio y registro final

            int pagPrincipal = pag == null ? 0 : (int)pag;
            int registroInicial = pagPrincipal * paginacion;
            int registroFinal = registroInicial + paginacion;

            //variable que almacenara los clientes para la paginacion

            List<tb_clientes> listaPag = new List<tb_clientes>();
            for (int i = registroInicial; i < registroFinal; i++)
            {
                if (i == cliente) break; // si i es igual a numero de registro saldra
                listaPag.Add(negocios.tb_clientes.ToList()[i]);
            }
            return View(listaPag);


            //return View(bd.Get());
        }

        public ActionResult Create()
        {
            ViewBag.paises = new SelectList(bd.GetPaises(),"idpais","nombrepais");
            return View(new tb_clientes());
        }

        [HttpPost] public ActionResult Create(tb_clientes reg)
        {
            //si es diferente al estado del modelo que es valido, le retornas los registros
            if (!ModelState.IsValid) { return View(reg); }
            //agregamos el registro a la tabla tb_clientes
            bd.Post(reg);
            //retornamos al index
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            tb_clientes reg = bd.Get(id);
            ViewBag.paises = new SelectList(bd.GetPaises(), "idpais", "nombrepais");
            return View(reg);
        }

        [HttpPost] public ActionResult Edit(tb_clientes reg)
        {
            if (!ModelState.IsValid) {
                ViewBag.paises = new SelectList(bd.GetPaises(), "idpais", "nombrepais");
                return View(reg);
            }
            //actualizamos el registro a la tabla tb_clientes
            bd.Put(reg);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            bd.Delete(id);
            return RedirectToAction("Index");
        }
        /*Páginacion*/
        int paginacion = 10;

        public ActionResult ListadoClientePaginacion(int? pag = null)
        {
            //recupero la cantidad de registro y almaceno el numero de registro
            int cliente = negocios.tb_clientes.Count();
            ViewBag.paginacion = cliente % paginacion!= 0 ? cliente / paginacion + 1 : cliente / paginacion;

            //definimos la paginacion actual y el registro de inicio y registro final

            int pagPrincipal = pag == null ? 0 : (int)pag;
            int registroInicial = pagPrincipal * paginacion;
            int registroFinal = registroInicial + paginacion;

            //variable que almacenara los clientes para la paginacion

            List<tb_clientes> listaPag = new List<tb_clientes>();
            for (int i = registroInicial; i < registroFinal; i++)
            {
                if (i == cliente) break; // si i es igual a numero de registro saldra
                listaPag.Add(negocios.tb_clientes.ToList()[i]);
            }
            return View(listaPag);
        }
    }
}
