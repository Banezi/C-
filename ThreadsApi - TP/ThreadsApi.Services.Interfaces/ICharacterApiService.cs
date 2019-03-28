using System.Collections.Generic;
using System.Threading.Tasks;
using ThreadsApi.DTOs;

namespace ThreadsApi.Services.Interfaces
{
    public interface ICharacterApiService
    {
        Task<CharacterDTO> GetCharacter(int characterId);
        Task<List<CharacterDTO>> GetCharacters();
        Task<FullCharacterDTO> SaveCharacter(CharacterDTO characterDto);

        Task<string> GetCharacterName(int characterId);

        Task AddCharacterToGroup(int groupID, int characterId);
    }
}
