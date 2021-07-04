using MeetupApis.Models;
using MeetupApis.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantRepository _repository;

        public ParticipantsController(IParticipantRepository participantRepository)
        {
            _repository = participantRepository;
        }

        // GET: api/Participants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants()
        {
            var participants = await _repository.GetParticipantsAsync();

            return participants.ToList();
        }

        // GET: api/Participants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipant(int id)
        {

            var participant = await _repository.GetParticipantAsync(id);

            if (participant == null)
            {
                return NotFound();
            }

            return participant;
        }

        // PUT: api/Participants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant(int id, Participant participant)
        {
            if (id != participant.Id)
            {
                return BadRequest();
            }
            try
            {
                var result = await _repository.UpdateParticipantAsync(id, participant);
                if(result == null)
                {
                    return NotFound("Something went wrong, please contact your system administator");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }

            return NoContent();
        }

        // POST: api/Participants
        [HttpPost]
        public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
        {

            try
            {
                await _repository.AddParticipantAsync(participant);

                return CreatedAtAction("GetParticipant", new { id = participant.Id }, participant);
            }
            catch (System.Exception ex)
            {
                return BadRequest("Something went wrong, please contact your system administator");
            }
        }

        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var participant = await _repository.DeleteParticipantAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
