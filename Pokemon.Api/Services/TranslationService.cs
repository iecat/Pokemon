using Newtonsoft.Json;
using Pokemon.Api.Interfaces;
using Pokemon.Api.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokemon.Api.Services
{
    public class TranslationService : ITranslate
    {
        private readonly IHttpClientFactory _clientFactory;
        public TranslationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> Translate(string stringToTranslate, TranslationType translationType)
        {
            var uriString = translationType == TranslationType.Yoda ?
                "https://api.funtranslations.com/translate/yoda"
                : "https://api.funtranslations.com/translate/shakespeare";

            HttpRequestMessage rerquest = new HttpRequestMessage(HttpMethod.Post, new Uri(uriString));

            var Parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("text", stringToTranslate),
                };

            rerquest.Content = new FormUrlEncodedContent(Parameters);

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(rerquest);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var translation = JsonConvert.DeserializeObject<TranslationJson>(responseString);
                return translation.Content.Translated;
            }
            return stringToTranslate;
        }

    }

    public enum TranslationType
    {
        Yoda = 0,
        Shakespeare = 1
    }
}
