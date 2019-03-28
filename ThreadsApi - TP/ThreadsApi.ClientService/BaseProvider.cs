namespace Adecco.TheHunt.ClientService.Services
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using ThreadsApi.ClientService.Exceptions;

    /// <summary>
    /// 
    /// </summary>
    public class BaseProvider
    {
        /// <summary>
        /// URL of the BO
        /// </summary>
        protected string _baseUrl = "http://localhost:57718/api/Character";

        /// <summary>
        /// Call the URL for getting client
        /// </summary>
        /// <returns></returns>
        protected HttpClient GetClient()
        {
            return GetClient(_baseUrl);
        }

        /// <summary>
        /// Getting client object 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        protected virtual HttpClient GetClient(string baseUrl)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);

            return client;
        }

        /// <summary>
        /// Just a call to WS no data returned
        /// </summary>
        /// <param name="url">URL of BO</param>
        /// <returns></returns>
        protected async Task Get(string url)
        {
            // TODO Throw Custom Exception
            using (HttpClient client = GetClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                    {
                        var contentError = await response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<CustomApiError>(contentError);
                        
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                // TODO Catch custom exeptions
                // TODO Catch other exeptions
            }
        }

        /// <summary>
        /// Get datas // Calling the webservice
        /// </summary>
        /// <typeparam name="T">Type of datas to get</typeparam>
        /// <param name="url">URL of BO</param>
        /// <returns>Async task</returns>
        protected async Task<T> Get<T>(string url)
        {
            
            using (HttpClient client = GetClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                    {
                        var contentError = await response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<CustomApiError>(contentError);
                        var message = error != null ? error.Message : string.Empty;
                        throw new CustomApiException(message, response.StatusCode);
                    }

                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);
                }
                catch(CustomApiException e)
                {
                    Console.WriteLine(e.Message);
                    throw new CustomApiException(e.Message, e.StatusCode);
                }
                // TODO Catch custom exeptions
                // TODO Catch other exeptions
            }
            
        }
        
        /// <summary>
        /// Post data
        /// </summary>
        /// <typeparam name="T">Type of datas to get</typeparam>
        /// <param name="url">URL of BO</param>
        /// <param name="valuesToPost">Async task</param>
        /// <returns></returns>
        protected async Task<R> Post<T, R>(string url, T objToPost)
        {
            // TODO Throw Custom Exception
            using (HttpClient client = GetClient())
            {
                try
                {
                    string jsonObject = JsonConvert.SerializeObject(objToPost);
                    var httpContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, httpContent);
                    if (!response.IsSuccessStatusCode)
                    {
                        var contentError = await response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<CustomApiError>(contentError);
                        var message = error != null ? error.Message : string.Empty;
                    }
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<R>(content);
                }
                catch (CustomApiException e)
                {
                    Console.WriteLine(e.Message);
                    throw new CustomApiException(e.Message, e.StatusCode);
                }
                // TODO Catch custom exeptions
                // TODO Catch other exeptions
            }
        }

        /// <summary>
        /// Post data
        /// </summary>
        /// <typeparam name="T">Type of datas to get</typeparam>
        /// <param name="url">URL of BO</param>
        /// <param name="valuesToPost">Async task</param>
        /// <returns></returns>
        protected async Task Post(string url)
        {
            // TODO Throw Custom Exception
            using (HttpClient client = GetClient())
            {
                try
                {
                    string jsonObject = string.Empty;
                    var httpContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, httpContent);
                    if (!response.IsSuccessStatusCode)
                    {
                        var contentError = await response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<CustomApiError>(contentError);

                        var message = error != null ? error.Message : string.Empty;

                        throw new CustomApiException(message, response.StatusCode);
                    }
                    var content = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                // TODO Catch custom exeptions
                // TODO Catch other exeptions
            }
        }

        /// <summary>
        /// Put data
        /// </summary>
        /// <typeparam name="T">Type of datas to put</typeparam>
        /// <param name="url">URL of BO</param>
        /// <param name="valuesToPost">Async task</param>
        /// <returns></returns>
        protected async Task<R> Put<T, R>(string url, T objToPut)
        {
            // TODO Throw Custom Exception
            using (HttpClient client = GetClient())
            {
                
                try
                {
                    string jsonObject = JsonConvert.SerializeObject(objToPut);
                    var httpContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(url, httpContent);
                    if (!response.IsSuccessStatusCode)
                    {
                        var contentError = await response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<CustomApiError>(contentError);
                        var message = error != null ? error.Message : string.Empty;
                    }
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<R>(content);
                }
                catch (CustomApiException e)
                {
                    Console.WriteLine(e.Message);
                    throw new CustomApiException(e.Message, e.StatusCode);
                }
                // TODO Catch custom exeptions
                // TODO Catch other exeptions
            }
        }

        /// <summary>
        /// Put data
        /// </summary>
        /// <typeparam name="T">Type of datas to put</typeparam>
        /// <param name="url">URL of BO</param>
        /// <param name="valuesToPost">Async task</param>
        /// <returns></returns>
        protected async Task Put<T>(string url, T objToPut)
        {
            // TODO Throw Custom Exception
            using (HttpClient client = GetClient())
            {
                try
                {
                    string jsonObject = JsonConvert.SerializeObject(objToPut);
                    var httpContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(url, httpContent);
                    if (!response.IsSuccessStatusCode)
                    {
                        var contentError = await response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<CustomApiError>(contentError);

                        var message = error != null ? error.Message : string.Empty;
                        
                    }
                    var content = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                // TODO Catch custom exeptions
                // TODO Catch other exeptions
            }
        }
     
    }
}
