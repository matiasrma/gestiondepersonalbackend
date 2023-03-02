using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Personal.Dominio;
using Personal.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Personal.mav.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly ILogicaPersona logicaPersona;

        public PersonaController(ILogicaPersona logicaPersona)
        {
            this.logicaPersona  = logicaPersona;
        }

        [HttpGet]
        public ActionResult Obtener()
        {
            List<Persona> lista = new List<Persona>();
            try
            {
                lista = this.logicaPersona.Obtener();
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

        [HttpGet("{personaId:int}")]
        public ActionResult Obtener(int personaId)
        {
            Persona persona = new Persona();

            try
            {
                persona = this.logicaPersona.Obtener(personaId);
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

            return StatusCode(200, JsonConvert.SerializeObject(persona));
        }

        [HttpPost]
        public ActionResult Insertar(
            int personaLegajo,
            string personaNombre,
            string personaApellido
            )
        {
            Persona persona = new Persona();

            try
            {
                persona = this.logicaPersona.Insertar(
                    personaLegajo,
                    personaNombre,
                    personaApellido);
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

            return StatusCode(200, JsonConvert.SerializeObject(persona));
        }

        [HttpPut]
        public ActionResult Modificar(
            int personaId,
            int personaLegajo,
            string personaNombre,
            string personaApellido,
            string personaCuil,
            string personaEstado,
            string personaPuesto,
            string personaSector,
            DateTime personaFechaAlta,
            DateTime personaFechaNacimiento)
        {
            Persona persona = new Persona();

            try
            {
                persona = this.logicaPersona.Modificar(
                    personaId, 
                    personaLegajo,
                    personaNombre,
                    personaApellido,
                    personaCuil,
                    personaEstado,
                    personaPuesto,
                    personaSector,
                    personaFechaAlta,
                    personaFechaNacimiento);
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

            return StatusCode(200, JsonConvert.SerializeObject(persona));
        }

        [HttpDelete("{personaId:int}")]
        public ActionResult Eliminar(int personaId)
        {
            try
            {
                this.logicaPersona.Eliminar(personaId);
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

            return StatusCode(200);
        }

    }
}
