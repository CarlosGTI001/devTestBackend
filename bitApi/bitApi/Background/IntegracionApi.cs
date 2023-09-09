using bitApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace bitApi.Background
{
    public class IntegracionApi : BackgroundService
    {
        bitApiContext _context;
        public IntegracionApi(bitApiContext context)
        {
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var announcements = await ObtenerJsonAsync("https://www.bitmex.com/api/v1/announcement");
                if (announcements != null)
                {
                    foreach (var announcement in announcements)
                    {
                        if (!_context.announcement.Contains(announcement))
                        {
                            _context.announcement.Add(announcement);
                        }

                    }
                    _context.SaveChanges();
                }
                await Task.Delay(TimeSpan.FromMinutes(0.5), stoppingToken);
            }
        }

        public async Task<List<announcement>> ObtenerJsonAsync(string uriApi)
        {
            List<announcement> result = new List<announcement>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(uriApi);
                if(response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<List<announcement>>(json.Result);
                }
            }
            return result;
        }
    }
}
