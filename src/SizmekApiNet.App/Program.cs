using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SizmekApiNet.App.AdvertiserService;
using SizmekApiNet.App.AuthenticationService;
using SizmekApiNet.App.AnalyticsDataService;

namespace SizmekApiNet.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var authenticationServiceClient = new AuthenticationServiceClient();
            var authToken = authenticationServiceClient.ClientLogin("", "", "");

            var advertiserService = new AdvertiserServiceClient();

            var paging = new ListPaging()
            {
                PageIndex = 0,
                PageSize = 99999
            };

            var totalCount = 0;

            var advertisers = advertiserService.GetAdvertisers(authToken, null, paging, true, out totalCount);
            
            if (totalCount > 0)
            {
                var conversionTags = advertiserService.GetConversionTags(authToken, (uint) advertisers[0].ID, null, paging, true, out totalCount);

                if (totalCount > 0)
                {
                    var analyticsDataService = new AnalyticsDataServiceClient();

                    var conversionTagsFiltered = conversionTags.ToList()
                                                .Where(o => o.ReportingName == "")
                                                .ToList();
                }
            }
        }
    }
}
