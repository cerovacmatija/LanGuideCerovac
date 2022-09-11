using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanGuideCerovac
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        bool UserIdDescending = false;
        bool TestId = false;
        bool Skill = false;
        bool Percent = false;
        bool Score = false;
        bool MaxV = false;

        List<ResultsModel> modelList = new List<ResultsModel>();

        public ResultsPage()
        {
            InitializeComponent();
            GetJsonAsync();
        }

        public async Task GetJsonAsync()
        {
            var uri = new Uri("https://www.idt.mdh.se/personal/plt01/languide/?get=results");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string json = content.ToString();


                var jsonObject = JObject.Parse(json);
                var status = jsonObject["error"];
                var msg = jsonObject["msg"];
                var data = jsonObject["data"];

                var jsonArray = JArray.Parse(data.ToString());

                foreach (var userObject in jsonArray)
                {
                    ResultsModel tmp = new ResultsModel();

                    tmp.id_user = userObject["id_user"].ToString();
                    tmp.id_exercise = userObject["id_exercise"].ToString();
                    tmp.skill = userObject["skill"].ToString();
                    tmp.result_percent = userObject["result_percent"].ToString();
                    tmp.result_score = userObject["result_score"].ToString();
                    tmp.result_max = userObject["result_max"].ToString();

                    modelList.Add(tmp);
                }
            }

            results.ItemsSource = modelList;
        }

        private void Sort_by_Id(object sender, EventArgs e)
        {
            List<ResultsModel> sortedList = new List<ResultsModel>();
            if (UserIdDescending)
                sortedList = modelList.OrderBy(o => o.id_user).ToList();
            else
                sortedList = modelList.OrderByDescending(o => o.id_user).ToList();

            UserIdDescending = !UserIdDescending;
            results.ItemsSource = null;
            results.ItemsSource = sortedList;
        }
        private void Sort_by_TestId(object sender, EventArgs e)
        {
            List<ResultsModel> sortedList = new List<ResultsModel>();
            if (TestId)
                sortedList = modelList.OrderBy(o => o.id_exercise).ToList();
            else
                sortedList = modelList.OrderByDescending(o => o.id_exercise).ToList();

            TestId = !TestId;
            results.ItemsSource = null;
            results.ItemsSource = sortedList;
        }
        private void Sort_by_Skill(object sender, EventArgs e)
        {
            List<ResultsModel> sortedList = new List<ResultsModel>();
            if (Skill)
                sortedList = modelList.OrderBy(o => o.skill).ToList();
            else
                sortedList = modelList.OrderByDescending(o => o.skill).ToList();

            Skill = !Skill;
            results.ItemsSource = null;
            results.ItemsSource = sortedList;
        }
        private void Sort_by_Percent(object sender, EventArgs e)
        {
            List<ResultsModel> sortedList = new List<ResultsModel>();
            if (Percent)
                sortedList = modelList.OrderBy(o => o.result_percent).ToList();
            else
                sortedList = modelList.OrderByDescending(o => o.result_percent).ToList();

            Percent = !Percent;
            results.ItemsSource = null;
            results.ItemsSource = sortedList;
        }
        private void Sort_by_Score(object sender, EventArgs e)
        {
            List<ResultsModel> sortedList = new List<ResultsModel>();
            if (Score)
                sortedList = modelList.OrderBy(o => o.result_score).ToList();
            else
                sortedList = modelList.OrderByDescending(o => o.result_score).ToList();

            Score = !Score;
            results.ItemsSource = null;
            results.ItemsSource = sortedList;
        }
        private void Sort_by_Max(object sender, EventArgs e)
        {
            List<ResultsModel> sortedList = new List<ResultsModel>();
            if (MaxV)
                sortedList = modelList.OrderBy(o => o.result_max).ToList();
            else
                sortedList = modelList.OrderByDescending(o => o.result_max).ToList();

            MaxV = !MaxV;
            results.ItemsSource = null;
            results.ItemsSource = sortedList;
        }

        private async void Filter_Button_Clicked(object sender, EventArgs e)
        {
            List<ResultsModel> filteredList = new List<ResultsModel>();

            var fromValue = From.Text;
            var toValue = To.Text;

            if (fromValue == null) fromValue = "0";
            if (toValue == null) toValue = "100";

            float fV = float.Parse(fromValue);
            float tV = float.Parse(toValue);

            filteredList = modelList.Where(o => float.Parse(o.result_percent) >= fV && float.Parse(o.result_percent) <= tV).ToList();
            results.ItemsSource = null;
            results.ItemsSource = filteredList;
        }
    }
}