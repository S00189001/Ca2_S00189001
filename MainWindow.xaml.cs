using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2_S00189001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random;
        ObservableCollection<Activity> activityList;
        ObservableCollection<Activity> addedActivityList;
        ObservableCollection<Activity> AllActivityList;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rbtnAll_Checked(object sender, RoutedEventArgs e)
        {
            Filter(ActivityType.All);
        }

        private void rbtnLand_Checked(object sender, RoutedEventArgs e)
        {
            Filter(ActivityType.Land);
        }

        private void rbtnWater_Checked(object sender, RoutedEventArgs e)
        {
            Filter(ActivityType.Water);
        }

        private void rbtnAir_Checked(object sender, RoutedEventArgs e)
        {
            Filter(ActivityType.Air);
        }

        private void btnAddRight_Click(object sender, RoutedEventArgs e)
        {
            if (listboxActivities.SelectedIndex < 0)
            {
                return;
            }            

            Activity activity = activityList[listboxActivities.SelectedIndex];
            addedActivityList.Add(activity);
            activityList.Remove(activity);
            AllActivityList.Remove(activity);
        }

        private void btnRemoveLeft_Click(object sender, RoutedEventArgs e)
        {
            if (listboxSelectedActivities.SelectedIndex < 0)
            {
                return;
            }

            Activity activity = addedActivityList[listboxSelectedActivities.SelectedIndex];
            activityList.Add(activity);
            AllActivityList.Add(activity);
            addedActivityList.Remove(activity);
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {          
            addedActivityList = new ObservableCollection<Activity>();
            activityList = new ObservableCollection<Activity>();
            AllActivityList = new ObservableCollection<Activity>();
            random = new Random();
            for (int i = 0; i < 10; i++)
            {
                AllActivityList.Add(RandomActivity());
            }
            activityList = CopyList( AllActivityList,activityList);
            listboxActivities.ItemsSource = activityList;
            listboxSelectedActivities.ItemsSource = addedActivityList;
        }

        private Activity RandomActivity()
        {           
            int cost = random.Next(20, 150);
            DateTime date = new DateTime(random.Next(2000, 2020), random.Next(1, 13), random.Next(1, 31));
            ActivityType type = (ActivityType)random.Next(1,4) ;
            string description = " sdadd" + type.ToString();
            string Name = random.Next(1, 11) % 2 == 0 ? "firstname " + type.ToString() : "secondname " + type.ToString();
            return new Activity(Name, cost, date, description, type);

        }
       
        private ObservableCollection<Activity> CopyList(ObservableCollection<Activity> fromList, ObservableCollection<Activity> toList)
        {
            if (fromList == null)
                return fromList;
            foreach (Activity item in fromList)
            {
                toList.Add(item);
            }
            return toList;
        }

        private void Filter(ActivityType TYPE)
        {
            switch (TYPE)
            {
                case ActivityType.All:
                    activityList = CopyList(AllActivityList, activityList);
                    break;
                case ActivityType.Water:
                case ActivityType.Air:
                case ActivityType.Land:
                    // Display Land Only
                    activityList.Clear();
                    foreach (Activity activity in AllActivityList)
                    {
                        if (activity.type == TYPE)
                            activityList.Add(activity);
                    }
                    break;

            }
        }
        //}        private void Filter(ActivityType TYPE)
        //{
        //    switch (TYPE)
        //    {
        //        case ActivityType.All:
        //            foreach (Activity activity in AllActivityList)
        //            {
        //                if (activity.type == ActivityType.All)
        //                    activityList.Add(activity);
        //            }
        //            break;
        //        case ActivityType.Land:
        //            // Display Land Only
        //            activityList.Clear();
        //            foreach (Activity activity in AllActivityList)
        //            {
        //                if (activity.type == ActivityType.Land)
        //                    activityList.Add(activity);
        //            }
        //            break;
        //        case ActivityType.Water:
        //            //Display Water Only
        //            activityList.Clear();
        //            foreach (Activity activity in AllActivityList)
        //            {
        //                if (activity.type == ActivityType.Water)
        //                    activityList.Add(activity);
        //            }
        //            break;
        //        case ActivityType.Air:
        //            // Display Air Only
        //            foreach (Activity activity in AllActivityList)
        //            {
        //                if (activity.type == ActivityType.Air)
        //                    activityList.Add(activity);
        //            }
        //            break;
        //        default:
        //            //Display All
        //            break;
        //    }
        //}
    }
}
