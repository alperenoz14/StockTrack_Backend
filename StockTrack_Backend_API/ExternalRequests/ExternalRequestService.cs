using Newtonsoft.Json;
using StockTrack_Backend_API.ExternalRequests.ExternalrequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockTrack_Backend_API.ExternalRequests
{
    public class ExternalRequestService
    {
        private readonly HttpClient _httpClient;
        public ExternalRequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<InjectionUnitNames>> getOrganizations()
        {
            var plants = new List<InjectionUnitNames>();

            var response = await _httpClient.GetAsync("https://seffaflik.epias.com.tr/transparency/service/production/dpp-organization");
            var units = new List<InjectionUnitNames>();
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var final = JsonConvert.DeserializeObject<OrganizationResponse>(result);

                foreach (var item in final.Body.Organizations)
                {
                    var res = await _httpClient.GetAsync($"https://seffaflik.epias.com.tr/transparency/service/production/dpp-injection-unit-name?organizationEIC={item.organizationETSOCode}");

                    if (res.IsSuccessStatusCode)
                    {
                        var resultdata = await res.Content.ReadAsStringAsync();
                        var finaldata = JsonConvert.DeserializeObject<dppInjectionUnitnameResponse>(resultdata);

                        foreach (var unit in finaldata.Body.injectionUnitNames)
                        {
                            unit.organizationETSOCode = item.organizationETSOCode;
                            plants.Add(unit);
                        }
                    }
                }

            }
            return plants;
        }
    }
}
