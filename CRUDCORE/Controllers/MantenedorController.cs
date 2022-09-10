using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDCORE.Datos;
using CRUDCORE.Models;


namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            //La vista mostrara una lista de contactos.
            var oLista = _ContactoDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //Metodo solo devuelve la vista.
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //recibe el objeto para guardarlo en BD.
            if (!ModelState.IsValid)
                return View();
           
            var respuesta = _ContactoDatos.Guardar(oContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View(); 
           
        }
        public IActionResult Editar(int IdContacto)
        {
            //Metodo solo devuelve la vista.
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }
        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            //recibe el objeto para guardarlo en BD.
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContactoDatos.Editar(oContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Eliminar(int IdContacto)
        {
            //Metodo solo devuelve la vista.
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }
        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {
            //recibe el objeto para guardarlo en BD.

            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
