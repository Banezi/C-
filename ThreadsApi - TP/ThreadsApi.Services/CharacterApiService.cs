using Adecco.TheHunt.ClientService.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThreadsApi.DTOs;
using ThreadsApi.Services.Interfaces;

namespace ThreadsApi.Services
{
    public class CharacterApiService : BaseProvider, ICharacterApiService
    {
        private const string CONTROLLER_NAME = "/api/Character";

        public CharacterApiService()
        {
        }

        public async Task<CharacterDTO> GetCharacter(int characterId)
        {
            string requestURI = $"{CONTROLLER_NAME}/GetCurrentUserPicture/";

            return  await Get<CharacterDTO>(requestURI);
        }
        //Recuperation de tous les charactères
        public async Task<List<CharacterDTO>> GetCharacters()
        {
            string requestURI = $"{CONTROLLER_NAME}/";

            return await Get<List<CharacterDTO>>(requestURI);
        }

        public async Task<FullCharacterDTO> SaveCharacter(CharacterDTO characterDto)
        {
            string requestURI = $"{CONTROLLER_NAME}/SaveCharacter/";

            return await Post<CharacterDTO, FullCharacterDTO>(requestURI, characterDto);
        }

        public async Task<string> GetCharacterName(int characterId)
        {
            string requestURI = $"{CONTROLLER_NAME}/GetCharacterId?characterId={characterId}";
            var result = await Get<string>(requestURI);
            return result;
        }

        public async Task AddCharacterToGroup(int groupID, int characterId)
        {
            string requestURI = $"{CONTROLLER_NAME}/SaveUserLink/?groupID={groupID}&characterID={characterId}";

            await Post(requestURI);
        }

        Task<CharacterDTO> ICharacterApiService.GetCharacter(int characterId)
        {
            throw new System.NotImplementedException();
            /*
            ask<CharacterDTO> c = new Task<CharacterDTO>;
            return c;
            */
        }

        Task<FullCharacterDTO> ICharacterApiService.SaveCharacter(CharacterDTO characterDto)
        {
            throw new System.NotImplementedException();
        }

        Task<string> ICharacterApiService.GetCharacterName(int characterId)
        {
            throw new System.NotImplementedException();
        }

        Task ICharacterApiService.AddCharacterToGroup(int groupID, int characterId)
        {
            throw new System.NotImplementedException();
        }
    }
}
