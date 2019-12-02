using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_S00189001
{
    public enum ActivityType
    {
        All, Land, Water, Air
    }


    public class Activity : IComparable
    {
        public string Name;
        public decimal cost;
        public DateTime date;
        public string description;
        public ActivityType type;

        public Activity(string NAME, int COST, DateTime DATE, string DESCRIPTION, ActivityType TYPE)
        {
            type = TYPE;
            Name = NAME;
            cost = COST;
            date = DATE;
            description = DESCRIPTION;
        }

        public int CompareTo(object obj)
        {
            Activity activity = obj as Activity;
            return activity.date.CompareTo(this.date);
        }

        public override string ToString()
        {
            return Name + " - " + date.ToShortDateString();
        }


        public string GetDescription()
        {
            return String.Format("{0} - {1:c}", description, cost);
        }
    }
}
