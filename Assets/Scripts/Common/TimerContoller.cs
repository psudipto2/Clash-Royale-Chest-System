using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

namespace Common
{
    public class TimerContoller : MonoBehaviour
    {
        private int hour;
        private int minute;
        private int second;
        private string displayHour;
        private string displayMinute;
        private string displaySecond;
        public string TimerDisplay(int timerInSeconds)
        {
            int hour = timerInSeconds / 3600;
            int minute = (timerInSeconds - (3600 * hour)) / 60;
            int second = (timerInSeconds - (3600 * hour) - (minute * 60));
            if (second > 0)
            {
                displaySecond = second.ToString() + "S";
            }
            else
            {
                displaySecond = "";
            }
            if (minute > 0)
            {
                displayMinute = minute.ToString() + "M";
            }
            else
            {
                displayMinute = "";
            }
            if (hour > 0)
            {
                displayHour = hour.ToString() + "H";
            }
            else
            {
                displayHour = "";
            }
            string timer = displayHour + displayMinute + displaySecond;
            return timer;
        }
    }
}

