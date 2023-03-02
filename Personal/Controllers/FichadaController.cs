using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Personal.Dominio;
using Personal.InterfazLogicaDominio;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Cors;

namespace Personal.mav.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class FichadaController : ControllerBase
    {
        private readonly ILogicaFichada logicaFichada;

        public FichadaController(ILogicaFichada logicaFichada)
        {
            this.logicaFichada = logicaFichada;
        }

        [HttpGet]
        public ActionResult Obtener()
        {
            List<Fichada> lista = new List<Fichada>();

            try
            {
                lista = this.logicaFichada.Obtener();
            }
            catch (Excepciones.ExcepcionTokenInexistente e)
            {
                return StatusCode(401, e.Message);
            }
            catch (Excepciones.ExcepcionErrorDeSintaxisSql e)
            {
                return StatusCode(500, e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, JsonConvert.SerializeObject(lista));
        }

        [HttpGet("persona")]
        public ActionResult Obtener(int persona_personaId, DateTime fichadaFH)
        {
            List<Fichada> listaFichadas = new List<Fichada>();

            try
            {
                listaFichadas = this.logicaFichada.ObtenerFichadas(persona_personaId, fichadaFH);
            }
            catch (Excepciones.ExcepcionTokenInexistente e)
            {
                return StatusCode(401, e.Message);
            }
            catch (Excepciones.ExcepcionErrorDeSintaxisSql e)
            {
                return StatusCode(500, e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, JsonConvert.SerializeObject(listaFichadas));
        }

        [HttpPost]
        public ActionResult Insertar(
            DateTime fichadaFH,
            string fichadaEstado,
            int persona_personaId)
        {
            Fichada fichada = new Fichada();            

            try
            {

                fichada = this.logicaFichada.Insertar(
                    fichadaFH,
                    fichadaEstado,
                    persona_personaId);
            }
            catch (Excepciones.ExcepcionTokenInexistente e)
            {
                return StatusCode(401, e.Message);
            }
            catch (Excepciones.ExcepcionErrorDeSintaxisSql e)
            {
                return StatusCode(500, e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, JsonConvert.SerializeObject(fichada));
        }
    }
}
