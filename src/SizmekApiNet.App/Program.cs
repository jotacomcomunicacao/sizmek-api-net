using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SizmekApiNet.App.AuthenticationService;
using SizmekApiNet.App.AdvertiserService;
using SizmekApiNet.App.AnalyticsDataService;
using SizmekApiNet.App.CampaignService;

namespace SizmekApiNet.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var authenticationServiceClient = new AuthenticationServiceClient();
            var authToken = authenticationServiceClient.ClientLogin(Environment.GetEnvironmentVariable("SIZMEK_USERNAME"), Environment.GetEnvironmentVariable("SIZMEK_PASSWORD"), Environment.GetEnvironmentVariable("SIZMEK_APP_KEY"));

            var advertiserService = new AdvertiserServiceClient();

            var paging = new AdvertiserService.ListPaging()
            {
                PageIndex = 0,
                PageSize = 99999
            };

            var paging2 = new CampaignService.ListPaging()
            {
                PageIndex = 0,
                PageSize = 99999
            };

            var totalCount = 0;

            var advertisers = advertiserService.GetAdvertisers(authToken, null, paging, true, out totalCount);
            
            foreach (var advertiser in advertisers)
            {
                var campaignService = new CampaignServiceClient();

                var campaigns = campaignService.GetCampaigns(authToken, null, paging2, true, out totalCount);

				foreach (var campaign in campaigns)
				{
					var conversionTagFilters = new List<ConversionTagsFilter>();

					conversionTagFilters.Add(new ConversionTagCampaignFilter()
					{
                        CampaignID = campaign.ID
					});

                    var conversionTags = advertiserService.GetConversionTags(authToken, (uint)advertiser.ID, conversionTagFilters, paging, true, out totalCount);

					if (conversionTags.Count > 0)
					{
						var analyticsDataService = new AnalyticsDataServiceClient();
						var report = new PerformanceReport();
                        var reportBase = new ReportBase();

                        report.CampaignID = campaign.ID;

                        report.ReportStartDate = new AnalyticsDataService.APIDateTime();
                        report.ReportStartDate.Day = campaign.CampaignExtendedInfo.StartDate.Day;
                        report.ReportStartDate.Month = campaign.CampaignExtendedInfo.StartDate.Month;
                        report.ReportStartDate.Year = campaign.CampaignExtendedInfo.StartDate.Year;

                        report.ReporEndtDate = new AnalyticsDataService.APIDateTime();
                        report.ReporEndtDate.Day = campaign.CampaignExtendedInfo.EndDate.Day;
                        report.ReporEndtDate.Month = campaign.CampaignExtendedInfo.EndDate.Month;
                        report.ReporEndtDate.Year = campaign.CampaignExtendedInfo.EndDate.Year;

                        reportBase = report;

                        analyticsDataService.InitiateReportJob(authToken, ref reportBase);

                        var reportStatus = analyticsDataService.GetReportJobStatus(authToken, report);

                        while (reportStatus != JobStatus.Completed)
                            reportStatus = analyticsDataService.GetReportJobStatus(authToken, report);

                        var reportUrl = analyticsDataService.GetReportAsURL(authToken, report);
					}
				}
            }
        }
    }
}
