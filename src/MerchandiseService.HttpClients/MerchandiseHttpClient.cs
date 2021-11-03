using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpClients.Models;
using Newtonsoft.Json;
using RestEase;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MerchandiseService.HttpClients
{
    public interface IMerchandiseHttpClient
    {
        Task<CreateMerchResponse> CreateAsync(CreateMerchRequest request, CancellationToken token);
        Task<GetMerchHistoryResponse> GetByEmployeeIdAsync(GetMerchHistoryRequest request, CancellationToken token);
    }

    public class MerchandiseHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMerchandiseHttpClient _merchandiseHttpClient;

        public MerchandiseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _merchandiseHttpClient = RestClient.For<IMerchandiseHttpClient>("http://localhost:5001");
        }

        public async Task<CreateMerchResponse> Create(CreateMerchRequest request, CancellationToken token)
        {
            return await _merchandiseHttpClient.CreateAsync(request, token);
        }

        public async Task<GetMerchHistoryResponse> GetByEmployeeId(GetMerchHistoryRequest request, CancellationToken token)
        {
            return await _merchandiseHttpClient.GetByEmployeeIdAsync(request, token);
        }
    }
}