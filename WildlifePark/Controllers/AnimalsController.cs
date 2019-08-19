using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WildlifePark.Models;

namespace WildlifePark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private WildlifeParkContext _db = new WildlifeParkContext();

        // GET api/animals
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get()
        {
            return _db.Animals.ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Animal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
        }

        //GET api/animals/5
        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            return _db.Animals.FirstOrDefault(x=>x.AnimalId==id);
        }

        //Put api/animals/5
        [HttpPut ("{id}")]
        public void Put(int id, [FromBody] Animal animal)
        {
            animal.AnimalId = id;
            _db.Entry(animal).State= EntityState.Modified;
            _db.SaveChanges();
        }

        //Delete api/animals/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var animalToDelete = _db.Animals.FirstOrDefault(x=>x.AnimalId==id);
            _db.Animals.Remove(animalToDelete);
            _db.SaveChanges();
        }
    }
}