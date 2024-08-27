using ShopifyAPI.Interfaces;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ShopifyAPI.Services
{
    public class WebhookAuthenticationService : IWebhookAuthenticationService
    {
        private readonly string webhookSecret;

        public WebhookAuthenticationService(IConfiguration configuration)
        {
            // Retrieve the webhook secret from configuration
            webhookSecret = configuration["Shopify:WebhookSecret"];
        }

        public WebhookAuthenticationService()
        {
        }

        //public bool IsRequestValid(string requestBody, string hmacHeader)
        //{
        //    // Compute HMAC hash of the request body using webhook secret
        //    byte[] secretBytes = Encoding.UTF8.GetBytes("e6962cdcf571d0de35fe04de1f08acc07024de30abe7e63443f3fd1220c97d51");
        //    requestBody = requestBody.Replace(" ", "");
        //    requestBody = Regex.Replace(requestBody, @"[\s\r\n]+", "");
        //    byte[] requestBodyBytes = Encoding.UTF8.GetBytes(requestBody);

        //    using (var hmac = new HMACSHA256(secretBytes))
        //    {
        //        byte[] hash = hmac.ComputeHash(requestBodyBytes);
        //        string computedHmac = Convert.ToBase64String(hash);

        //        // Compare computed HMAC with header HMAC
        //        return computedHmac.Equals(hmacHeader);
        //    }
        //}
        private readonly string CLIENT_SECRET = "e6962cdcf571d0de35fe04de1f08acc07024de30abe7e63443f3fd1220c97d51";
        public bool VerifyWebhook(string data, string hmacHeader)
        {
            using (var hasher = new HMACSHA256(Encoding.UTF8.GetBytes(CLIENT_SECRET)))
            {
                var computedHash = hasher.ComputeHash(Encoding.UTF8.GetBytes(data));
                var computedHashString = Convert.ToBase64String(computedHash);

                return hmacHeader.Equals(computedHashString, StringComparison.OrdinalIgnoreCase);
            }
        }

        // Compare the computed HMAC digest based on the client secret and the request contents to the reported HMAC in the headers
        //public bool VerifyWebhook(string data, string hmacHeader)
        //{
        //    byte[] keyBytes = Encoding.UTF8.GetBytes(CLIENT_SECRET);
        //    byte[] dataBytes = Encoding.UTF8.GetBytes(data);

        //    using (var hmac = new HMACSHA256(keyBytes))
        //    {
        //        byte[] hashBytes = hmac.ComputeHash(dataBytes);
        //        string calculatedHmac = Convert.ToBase64String(hashBytes);
        //        return string.Equals(calculatedHmac, hmacHeader);
        //    }
        //}

        // Respond to HTTP POST requests sent to this web service
        public void HandlePostRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            using (Stream body = request.InputStream)
            {
                using (StreamReader reader = new StreamReader(body, request.ContentEncoding))
                {
                    string data = reader.ReadToEnd();
                    string hmacHeader = request.Headers["X-Shopify-Hmac-Sha256"];

                    bool verified = VerifyWebhook(data, hmacHeader);

                    if (!verified)
                    {
                        response.StatusCode = 401;
                        response.Close();
                        return;
                    }

                    // Process webhook payload
                    // ...
                }
            }

        }
    }
}
