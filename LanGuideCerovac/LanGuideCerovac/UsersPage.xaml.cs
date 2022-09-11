using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.ComponentModel;

namespace LanGuideCerovac
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        List<UsersModel> modelList = new List<UsersModel>();
        public UsersPage()
        {
            InitializeComponent();

            GetJsonAsync();
        }

        public async Task GetJsonAsync()
        {
            var uri = new Uri("https://www.idt.mdh.se/personal/plt01/languide/?get=users");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string json = content.ToString();
                var jsonObject = JObject.Parse(json);
                var status = jsonObject["error"];
                var message = jsonObject["msg"];
                var data = jsonObject["data"];
                var jsonArray = JArray.Parse(data.ToString());

                foreach (var token in jsonArray)
                {
                    UsersModel model = new UsersModel();
                    string id_user = token["id_user"].ToString();
                    string value1 = token["0"].ToString();
                    string value2 = token["1"].ToString();
                    string create_time = token["create_time"].ToString();
                    string value3 = token["2"].ToString();
                    model.id_user = id_user;
                    model.value1 = value1;
                    model.value2 = value2;
                    model.create_time = create_time;
                    model.value3 = value3;
                    modelList.Add(model);


                }
                Debug.WriteLine(message);
            }
            testListView.ItemsSource = modelList;

        }

        public async Task GetJsonAsync1()
        {
            var uri = new Uri("https://www.idt.mdh.se/personal/plt01/languide/?get=users");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string json = content.ToString();
                var jsonObject = JObject.Parse(json);
                var status = jsonObject["error"];
                var message = jsonObject["msg"];
                var data = jsonObject["data"];
                var jsonArray = JArray.Parse(data.ToString());

                foreach (var token in jsonArray)
                {
                    UsersModel model = new UsersModel();
                    string id_user = token["id_user"].ToString();
                    string value1 = token["0"].ToString();
                    string value2 = token["1"].ToString();
                    string create_time = token["create_time"].ToString();
                    string value3 = token["2"].ToString();
                    model.id_user = id_user;
                    model.value1 = value1;
                    model.value2 = value2;
                    model.create_time = create_time;
                    model.value3 = value3;
                    modelList.Add(model);


                }
                Debug.WriteLine(message);
            }

            var sorting = modelList.OrderBy(model => model.id_user).ToList();
            testListView.ItemsSource = sorting;


        }

        public async Task GetJsonAsync2()
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
                var message = jsonObject["msg"];
                var data = jsonObject["data"];
                var jsonArray = JArray.Parse(data.ToString());

                foreach (var token in jsonArray)
                {
                    UsersModel model = new UsersModel();

                    string id_user = token["id_user"].ToString();
                    string value1 = token["0"].ToString();
                    string value2 = token["1"].ToString();
                    string create_time = token["create_time"].ToString();
                    string value3 = token["2"].ToString();
                    model.id_user = id_user;
                    model.value1 = value1;
                    model.value2 = value2;
                    model.create_time = create_time;
                    model.value3 = value3;
                    modelList.Add(model);

                }
                Debug.WriteLine(message);
            }

            var sorting = modelList.OrderByDescending(model => model.id_user).ToList();
            testListView.ItemsSource = sorting;

        }

        private void Ascending_Button(object sender, EventArgs e)
        {
            GetJsonAsync1();
        }

        private void Descending_Button(object sender, EventArgs e)
        {
            GetJsonAsync2();
        }

        private void Search_ID(object sender, TextChangedEventArgs e)
        {
            var search = modelList.Where(user => user.id_user.StartsWith(e.NewTextValue)).ToList();
            testListView.ItemsSource = search;
        }

        
    }

}