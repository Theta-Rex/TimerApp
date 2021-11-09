using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TimerApp
{
    class MainViewModel
    {
        public ObservableCollection<MyTimer> MyTimers { get; set; }
        public MainViewModel()
        {
            MyTimers = new ObservableCollection<MyTimer>();

            MyTimers.Add(new MyTimer("Timer 1", "0"));
            MyTimers.Add(new MyTimer("Timer 2", "0"));
            MyTimers.Add(new MyTimer("Timer 3", "0"));
        }

    }
}
