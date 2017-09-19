using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using api.eyeblaster.com.V1.DataContracts;
using api.eyeblaster.com.V2.DataContracts;
using api.eyeblaster.com.message;

namespace SizmekApiNet.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var authenticationServiceClient = new AuthenticationServiceClient();
            var authToken = authenticationServiceClient.ClientLogin(Environment.GetEnvironmentVariable("SIZMEK_USERNAME"), Environment.GetEnvironmentVariable("SIZMEK_PASSWORD"), Environment.GetEnvironmentVariable("SIZMEK_APP_KEY"));

            var advertiserService = new AdvertiserServiceClient();

            var paging = new ListPaging()
            {
                PageIndex = 0,
                PageSize = 99999
            };

            var advertisers = advertiserService.GetAdvertisers(null, paging, true);
            
            foreach (var advertiser in advertisers)
            {
                var campaignService = new CampaignServiceClient();

                var campaigns = campaignService.GetCampaigns(null, paging, true);

				foreach (var campaign in campaigns)
				{
					var conversionTagFilters = new List<ConversionTagsFilter>();

					conversionTagFilters.Add(new ConversionTagCampaignFilter()
					{
                        CampaignID = campaign.ID
					});

                    var conversionTags = advertiserService.GetConversionTags((uint)advertiser.ID, conversionTagFilters, paging, true);

					if (conversionTags.Count > 0)
					{
						var analyticsDataService = new AnalyticsDataServiceClient();
						var report = new PerformanceReport();

                        report.CampaignID = campaign.ID;
                        report.ReportStartDate = campaign.CampaignExtendedInfo.StartDate;
                        report.ReporEndtDate = campaign.CampaignExtendedInfo.EndDate;

                        analyticsDataService.InitiateReportJob(report);

                        var reportStatus = analyticsDataService.GetReportJobStatus(report);

                        while (reportStatus != JobStatus.Completed)
                            reportStatus = analyticsDataService.GetReportJobStatus(report);

                        var reportUrl = analyticsDataService.GetReportAsURL(report);
					}
				}
            }
        }
    }
}
