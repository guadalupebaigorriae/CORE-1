using Microsoft.AspNetCore.Mvc;
using Entidades;
namespace CORE_1.Controllers
{
    [ApiController]
    [Route("peluquero")]
    public class PeluquerosController : ControllerBase
    {
        [HttpGet]//Muestra
        [Route("get")]
        public ActionResult<object> GetAll()
        {
            try
            {
                return Ok(new { status = "true", result = Listas.ListaPeluquero });
            }
            catch (Exception ex)
            {
                List<Peluquero> list = new List<Peluquero>();
                return Ok(new { status = "false", result = list });
            }
            
        }
        //guada
        [HttpGet("getForId")]
        public ActionResult<object> GetForId([FromQuery]string nombre)
        {
            try
            {
                if(nombre != "")
                {
                    Peluquero pel= Listas.ListaPeluquero.Where(x => x.Nombre.ToUpper() == nombre.ToUpper()).SingleOrDefault();
                    
                    if(pel != null)
                    {
                        return Ok(new { status = true, resultado = pel });
                    }
                    else
                    {
                        return Ok(new { status = false });
                    }
                }
                else
                {
                    return Ok(new { status = false });
                }
                
            }
            catch (Exception)
            {
                return Ok(new { status = false });
            }
           
        }

        [HttpPost] //carga registros
        [Route("post")]
        public ActionResult<object> Post([FromBody] Peluquero peluquero)
        {
            try
            {
                Listas.ListaPeluquero.Add(peluquero);
                return Ok(new { status = true });
            }
            catch (Exception ex)
            {

                return Ok(new { status = false });
            }
        }
        [HttpPut]
        [Route("put")]
        public ActionResult<object> Put([FromQuery] Peluquero peluquero)
        {
            try
            {
                Listas.ListaPeluquero.Where(x => x.Nombre == peluquero.Nombre).SingleOrDefault().Apellido = peluquero.Apellido;
                Listas.ListaPeluquero.Where(x => x.Nombre == peluquero.Nombre).SingleOrDefault().Telefono = peluquero.Telefono;
                Listas.ListaPeluquero.Where(x => x.Nombre == peluquero.Nombre).SingleOrDefault().Actividad = peluquero.Actividad;

                return Ok(new { status = true });
            }
            catch (Exception)
            {

                return Ok(new { status = false });
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult<object> Delete([FromQuery] string nombre)
        {
            try
            {
                if (nombre != null)
                {
                    Peluquero peluquero = Listas.ListaPeluquero.Where(x => x.Nombre == nombre).FirstOrDefault();

                    if (peluquero != null)
                    {
                        Listas.ListaPeluquero.Remove(peluquero);
                        return Ok(new { status = true });
                    }
                    else
                    {
                        return Ok(new { status = false });
                    }
                }
                else
                {
                    return Ok(new { status = false });
                }
            }
            catch (Exception)
            {
                return Ok(new { status = false  });
            }

        }
    }
}
