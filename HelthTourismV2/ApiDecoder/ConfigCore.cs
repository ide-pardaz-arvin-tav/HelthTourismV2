using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HelthTourismV2.Models.Dto;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.ApiDecoder
{
    public class ConfigCore : ApiController
    {
        private HttpClient _httpClient;

        public ConfigCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ConfigCore"));
            _httpClient.BaseAddress = new Uri("#localhost#");
        }
        public async Task<TblConfig> AddConfig(TblConfig config)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ConfigCore/AddConfig", config);
            TblConfig ans = await httpResponseMessage.Content.ReadAsAsync<TblConfig>();
            return ans;
        }
        public async Task<bool> DeleteConfig(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DeleteConfig/DeleteConfig?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<bool> UpdateConfig(TblConfig config, int logId)
        {
            List<object> configAndLogId = new List<object>();
            configAndLogId.Add(config);
            configAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ConfigCore/UpdateConfig", configAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<List<DtoTblConfig>> SelectAllConfigs()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ConfigCore/SelectAllConfigs");
            List<DtoTblConfig> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblConfig>>();
            return ans;
        }
        public async Task<DtoTblConfig> SelectConfigById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ConfigCore/SelectConfigById?id={id}", id);
            DtoTblConfig ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblConfig>();
            return ans;
        }

    }
}