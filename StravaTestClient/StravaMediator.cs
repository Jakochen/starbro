using com.strava.api.Activities;
using com.strava.api.Authentication;
using com.strava.api.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaTestClient
{
    public class StravaMediator
    {
        private string token = "e2e838ab0491e56e094ae18db4b27ade1c840ab2";
        private StaticAuthentication auth;
        private StravaClient client;

        public StravaMediator(string apiToken)
        {
            auth = new StaticAuthentication(apiToken);
            client = new StravaClient(auth);
        }

        private List<ActivitySummary> GetAllRuns(DateTime startDate, DateTime endDate)
        {
            var allactivites = client.Activities.GetActivities(startDate, endDate);

            return allactivites.Where(x => x.Type == ActivityType.Run).ToList();

        }

        public List<ActivitySummary> GetLongRuns(DateTime startDate, DateTime endDate)
        {
            var allruns = GetAllRuns(startDate, endDate);
            var longruns = allruns.Where(x => x.Distance > 26000).ToList();

            return longruns;
        }

        public double GetAveragePace(List<ActivitySummary> activities)
        {
            var totaldistance = activities.Sum(x => x.Distance) / 1000;
            var totaltime = activities.Sum(x => x.ElapsedTime) / 60;
            return totaltime / totaldistance;
        }

        public string GetFormatedPace(double pace)
        {
            return MakeTimeString(pace);
        }

        private static string MakeTimeString(double num)
        {
            double hours = Math.Floor(num); //take integral part
            double minutes = (num - hours) * 60.0; //multiply fractional part with 60
         //   double seconds = (minutes - Math.Floor(minutes)) * 60.0;  //add if you want seconds
            int H = (int)Math.Floor(hours);
            int M = (int)Math.Floor(minutes);
        //    int S = (int)Math.Floor(seconds);   //add if you want seconds
            return H.ToString() + ":" + M.ToString();// +":" + S.ToString(); //add if you want seconds

        }

    }
}
