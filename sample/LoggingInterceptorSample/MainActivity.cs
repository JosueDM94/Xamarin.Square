using System.Linq;
using System.Collections.Generic;

using Android.OS;
using Android.App;
using Android.Widget;
using Android.Support.V7.App;

using Square.OkHttp3;
using Newtonsoft.Json;
using Square.OkHttp3.Logging;

namespace LoggingInterceptorSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private static string Endpoint = "https://api.github.com/repos/square/okhttp/contributors";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Button download = FindViewById<Button>(Resource.Id.download);
            ListView listView = FindViewById<ListView>(Resource.Id.listView);

            download.Click += async delegate
            {
                HttpLoggingInterceptor logging = new HttpLoggingInterceptor();
                logging.SetLevel(HttpLoggingInterceptor.Level.Basic);
                OkHttpClient client = new OkHttpClient().NewBuilder()
                                                        .AddInterceptor(logging)
                                                        .Build();

                // Create request for remote resource.
                Request request = new Request.Builder()
                    .Url(Endpoint)
                    .Build();

                // Execute the request and retrieve the response.
                Response response = await client.NewCall(request).ExecuteAsync();

                // Deserialize HTTP response to concrete type.
                string body = await response.Body().StringAsync();
                List<Contributor> contributors = JsonConvert.DeserializeObject<List<Contributor>>(body);

                // Sort list by the most contributions.
                List<string> data = contributors
                    .OrderByDescending(c => c.contributions)
                    .Select(c => string.Format("{0} ({1})", c.login, c.contributions))
                    .ToList();

                // Output list of contributors.
                IListAdapter adapter = new ArrayAdapter<string>(
                    this,
                    Android.Resource.Layout.SimpleListItem1,
                    Android.Resource.Id.Text1,
                    data);
                listView.Adapter = adapter;
            };
        }

        public class Contributor
        {
            public string login { get; set; }

            public int contributions { get; set; }
        }
    }
}