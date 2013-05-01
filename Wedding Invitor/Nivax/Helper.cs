using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace InvitationTemplate
{
    class ReviewData
    {
        public string Event, Name, Day, Month, Year, Hour, Minute, Initive ;
        public ImageSource Image;

        public ReviewData(string Event, string name, string day, string month, string year, string hour, string minute, string initive, ImageSource img)
        {
            this.Event = Event;
            this.Name = name;
            this.Day = day;
            this.Month = month;
            this.Year = year;
            this.Hour = hour;
            this.Minute = minute;
            this.Initive = initive;
            this.Image = img;
        }

    }

}