using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2
{
    public class TimezoneData
    {
        /// <summary>
        /// Gets or sets Timezones.
        /// </summary>
        [JsonProperty("timezones")]
        public Timezones[] Timezones { get; set; }
    }
    public class Timezones
    {
        /// <summary>
        /// Gets or sets timeZoneCode.
        /// </summary>
        [JsonProperty("zone")]
        public string TimeZoneCode { get; set; }

        /// <summary>
        /// Gets or sets TimeZoneOffset.
        /// </summary>
        [JsonProperty("offset")]
        public string TimeZoneOffset { get; set; }
    }
    class Program
    {

        /// <summary>
        /// GetTime ZoneData.
        /// </summary>
        /// <returns>time zones.</returns>
        private static string GetTimeZoneData()
        {
            string timezoneString = @"{'timezones':[{'zone':'DST','offset':'-12'},{'zone':'U','offset':'-11'},{'zone':'HST','offset':'-10'},{'zone':'AKDT','offset':'-8'},{'zone':'PDT','offset':'-7'},{'zone':'PST','offset':'-8'},{'zone':'UMST','offset':'-7'},{'zone':'MDT','offset':'-6'},{'zone':'MDT','offset':'-6'},{'zone':'CAST','offset':'-6'},{'zone':'CDT','offset':'-5'},{'zone':'CDT','offset':'-5'},{'zone':'CCST','offset':'-6'},{'zone':'SPST','offset':'-5'},{'zone':'EDT','offset':'-4'},{'zone':'UEDT','offset':'-4'},{'zone':'VST','offset':'-4.30'},{'zone':'PYT','offset':'-4'},{'zone':'ADT','offset':'-3'},{'zone':'CBST','offset':'-4'},{'zone':'SWST','offset':'-4'},{'zone':'PSST','offset':'-4'},{'zone':'NDT','offset':'-2.30'},{'zone':'ESAST','offset':'-3'},{'zone':'AST','offset':'-3'},{'zone':'SEST','offset':'-3'},{'zone':'GDT','offset':'-3'},{'zone':'MST','offset':'-3'},{'zone':'BST','offset':'-3'},{'zone':'U','offset':'-2'},{'zone':'MDT','offset':'-1'},{'zone':'ADT','offset':'0'},{'zone':'CVST','offset':'-1'},{'zone':'MDT','offset':'1'},{'zone':'UTC','offset':'0'},{'zone':'GMT','offset':'0'},{'zone':'BST','offset':'1'},{'zone':'GDT','offset':'1'},{'zone':'GST','offset':'0'},{'zone':'WEDT','offset':'2'},{'zone':'CEDT','offset':'2'},{'zone':'RDT','offset':'2'},{'zone':'CEDT','offset':'2'},{'zone':'WCAST','offset':'1'},{'zone':'NST','offset':'1'},{'zone':'GDT','offset':'3'},{'zone':'MEDT','offset':'3'},{'zone':'EST','offset':'2'},{'zone':'SDT','offset':'3'},{'zone':'EEDT','offset':'3'},{'zone':'SAST','offset':'2'},{'zone':'FDT','offset':'3'},{'zone':'TDT','offset':'3'},{'zone':'JDT','offset':'3'},{'zone':'LST','offset':'2'},{'zone':'JST','offset':'3'},{'zone':'AST','offset':'3'},{'zone':'KST','offset':'3'},{'zone':'AST','offset':'3'},{'zone':'EAST','offset':'3'},{'zone':'MSK','offset':'3'},{'zone':'SAMT','offset':'4'},{'zone':'IDT','offset':'4.30'},{'zone':'AST','offset':'4'},{'zone':'ADT','offset':'5'},{'zone':'MST','offset':'4'},{'zone':'GET','offset':'4'},{'zone':'CST','offset':'4'},{'zone':'AST','offset':'4.30'},{'zone':'WAST','offset':'5'},{'zone':'YEKT','offset':'5'},{'zone':'PKT','offset':'5'},{'zone':'IST','offset':'5.30'},{'zone':'SLST','offset':'5.30'},{'zone':'NST','offset':'5.45'},{'zone':'CAST','offset':'6'},{'zone':'BST','offset':'6'},{'zone':'MST','offset':'6.30'},{'zone':'SAST','offset':'7'},{'zone':'NCAST','offset':'7'},{'zone':'CST','offset':'8'},{'zone':'NAST','offset':'8'},{'zone':'MPST','offset':'8'},{'zone':'WAST','offset':'8'},{'zone':'TST','offset':'8'},{'zone':'UST','offset':'8'},{'zone':'NAEST','offset':'8'},{'zone':'JST','offset':'9'},{'zone':'KST','offset':'9'},{'zone':'CAST','offset':'9.30'},{'zone':'ACST','offset':'9.30'},{'zone':'EAST','offset':'10'},{'zone':'AEST','offset':'10'},{'zone':'WPST','offset':'10'},{'zone':'TST','offset':'10'},{'zone':'YST','offset':'9'},{'zone':'CPST','offset':'11'},{'zone':'VST','offset':'11'},{'zone':'NZST','offset':'12'},{'zone':'U','offset':'12'},{'zone':'FST','offset':'12'},{'zone':'MST','offset':'12'},{'zone':'KDT','offset':'13'},{'zone':'TST','offset':'13'},{'zone':'SST','offset':'13'}]}";
            return timezoneString;
        }

        public class Scrum
        {
            /// <summary>
            /// Gets or sets the conversation ID of the team chat that started the scrum.
            /// </summary>
            [JsonProperty("ThreadConversationId")]
            public string ThreadConversationId { get; set; }

            /// <summary>
            /// Gets or sets the ScrumStartActivityId of the root scrum card.
            /// </summary>
            [JsonProperty("ScrumStartActivityId")]
            public string ScrumStartActivityId { get; set; }

            /// <summary>
            /// Gets or sets the TrailCardActivityId of the root scrum card.
            /// </summary>
            [JsonProperty("SummaryCardActivityId")]
            public string SummaryCardActivityId { get; set; }

            /// <summary>
            /// Gets or sets the MembersActivityIdMap of the root scrum card.
            /// </summary>
            [JsonProperty("MembersActivityIdMap")]
            public string MembersActivityIdMap { get; set; }

            /// <summary>
            /// Gets or sets the ScrumMasterId of the root scrum card.
            /// </summary>
            [JsonProperty("ScrumMasterId")]
            public string ScrumMasterId { get; set; }

            /// <summary>
            /// Gets or sets ScrumId.
            /// </summary>
            [JsonProperty("ScrumId")]
            public string ScrumId { get; set; }

            /// <summary>
            /// Gets or sets TeamId.
            /// </summary>
            [JsonProperty("TeamId")]
            public string TeamId { get; set; }

            /// <summary>
            /// Gets or sets ChannelName.
            /// </summary>
            [JsonProperty("ChannelName")]
            public string ChannelName { get; set; }

            /// <summary>
            /// Gets or sets serviceUrl.
            /// </summary>
            [JsonProperty("ServiceUrl")]
            public string ServiceUrl { get; set; }

            /// <summary>
            /// Gets or sets UserPrincipalNames.
            /// </summary>
            [JsonProperty("UserPrincipalNames")]
            public List<string> UserPrincipalNames { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether gets or sets status of the scrum.
            /// </summary>
            [JsonProperty("IsCompleted")]
            public bool IsCompleted { get; set; }

            /// <summary>
            /// Gets or sets CreatedOn.
            /// </summary>
            [JsonProperty("CreatedOn")]
            public string CreatedOn { get; set; }

            /// <summary>
            /// Gets or sets CreatedBy.
            /// </summary>
            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether gets or sets IsReportGenerated.
            /// </summary>
            [JsonProperty("IsReportGenerated")]
            public bool IsReportGenerated { get; set; }

            /// <summary>
            /// Gets or sets IsReportGenerated.
            /// </summary>
            [JsonProperty("ReportGeneratedDate")]
            public string ReportGeneratedDate { get; set; }
        }
        public class ScrumMaster
        {
            /// <summary>
            /// Gets or sets ScrumMasterID.
            /// </summary>
            [JsonProperty("ScrumMasterID")]
            public string ScrumMasterID { get; set; }

            /// <summary>
            /// Gets or sets ChannelId.
            /// </summary>
            [JsonProperty("ChannelId")]
            public string ChannelId { get; set; }

            /// <summary>
            /// Gets or sets ChannelName.
            /// </summary>
            [JsonProperty("ChannelName")]
            public string ChannelName { get; set; }

            /// <summary>
            /// Gets or sets TeamId.
            /// </summary>
            [JsonProperty("TeamId")]
            public string TeamId { get; set; }

            /// <summary>
            /// Gets or sets StartTime.
            /// </summary>
            [JsonProperty("StartTime")]
            public string StartTime { get; set; }

            /// <summary>
            /// Gets or sets TimeZone.
            /// </summary>
            [JsonProperty("TimeZone")]
            public string TimeZone { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether gets or sets IsActive.
            /// </summary>
            [JsonProperty("IsActive")]
            public bool IsActive { get; set; }

            /// <summary>
            /// Gets or sets UserPrincipalNames.
            /// </summary>
            [JsonProperty("UserPrincipalNames")]
            public string UserPrincipalNames { get; set; }

            /// <summary>
            /// Gets or sets CreatedOn.
            /// </summary>
            [JsonProperty("CreatedOn")]
            public string CreatedOn { get; set; }

            /// <summary>
            /// Gets or sets CreatedBy.
            /// </summary>
            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }

            /// <summary>
            /// Gets or sets TeamName.
            /// </summary>
            [JsonProperty("TeamName")]
            public string TeamName { get; set; }

            /// <summary>
            /// Gets or sets AADGroupID.
            /// </summary>
            [JsonProperty("AADGroupID")]
            public string AADGroupID { get; set; }
        }
        /// <summary>
        /// GetActive Scrum Masters ListAsync.
        /// </summary>
        /// <returns>ScrumMasters.</returns>
        /// 
        private static DateTime ConvertToUTCDateTime(string timeZone, string startTime)
        {
            Console.WriteLine($"ConvertToUTCDateTime : Started ");
            Console.WriteLine($"ConvertToUTCDateTime : Started ");
            try
            {
                char[] delimiterChars = { ' ', ':', '.' };
                var timezonedata = GetTimeZoneData();
                var timezones = JsonConvert.DeserializeObject<TimezoneData>(timezonedata);
                string offset = timezones.Timezones.Where(zone => zone.TimeZoneCode.Equals(timeZone)).FirstOrDefault().TimeZoneOffset;
                string[] timeParts = startTime.Split(delimiterChars);
                string[] offsets = offset.Split(delimiterChars);
                Console.WriteLine($"Original Time " + startTime);
                string time = (timeParts[2].Equals("PM") && Convert.ToInt32(timeParts[0]) < 12) ? $"{Convert.ToInt32(timeParts[0]) + 12}:{timeParts[1]}:00" : $"{timeParts[0]}:{timeParts[1]}:00";
                Console.WriteLine($"Changed Time " + time);
                var convertedUTCTime = Convert.ToDateTime(time);
                bool isBehindUTC = offsets[0].StartsWith("-");
                // Indian Standard Time is 5 hours and 30 minutes ahead of Coordinated Universal Time +5:30
                // Pacific Time Time is 7 hours behind Coordinated Universal Time                     -7:00
                Console.WriteLine($"ConvertToUTCDateTime : before offset " + convertedUTCTime);
                // if it is behind add 
                convertedUTCTime = convertedUTCTime.AddMinutes((offsets.Length > 1) ? (isBehindUTC ? Convert.ToInt32(offsets[1]) : -Convert.ToInt32(offsets[1])) : 0);
                var changedTime = convertedUTCTime.AddHours(-Convert.ToInt32(offsets[0]));
                Console.WriteLine($"ConvertToUTCDateTime : after offset " + changedTime);
                return changedTime;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ConvertToUTCDateTime : Exception : {ex.StackTrace}");
               
                return default;
            }
        }
        private static async Task<List<ScrumMaster>> GetActiveScrumMastersListAsync()
        {
            Console.WriteLine($"GetActive ScrumMasters List Async: Started ");
            List<ScrumMaster> activeScrumMastersList = new List<ScrumMaster>();
            try
            {
                var master1 = new ScrumMaster { ScrumMasterID = "1", TimeZone = "MDT", StartTime = "03:00 AM" };
                 //var master2 = new ScrumMaster { ScrumMasterID = "2", TimeZone = "IST", StartTime = "01:30 PM" };
                var scrum1 = new Scrum { ScrumMasterId = "1", IsCompleted = false, CreatedOn = "4/3/2020 7:47:08 PM" };
                 var scrum2 = new Scrum { ScrumMasterId = "1", IsCompleted = true , CreatedOn = "4/3/2020 7:47:08 PM" };

                var activeScrumMasters = new List<ScrumMaster> { master1 };
                foreach (ScrumMaster scrumMaster in activeScrumMasters)
                {
                    DateTime scrumStartUTCTime = ConvertToUTCDateTime(scrumMaster.TimeZone, scrumMaster.StartTime);
                    DateTime currentDateTime = DateTime.UtcNow;
                    Console.WriteLine($"currentDateTime :  {currentDateTime}");
                    Console.WriteLine($"scrumStartUTCTime :  {scrumStartUTCTime}");
                    int result = currentDateTime.CompareTo(scrumStartUTCTime);
                    if (currentDateTime >= scrumStartUTCTime)
                    {
                        var scrumTimedifferencedays = currentDateTime.Subtract(scrumStartUTCTime).Days;
                        var scrumTimedifferenceHrs = currentDateTime.Subtract(scrumStartUTCTime).Hours;
                        var scrumTimedifferencehrsMins = currentDateTime.Subtract(scrumStartUTCTime).Minutes;
                        var differenceinScrumStartTimeMins = (scrumTimedifferenceHrs * 60) + scrumTimedifferencehrsMins;
                        if (differenceinScrumStartTimeMins < 10)
                        {
                            var allScrums = new List<Scrum> { scrum1, scrum2 };
                            if (allScrums == null)
                            {
                                Console.WriteLine($"No Scrums for  {scrumMaster.ScrumMasterID}");
                                activeScrumMastersList.Add(scrumMaster);
                            }
                            else
                            {
                                var completedScrums = allScrums.Where(scrum => scrum.IsCompleted == true);
                                var runningScrums = allScrums.Where(scrum => scrum.IsCompleted == false);
                                if (runningScrums != null)
                                {
                                    if (runningScrums.Count() > 0)
                                    {
                                        Console.WriteLine($"Incompleted scrums {scrumMaster.ScrumMasterID}  {runningScrums.Count()}");
                                        foreach (var scrum in runningScrums)
                                        {
                                            var universalCreatedTime = Convert.ToDateTime(scrum.CreatedOn);
                                            var scrumStartedBeforeInMinutes = (currentDateTime.Subtract(universalCreatedTime).Days * 24 * 60) + (currentDateTime.Subtract(universalCreatedTime).Hours * 60) + currentDateTime.Subtract(universalCreatedTime).Minutes;
                                            Console.WriteLine($"Scrum started {scrumStartedBeforeInMinutes} mins ago ");
                                            var oneDayinMinuts = (23 * 60) - 5;
                                            if (scrumStartedBeforeInMinutes > oneDayinMinuts)
                                            {
                                                scrum.IsCompleted = true;
                                                Console.WriteLine($"Scrum not completed for {scrumMaster.ScrumMasterID} with ScrumID {scrum.ScrumId}");
                                                //await this.scrumRepository.CreateOrUpdateScrumAsync(scrum).ConfigureAwait(true);
                                                activeScrumMastersList.Add(scrumMaster);
                                            }
                                        }
                                    }
                                }
                                else if (completedScrums != null)
                                {
                                    if (allScrums.Count == completedScrums.Count())
                                    {
                                        Console.WriteLine($"All scrums completed for {scrumMaster.ScrumMasterID}");
                                        activeScrumMastersList.Add(scrumMaster);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetActiveScrumMastersListAsync: Exception : {ex.StackTrace}");
                //this.telemetryClient.TrackException(ex);
            }

            return activeScrumMastersList;
        }
        static async Task Main(string[] args)
        {

            await GetActiveScrumMastersListAsync();
            //await callAPI();
            Console.WriteLine();

            
            //AccessToken token = GetTokenForApplication().Result;
            //await callAPI(token);
            //Console.WriteLine(String.Format("Access Token: {0}", token.access_token));

            Console.ReadKey();
        }
            private static async Task callAPI(AccessToken token)
            {
                Console.WriteLine($"C# Timer trigger function executed at: {DateTime.Now}");
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://scrumbeev2.azurewebsites.net/")
            };
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://scrumbeev2.azurewebsites.net/api/Notification/GetMessageAsync"),
                Headers = {
                        //{ HttpRequestHeader.Authorization.ToString(), "Bearer " + token.access_token },
                            { HttpRequestHeader.Authorization.ToString(), "Bearer eyJ0eXAiOiJKV1QiLCJub25jZSI6IjNTLXVDY2RUZ1NZY2FFR2Z4QnlaTjdmLXNMa0R0MjRlV3ZQX2t3OXNaU1UiLCJhbGciOiJSUzI1NiIsIng1dCI6IllNRUxIVDBndmIwbXhvU0RvWWZvbWpxZmpZVSIsImtpZCI6IllNRUxIVDBndmIwbXhvU0RvWWZvbWpxZmpZVSJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDAiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC82Mzg4OWU5Zi1mNGIyLTQwNDMtOGI4YS1mMjlkMjcyMmI4MTQvIiwiaWF0IjoxNTg2MTY0MzEwLCJuYmYiOjE1ODYxNjQzMTAsImV4cCI6MTU4NjE2ODIxMCwiYWNjdCI6MCwiYWNyIjoiMSIsImFpbyI6IjQyZGdZSkNvcldDK3N0dUR1VXBqeGZ3bnJibzJ0ZEtjaW5jNWVMdTM3UW1UNDdLV3lBVUEiLCJhbXIiOlsicHdkIl0sImFwcF9kaXNwbGF5bmFtZSI6IkdyYXBoIGV4cGxvcmVyIiwiYXBwaWQiOiJkZThiYzhiNS1kOWY5LTQ4YjEtYThhZC1iNzQ4ZGE3MjUwNjQiLCJhcHBpZGFjciI6IjAiLCJmYW1pbHlfbmFtZSI6IkRvZSIsImdpdmVuX25hbWUiOiJKb2huIiwiaXBhZGRyIjoiMTc1LjEwMS4zNi45MiIsIm5hbWUiOiJKb2huIERvZSIsIm9pZCI6IjY3ZGFmYjkxLTc4YjgtNDA1Mi05ZTQ0LWI5MzkzMDFkZjFiNSIsInBsYXRmIjoiMyIsInB1aWQiOiIxMDAzMjAwMDY1MDlEQzgyIiwic2NwIjoiQm9va2luZ3MuUmVhZFdyaXRlLkFsbCBDYWxlbmRhcnMuUmVhZCBDYWxlbmRhcnMuUmVhZFdyaXRlIENvbnRhY3RzLlJlYWRXcml0ZSBEZXZpY2VNYW5hZ2VtZW50QXBwcy5SZWFkV3JpdGUuQWxsIERldmljZU1hbmFnZW1lbnRDb25maWd1cmF0aW9uLlJlYWQuQWxsIERldmljZU1hbmFnZW1lbnRDb25maWd1cmF0aW9uLlJlYWRXcml0ZS5BbGwgRGV2aWNlTWFuYWdlbWVudE1hbmFnZWREZXZpY2VzLlByaXZpbGVnZWRPcGVyYXRpb25zLkFsbCBEZXZpY2VNYW5hZ2VtZW50TWFuYWdlZERldmljZXMuUmVhZC5BbGwgRGV2aWNlTWFuYWdlbWVudE1hbmFnZWREZXZpY2VzLlJlYWRXcml0ZS5BbGwgRGV2aWNlTWFuYWdlbWVudFJCQUMuUmVhZC5BbGwgRGV2aWNlTWFuYWdlbWVudFJCQUMuUmVhZFdyaXRlLkFsbCBEZXZpY2VNYW5hZ2VtZW50U2VydmljZUNvbmZpZy5SZWFkLkFsbCBEZXZpY2VNYW5hZ2VtZW50U2VydmljZUNvbmZpZy5SZWFkV3JpdGUuQWxsIERpcmVjdG9yeS5BY2Nlc3NBc1VzZXIuQWxsIERpcmVjdG9yeS5SZWFkV3JpdGUuQWxsIEZpbGVzLlJlYWRXcml0ZS5BbGwgR3JvdXAuUmVhZC5BbGwgR3JvdXAuUmVhZFdyaXRlLkFsbCBJZGVudGl0eVJpc2tFdmVudC5SZWFkLkFsbCBNYWlsLlJlYWRXcml0ZSBNYWlsYm94U2V0dGluZ3MuUmVhZFdyaXRlIE5vdGVzLlJlYWRXcml0ZS5BbGwgb3BlbmlkIFBlb3BsZS5SZWFkIFByZXNlbmNlLlJlYWQuQWxsIHByb2ZpbGUgUmVwb3J0cy5SZWFkLkFsbCBTaXRlcy5SZWFkV3JpdGUuQWxsIFRhc2tzLlJlYWRXcml0ZSBVc2VyLlJlYWQgVXNlci5SZWFkQmFzaWMuQWxsIFVzZXIuUmVhZFdyaXRlIFVzZXIuUmVhZFdyaXRlLkFsbCBlbWFpbCIsInN1YiI6ImhzWHIzMXY4Sl9vTU12M0NUdXI4cHNKajBMVEd1LWJiUGdwNnVYM2J5QVUiLCJ0aWQiOiI2Mzg4OWU5Zi1mNGIyLTQwNDMtOGI4YS1mMjlkMjcyMmI4MTQiLCJ1bmlxdWVfbmFtZSI6IkpvaG5kb2VAbXN0ZWFtc3BvYy5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJKb2huZG9lQG1zdGVhbXNwb2Mub25taWNyb3NvZnQuY29tIiwidXRpIjoibHZrZHdQOVB4VW1GZFJmMVdCczVBQSIsInZlciI6IjEuMCIsIndpZHMiOlsiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIl0sInhtc19zdCI6eyJzdWIiOiIwZVh3SG5GTzBYTDlFclZRZElDb2tUTWZIS3p1TDY0dHlnOUNzRmo2LWw4In0sInhtc190Y2R0IjoxNTY3NDg2NTkwfQ.ADzlCVFJlPwXPllnLuboUUf-RZQ8k_Nc0RW5xbUCs-BO5I0Si49246O7ICbv3IfgoZ5XE4_uDiPCHTX3MuT6AhCDo3Yb8LZVgyaahwliCFr_-XlW251MYg5gxnQEpqs78tZNWBJCbIO_ovzItE9xgYOH32WKTELQGNIyMw64mdWJflvwuAVZhnKkZlTu1i2A0SKI5AyC5AcfeMiUY45pCA_D2a9HVrVNUKnTb01ovuy96VNxgFakuT_h0cs9303vN3DGqMPVTLteVbxiTPGEXQHiDgXBufdX0P7VSWGo2l_mOakLF7y8hfmcmrehC7hOrWgj14WY6vgb3QBqHzGMSQ" },
                        { HttpRequestHeader.Accept.ToString(), "application/json" },
                    },
            };
            var response = client.SendAsync(httpRequestMessage).Result;
        
            Console.WriteLine($"C# Timer trigger{    response.Content.ReadAsStringAsync().Result} function executed at: {DateTime.Now}");
            response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"C# Timer trigger{response.IsSuccessStatusCode} function executed at: {DateTime.Now}");
                }
                else
                {
                    Console.WriteLine($"Error ..C# Timer trigger function executed at: {DateTime.Now}");
                }
        }
        class AccessToken
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public long expires_in { get; set; }
        }
        static async Task<AccessToken> GetToken()
        {
            Console.WriteLine("Getting Token");
            string clientId = "41cc84db-6ab6-494d-8226-f69abad5b263";
            string clientSecret = "lbXx6zf_atXoODBmcBE76N:@:4fZfLi6";
            string tenant = "63889e9f-f4b2-4043-8b8a-f29d2722b814";
            string credentials = String.Format("{0}:{1}", clientId, clientSecret);

            using (var client = new HttpClient())
            {
                //Define Headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));
                client.DefaultRequestHeaders.Add("scope", "User.Read");
                //Prepare Request Body
                List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
                requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

                FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

                //Request Token
                var request = await client.PostAsync("https://login.microsoftonline.com/63889e9f-f4b2-4043-8b8a-f29d2722b814/oauth2/v2.0/token", requestBody);
                var response = await request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AccessToken>(response);
            }
        }


        static async Task<AccessToken> GetTokenForApplication()
        {
            //check for token exppiration pending accessToken then create new instance of HttpClient - pending
          HttpClient _client;
          AccessToken accessToken = null;
        _client = new HttpClient();
            var formVariables = new List<KeyValuePair<string, string>>();
            formVariables.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            //formVariables.Add(new KeyValuePair<string, string>("client_id", "f50f0b77-13fc-4c50-9a98-0af41247600e"));
            //formVariables.Add(new KeyValuePair<string, string>("client_secret", "i4MKR.FscccBJOILa0Z_.o9dzY-CMtY9"));
            formVariables.Add(new KeyValuePair<string, string>("client_id", "41cc84db-6ab6-494d-8226-f69abad5b263"));
            formVariables.Add(new KeyValuePair<string, string>("client_secret", "lbXx6zf_atXoODBmcBE76N:@:4fZfLi6"));
            formVariables.Add(new KeyValuePair<string, string>("scope", "https://graph.microsoft.com/.default"));
            var formContent = new FormUrlEncodedContent(formVariables);
            _client.BaseAddress = new Uri("https://login.microsoftonline.com/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await _client.PostAsync(string.Format("/{0}/oauth2/v2.0/token", "63889e9f-f4b2-4043-8b8a-f29d2722b814"), formContent);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                accessToken = JsonConvert.DeserializeObject<AccessToken>(jsonString);
            }
            return accessToken;
        }
    }
}
