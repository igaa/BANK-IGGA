using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BANK_IGGA.Models; 

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BANK_IGGA.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class NasabahController : ControllerBase
    {
        private List<NasabahModels> dt = new List<NasabahModels> {
            new NasabahModels
            {
                id = 1,
                nama_lengkap = "Igga Fauzi  Rahman",
                alamat = "desa pancur rt 05 rw 01 jepara jawa tengah",
                tempat_lahir = "Indragiri Hilir",
                tanggal_lahir = DateTime.Now,
                no_ktp = "937927376327372287",
                nohp = "085155449709"

            }
        }; 
        // GET: api/<NasabahController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NasabahModels>>> Get()
        { 
            return await Task.FromResult(Ok(dt)); 

        }

        // GET api/<NasabahController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<NasabahModels>>> Get(string noktp)
        {
            List<NasabahModels> dto = new List<NasabahModels>(); 
            if (noktp != null)
            {
                dto  = dt.Where(s => s.no_ktp == noktp).ToList();
            }else
            {
                dto = dt; 
            }

            return await Task.FromResult(dto); 
            
        }

        // POST api/<NasabahController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<NasabahModels>>> Post(NasabahModels param)
        {
            dt.Add(param); 
            return await Task.FromResult(Ok(dt)); 
        }

        // PUT api/<NasabahController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<NasabahModels>>> Put(NasabahModels param)
        {
            var get_by_id = dt.Where(s => s.id == param.id).ToList();
            
            if (get_by_id.Count > 0)
            {
                for (int x =0; x < get_by_id.Count; x++)
                {
                    get_by_id[x].nama_lengkap = param.nama_lengkap;
                    get_by_id[x].alamat = param.alamat;
                    get_by_id[x].tempat_lahir = param.tempat_lahir;
                    get_by_id[x].tanggal_lahir = param.tanggal_lahir;
                    get_by_id[x].no_ktp = param.no_ktp;
                    get_by_id[x].nohp = param.nohp; 
                }

            }

            return await Task.FromResult(Ok(dt)); 
        }
       

        // DELETE api/<NasabahController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<NasabahModels>>> Delete(int id)
        {
            NasabahModels dto = new NasabahModels(); 
            var get_by_id = dt.Where(s => s.id == id).ToList();
            if (id.ToString().Length > 0 )
            {
                if (get_by_id.Count > 0) { 
                    for (int x = 0; x < get_by_id.Count; x++)
                    {
                        dto.id = get_by_id[x].id; 
                        dto.nama_lengkap = get_by_id[x].nama_lengkap;
                        dto.alamat = get_by_id[x].alamat;
                        dto.tempat_lahir = get_by_id[x].tempat_lahir;
                        dto.tanggal_lahir = get_by_id[x].tanggal_lahir;
                        dto.no_ktp = get_by_id[x].no_ktp;
                        dto.nohp = get_by_id[x].nohp;

                        dt.Remove(dto); 

                    }
                }
            }

            return await Task.FromResult(Ok(dt)); 
            
        }
    }
}
