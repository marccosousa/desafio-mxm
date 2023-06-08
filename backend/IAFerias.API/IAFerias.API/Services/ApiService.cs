using AutoMapper;
using IAFerias.API.Interfaces;
using IAFerias.API.Models;
using IAFerias.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace IAFerias.API.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public ApiService(HttpClient httpClient, IMapper mapper, IConfiguration config)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _config = config;
        }
        public void AuthenticationKey()
        {
            var gptKey = _config.GetValue<string>("GptKey:ServiceApiKey");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", gptKey);
        }

        public StringContent CreateStringContent(Ferias ferias)
        {
            var model = new ChatGptRequest(ferias);
            var requestBody = JsonSerializer.Serialize(model);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            return content;
        }
        public async Task<HttpResponseMessage> SendRequestAsync(StringContent content)
        {
            return await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);
        }

        public async Task<string> GetPromptAsync(HttpResponseMessage response)
        {
            var result = await response.Content.ReadFromJsonAsync<ChatGptResponse>();
            var resultDTO = _mapper.Map<GptResponseDTO>(result);
            var prompt = resultDTO?.Choice?.Text;
            
            if (!string.IsNullOrEmpty(prompt))
            {
                return prompt;
            }
            return string.Empty;
        }

    }
}
