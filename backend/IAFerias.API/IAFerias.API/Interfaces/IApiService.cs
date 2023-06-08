using IAFerias.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace IAFerias.API.Interfaces
{
    public interface IApiService
    {
        void AuthenticationKey();
        StringContent CreateStringContent(Ferias ferias);
        Task<HttpResponseMessage> SendRequestAsync(StringContent content);
        Task<string> GetPromptAsync(HttpResponseMessage response);
    }
}
