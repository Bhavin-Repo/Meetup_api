using MeetupApis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetupApis.Repository
{
    public interface IParticipantRepository
    {
        Task<IEnumerable<Participant>> GetParticipantsAsync();
        Task<Participant> GetParticipantAsync(int id);
        Task<Participant> AddParticipantAsync(Participant participant);
        Task<Participant> UpdateParticipantAsync(int id,Participant participant);
        Task<Participant> DeleteParticipantAsync(int id);
    }
}
