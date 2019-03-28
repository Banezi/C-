using System;
using ThreadsApi.DTOs;
using ThreadsApi.Services;
using ThreadsApi.ClientService;
using System.Collections.Generic;
using ThreadsApi.Services.Interfaces;
using System.Threading.Tasks;

namespace ThreadsApi
{
    class Program
    {
        //private static CharacterDTO[] characterFromApi = new CharacterDTO[5];

        static void Main(string[] args)
        {
            /// *************************************************
            /// APPELER LE WEBSERVICE ET AFFICHER LE RESULTAT ICI
            /// *************************************************
            ICharacterApiService service = new CharacterApiService();
            List<CharacterDTO> characterFromApi = new List<CharacterDTO>();
            var task = Task.Run(() => 
            {
                return service.GetCharacters();
            });
            task.Wait();
            var res = task.Result;
            Console.WriteLine("Name : " + res[0].Name + " Pv : " + res[0].Pv);
            //Console.Write($"Character Name { characterFromApi[0].Name } ");
            Console.ReadKey();
        }
    }
}
