using MeetupApis.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupApis.Repository
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly APIDBContext _context;

        public ParticipantRepository(APIDBContext context)
        {
            this._context = context;
        }
        public async Task<Participant> AddParticipantAsync(Participant participant)
        {
            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();
            return participant;
        }

        public async Task<Participant> DeleteParticipantAsync(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return null;
            }
            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();
            return participant;
        }

        public async Task<Participant> GetParticipantAsync(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            return participant;
        }

        public async Task<IEnumerable<Participant>> GetParticipantsAsync()
        {
            return await _context.Participants.ToListAsync();
        }

        public async Task<Participant> UpdateParticipantAsync(int id,Participant participant)
        {
            _context.Entry(participant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return participant;

        }

        private bool ParticipantExists(int id)
        {
            return _context.Participants.Any(e => e.Id == id);
        }
    }
}
