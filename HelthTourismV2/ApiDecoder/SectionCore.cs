using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HelthTourismV2.Models.Dto;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.ApiDecoder
{
    public class SectionCore : ApiController
    {
        private HttpClient _httpClient;

        public SectionCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/SectionCore"));
            _httpClient.BaseAddress = new Uri("#localhost#");
        }
        public async Task<TblSection> AddSection(TblSection section)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/SectionCore/AddSection", section);
            TblSection ans = await httpResponseMessage.Content.ReadAsAsync<TblSection>();
            return ans;
        }

        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DeleteSection/DeleteSection?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }

        {
            List<object> sectionAndLogId = new List<object>();
            sectionAndLogId.Add(section);
            sectionAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/SectionCore/UpdateSection", sectionAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }

        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/SectionCore/SelectAllSections");
            List<DtoTblSection> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblSection>>();
            return ans;
        }

        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/SectionCore/SelectSectionById?id={id}", id);
            DtoTblSection ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblSection>();
            return ans;
        }

        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/SectionCore/SelectSectionBySectionName?sectionName={sectionName}", sectionName);
            DtoTblSection ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblSection>();
            return ans;
        }

        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/OperationCore/SelectOperationBySectionId?sectionId={sectionId}", sectionId);
            List<DtoTblOperation> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblOperation>>();
            return ans;
        }

    }
}