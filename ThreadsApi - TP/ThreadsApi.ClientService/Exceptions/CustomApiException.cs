using System;
using System.Net;

namespace ThreadsApi.ClientService.Exceptions
{
    public class CustomApiException : Exception
    {

        /// <summary>
        /// Get or set : Status code of error
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Get or set : Boolean for connexion
        /// </summary>
        public bool Connection { get; set; }

        /// <summary>
        /// Custom exception
        /// </summary>
        /// <param name="message">Error mesage</param>
        /// <param name="statusCode">Status code of error</param>
        public CustomApiException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
            Connection = true;
        }

        /// <summary>
        /// Custom exception
        /// </summary>
        /// <param name="message">Error mesage</param>
        /// <param name="connection">Status code of error</param>
        /// <param name="inner">Exception</param>
        public CustomApiException(string message, bool connection, Exception inner)
            : base(message, inner)
        {
            Connection = connection;
            StatusCode = HttpStatusCode.ServiceUnavailable;
        }
    }

    /// <summary>
    /// Error message
    /// </summary>
    public class CustomApiError
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }
    }
}
