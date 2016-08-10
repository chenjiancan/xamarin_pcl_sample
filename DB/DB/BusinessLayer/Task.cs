using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace DB.BusinessLayer
{
    public class Task: Contracts.BusinessEntityBase
    {
        private AlarmClass alarm;

        public string Title { get; set; }
        public string Note { get; set; }
        // new property
        public bool Done { get; set; }

        public bool Star { get; set; }

        public AlarmClass Alarm
        {
            get { return alarm; }
            set { alarm = value; }
        }



        public class AlarmClass
        {
            public DateTime Time { get; set; }
            public bool Repeat { get; set; }
            public bool Over { get; set; }
        }

        public Task()
        {
            this.alarm = new AlarmClass();
        }
        public Task(string title="", string note="", bool done=false, bool star = false, bool repeat = false, bool over=false)
        {
            this.alarm = new AlarmClass();

            this.Title = title;
            this.Note = note;
            this.Done = done;
            this.Star = star;
            this.alarm.Time = DateTime.Now;
            this.alarm.Repeat = repeat;
            this.alarm.Over = over;
        }
    }
}
