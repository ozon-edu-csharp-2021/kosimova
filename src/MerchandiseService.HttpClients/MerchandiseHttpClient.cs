using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MerchandiseService.HttpClients
{
    public interface IMerchandiseHttpClient
    {
        Task<CreateMerchResponse> Create(CreateMerchRequest request, CancellationToken token);
        Task<GetMerchHistoryResponse> GetByEmployeeId(GetMerchHistoryRequest request, CancellationToken token);
    }

    public class MerchandiseHttpClient : IMerchandiseHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchandiseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CreateMerchResponse> Create(CreateMerchRequest request, CancellationToken token)
        {
            var json = JsonConvert.SerializeObject(request);
            var requestString = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("v1/api/merch/create", requestString, token);
            var result = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<CreateMerchResponse>(result);
        }

        public async Task<GetMerchHistoryResponse> GetByEmployeeId(GetMerchHistoryRequest request, CancellationToken token)
        {
            var response = await _httpClient.GetAsync($"v1/api/merch/getEmployeeHistory?EmployeeId={request.EmployeeId}", token);
            var result = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<GetMerchHistoryResponse>(result);
        }
    }
}