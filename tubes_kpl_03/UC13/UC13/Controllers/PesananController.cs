using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UC13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesananController : ControllerBase
    {
        private static List<Pesanan> pesanan = new List<Pesanan>
        {
            new Pesanan("001","Putri Auliya", new List<string>{"Bakso","Nasi Goreng"},"Confirmation Payment"),
            new Pesanan("002", "Auliya", new List<string>{"Nasi uduk"},"In Progress"),
            new Pesanan("003", "Rahmah", new List<string>{"Nasi kuning"}, "Order Done"),
            new Pesanan("004", "Auliya Rahmah", new List<string>{"Es teh"}, "Completed"),
            new Pesanan("005", "Putri Rahmah", new List<string>{"Kwetiaw Goreng"},"Confirmation Payment")
        };
        
        // GET: api/<PesananController>
        [HttpGet]
        public IEnumerable<Pesanan> Get()
        {
            return pesanan;
        }

        // GET api/<PesananController>/5
        [HttpGet("{id}")]
        public Pesanan Get(int id)
        {
            return pesanan[id];
        }

        // POST api/<PesananController>
        [HttpPost]
        public void Post([FromBody] Pesanan newPesanan)
        {
            pesanan.Add(newPesanan);
        }

        // PUT api/<PesananController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<PesananController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pesanan.RemoveAt(id);
        }
    }
}
