using Microsoft.AspNetCore.Mvc;
using Entidades;

namespace CORE_1.Controllers
{
    [ApiController]
    [Route("turnos")]
    public class TurnosController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public ActionResult<object> Get()
        {
            try
            {
                return Ok(new { status = true, response = Listas.ListaTurnos });
            }
            catch (Exception)
            {

                return Ok(new { status = false });
            }

        }

        [HttpGet]
        [Route("getForId")]
        public ActionResult<object> GetForId(int id)
        {
            try
            {
                Turnos turno = Listas.ListaTurnos.Where(x => x.Id == id).SingleOrDefault();
                if (turno != null)
                {
                    return Ok(new { status = true, response = turno });
                }
                else
                {
                    return Ok(new { status = false, message = "No hay datos coincidentes" });
                }

            }
            catch (Exception)
            {

                return Ok(new { status = false });
            }
        }

        [HttpPost("post")]
        public ActionResult<object> Post(Turnos turno)
        {
            try
            {
                if (turno == null)
                {
                    if (turno.Id != 0)
                    {
                        Listas.ListaTurnos.Add(turno);
                        return Ok(new { status = true });
                    }
                    else
                    {
                        return Ok(new { status = false, message = "Id incorrecto" });
                    }
                }
                else
                {
                    return Ok(new { status = false, message = "Complete el turno" });
                }

            }
            catch (Exception)
            {

                return Ok(new { status = false, message = "Error, contacte con Sistemas." });
            }
        }

        [HttpPut("put")]
        public ActionResult<object> Put(Turnos turno)
        {
            try
            {
                Listas.ListaTurnos.Where(x => x.Id == turno.Id).SingleOrDefault().NombreDeCliente = turno.NombreDeCliente;
                Listas.ListaTurnos.Where(x => x.Id == turno.Id).SingleOrDefault().FechaYhora = turno.FechaYhora;

                return Ok(new { status = true });
            }
            catch (Exception)
            {

                return Ok(new { status = false });
            }
            
        }

        [HttpDelete("delete")]
        public ActionResult Delete(Turnos turno)
        {
            try
            {
                Listas.ListaTurnos.Remove(turno);
                return Ok(new { status = true });
            }
            catch (Exception)
            {

               return Ok( new { status= false });
            }
            
        }


    }
}
