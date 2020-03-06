using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HelthTourismV2.Models.Dto;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.ApiDecoder
{
    public class SectionOperationRelCore : ApiController
    {
        private HttpClient _httpClient;

        public SectionOperationRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/SectionOperationRelCore"));
            _httpClient.BaseAddress = new Uri("#localhost#");
        }
        public async Task<TblSectionOperationRel> AddSectionOperationRel(TblSectionOperationRel sectionOperationRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/SectionOperationRelCore/AddSectionOperationRel", sectionOperationRel);
            TblSectionOperationRel ans = await httpResponseMessage.Content.ReadAsAsync<TblSectionOperationRel>();
            return ans;
        }
        public async Task<bool> DeleteSectionOperationRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DeleteSectionOperationRel/DeleteSectionOperationRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<bool> UpdateSectionOperationRel(TblSectionOperationRel sectionOperationRel, int logId)
        {
            List<object> sectionOperationRelAndLogId = new List<object>();
            sectionOperationRelAndLogId.Add(sectionOperationRel);
            sectionOperationRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/SectionOperationRelCore/UpdateSectionOperationRel", sectionOperationRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        public async Task<List<DtoTblSectionOperationRel>> SelectAllSectionOperationRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/SectionOperationRelCore/SelectAllSectionOperationRels");
            List<DtoTblSectionOperationRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblSectionOperationRel>>();
            return ans;
        }
        public async Task<TblSectionOperationRel> SelectSectionOperationRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/SectionOperationRelCore/SelectSectionOperationRelById?id={id}", id);
            TblSectionOperationRel ans = await httpResponseMessage.Content.ReadAsAsync<TblSectionOperationRel>();
            return ans;
        }
        public async Task<List<TblSectionOperationRel>> SelectSectionOperationRelBySectionId(int sectionId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/SectionOperationRelCore/SelectSectionOperationRelsBySectionId?sectionId={sectionId}", sectionId);
            List<TblSectionOperationRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<TblSectionOperationRel>>();
            return ans;
        }
        public async Task<List<TblSectionOperationRel>> SelectSectionOperationRelByOperationId(int operationId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/SectionOperationRelCore/SelectSectionOperationRelsByOperationId?operationId={operationId}", operationId);
            List<TblSectionOperationRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<TblSectionOperationRel>>();
            return ans;
        }

    }
}