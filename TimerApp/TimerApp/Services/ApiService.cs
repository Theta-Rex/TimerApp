// <copyright file="ApiService.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using TimerApp.ViewModels;

    public class ApiService : ITimerService
    {
        private readonly string url = "http://localhost:32930/api/timeritems";

        public async Task<IEnumerable<TimerItemViewModel>> GetTimers()
        {
            HttpClient httpClient = new HttpClient();
            using (HttpResponseMessage response = await httpClient.GetAsync(this.url).ConfigureAwait(false))
            {
                // Make sure we were successful and, if so, parse the JSON data into a structure.
                response.EnsureSuccessStatusCode();
                var result = JsonConvert.DeserializeObject<ObservableCollection<TimerItemViewModel>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                System.Diagnostics.Debug.WriteLine(result);
                return result;
            }
        }

        public Task<TimerItemViewModel> GetTimer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
