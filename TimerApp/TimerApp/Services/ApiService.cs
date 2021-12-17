// <copyright file="ApiService.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.Services
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using TimerApp.ViewModels;

    /// <summary>
    /// API Service class.
    /// </summary>
    public class ApiService : ITimerService
    {
        private readonly string url = "http://localhost:32930/api/timeritems";
        private readonly HttpClient httpClient = new HttpClient();

        /// <inheritdoc/>
        public async Task<IEnumerable<TimerItem>> GetTimers()
        {
            // HttpClient httpClient = new HttpClient();
            using (HttpResponseMessage response = await this.httpClient.GetAsync(this.url).ConfigureAwait(false))
            {
                // Make sure we were successful and, if so, parse the JSON data into a structure.
                response.EnsureSuccessStatusCode();
                var result = JsonConvert.DeserializeObject<ObservableCollection<TimerItem>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                return result;
            }
        }

        /// <inheritdoc/>
        public async Task<TimerItem> GetTimer(int id)
        {
            using (HttpResponseMessage response = await this.httpClient.GetAsync(this.url + $"/{id}").ConfigureAwait(false))
            {
                // Make sure we were successful and, if so, parse the JSON data into a structure.
                response.EnsureSuccessStatusCode();
                var result = JsonConvert.DeserializeObject<TimerItem>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                return result;
            }
        }

        /// <inheritdoc/>
        public async Task<TimerItem> AddTimer(TimerItem timerItem)
        {
            TimerItem t;

            using (HttpResponseMessage response = await this.httpClient.PostAsync(this.url, new StringContent(
                JsonConvert.SerializeObject(timerItem), Encoding.UTF8, "application/json")).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                t = JsonConvert.DeserializeObject<TimerItem>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                return t;
            }
        }

        /// <inheritdoc/>
        public async Task DeleteTimer(TimerItem timerItem)
        {
            using (HttpResponseMessage response = await this.httpClient.DeleteAsync(this.url + $"/{timerItem.Id}").ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        /// <inheritdoc/>
        public async Task UpdateTimer(TimerItem timerItem)
        {
            using (HttpResponseMessage response = await this.httpClient.PutAsync(this.url + $"/{timerItem.Id}", new StringContent(
                JsonConvert.SerializeObject(timerItem), Encoding.UTF8, "application/json")).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
