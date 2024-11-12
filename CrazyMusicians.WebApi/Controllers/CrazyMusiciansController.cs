using Microsoft.AspNetCore.Mvc;
using CrazyMusicians.Models;

namespace CrazyMusicians.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrazyMusiciansController : ControllerBase
    {
        private static List<Musician> _musicians = new List<Musician>
        {
            new Musician { Id = 1, Name = "Ahmet Çalgi", Profession = "Instrumentalist", FunFact = "Always plays the wrong note but is very fun" },
            new Musician { Id = 2, Name = "Zeynep Melodi", Profession = "Popular Melody Writer", FunFact = "Songs are misunderstood but very popular" },
            new Musician { Id = 3, Name = "Cemil Akor", Profession = "Crazy Chordist", FunFact = "Changes chords frequently but is surprisingly talented" },
            new Musician { Id = 4, Name = "Fatma Nota", Profession = "Surprise Note Producer", FunFact = "Always prepares surprises while creating notes" },
            new Musician { Id = 5, Name = "Hasan Ritim", Profession = "Rhythm Beast", FunFact = "Creates every rhythm in his own style, never matches but is funny" },
            new Musician { Id = 6, Name = "Elif Armoni", Profession = "Harmony Master", FunFact = "Sometimes plays her harmonies wrong but is very creative" },
            new Musician { Id = 7, Name = "Ali Perde", Profession = "Scale Player", FunFact = "Plays every scale differently, always surprising" },
            new Musician { Id = 8, Name = "Ayse Rezonans", Profession = "Resonance Expert", FunFact = "Expert in resonance but sometimes makes a lot of noise" },
            new Musician { Id = 9, Name = "Murat Ton", Profession = "Tone Enthusiast", FunFact = "Tone variations are sometimes funny but very interesting" },
            new Musician { Id = 10, Name = "Selin Akor", Profession = "Chord Magician", FunFact = "Creates a magical atmosphere when changing chords" }
        };

        // GET: api/CrazyMusicians
        [HttpGet]
        public ActionResult<IEnumerable<Musician>> GetAll()
        {
            return Ok(_musicians);
        }

        // GET: api/CrazyMusicians/{id}
        [HttpGet("{id}")]
        public ActionResult<Musician> GetById(int id)
        {
            var musician = _musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
                return NotFound("Musician not found");
            return Ok(musician);
        }

        // GET: api/CrazyMusicians/search?name=Ahmet
        [HttpGet("search")]
        public ActionResult<IEnumerable<Musician>> SearchByName([FromQuery] string name)
        {
            var result = _musicians.Where(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!result.Any())
                return NotFound("No _musicians found");
            return Ok(result);
        }

        // POST: api/CrazyMusicians
        [HttpPost]
        public ActionResult<Musician> CreateMusician([FromBody] Musician newMusician)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            newMusician.Id = _musicians.Max(m => m.Id) + 1;
            _musicians.Add(newMusician);
            return CreatedAtAction(nameof(GetById), new { id = newMusician.Id }, newMusician);
        }
        
        // PUT: api/CrazyMusicians/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMusician(int id, [FromBody] Musician updatedMusician)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var musician = _musicians.FirstOrDefault(m => m.Id == id);
            
            if (musician == null)
                return NotFound("Musician not found");

            musician.Name = updatedMusician.Name;
            musician.Profession = updatedMusician.Profession;
            musician.FunFact = updatedMusician.FunFact;
            return NoContent();
        }

        // PATCH: api/CrazyMusicians/{id}
        [HttpPatch("{id}")]
        public IActionResult PatchMusician(int id, [FromBody] string newFunFact)
        {
            var musician = _musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
                return NotFound("Musician not found");

            musician.FunFact = newFunFact;
            return NoContent();
        }

        // DELETE: api/CrazyMusicians/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMusician(int id)
        {
            var musician = _musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
                return NotFound("Musician not found");

            _musicians.Remove(musician);
            return NoContent();
        }
    }
}