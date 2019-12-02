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
        public decimal totalSelectedActivityCost = 0;

        public MainWindow()
        {
            InitializeComponent();
            ActivityDescription(null);
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
            //loop the list and add the cost to 'totalSelectedActivity'
            TotalSelectedActivity();
            SortAll();

        }

        // TotalSelectedActivity is used to update the total cost text and " formatting " it :D 
        public void TotalSelectedActivity()
        {
            totalSelectedActivityCost = 0;
            foreach (Activity activity in addedActivityList)
            {
                totalSelectedActivityCost += activity.cost;
            }
            string total = "€ " + totalSelectedActivityCost.ToString() + ".00";
            totalCost.Text = total;
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
            TotalSelectedActivity();
            SortAll();
        }

        public void ActivityDescription(Activity activity)
        {
            if (activity == null)
            {
                txtbDescription.Text = "Nothing is selected :(";
                return;
            }
            txtbDescription.Text = activity.GetDescription();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            addedActivityList = new ObservableCollection<Activity>();
            activityList = new ObservableCollection<Activity>();
            AllActivityList = new ObservableCollection<Activity>();
            random = new Random();
            ActivityCreation();

            // Old code, Replaces with ActivityCreation
            //for (int i = 0; i < 10; i++)
            //{
            //    AllActivityList.Add(RandomActivity());
            //}
            activityList = CopyList(AllActivityList, activityList);
            listboxActivities.ItemsSource = activityList;
            listboxSelectedActivities.ItemsSource = addedActivityList;
            SortAll();
        }

        public void SortAll()
        {
            SortList(activityList);
            SortList(addedActivityList);
            SortList(AllActivityList);
        }



        void SortList(ObservableCollection<Activity> listToSort)
        {
            // make new list of type Activity 
            List<Activity> sortedList = new List<Activity>();

            //for each item in 'listToSort' i will add it to 'the new list of type activity' 
            foreach (Activity activity in listToSort)
            {
                sortedList.Add(activity);
            }

            //sort the new list of type activity name.Sort()
            sortedList.Sort();

            //clear 'lsitToSort'
            listToSort.Clear();

            //copy items in new list of type activity to 'listToSort'
            foreach (Activity activity in sortedList)
            {
                listToSort.Add(activity);
            }
        }

        // Old code, Replaces with ActivityCreation
        //private Activity RandomActivity()
        //{
        //    int cost = random.Next(20, 150);
        //    DateTime date = new DateTime(random.Next(2000, 2020), random.Next(1, 13), random.Next(1, 30));
        //    ActivityType type = (ActivityType)random.Next(1, 4);
        //    string description = "sdadd" + type.ToString();
        //    string Name = random.Next(1, 11) % 2 == 0 ? "firstname " + type.ToString() : "secondname " + type.ToString();
        //    return new Activity(Name, cost, date, description, type);
        //}

        // Used to copy Activities from one list to another
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

        // Filter is used to filter the activities by type that is dictated by the radio button.
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

        private void listboxActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox temp = sender as ListBox;
            ActivityDescription(temp.SelectedItem as Activity);
        }

        public void ActivityCreation()
        {
            Activity l1 = new Activity()
            {
                Name = "Treking",
                description = "Instructor led group trek through local mountains.",
                date = new DateTime(2019, 06, 01),
                type = ActivityType.Land,
                cost = 20m
            };

            Activity l2 = new Activity()
            {
                Name = "Mountain Biking",
                description = "Instructor led half day mountain biking.  All equipment provided.",
                date = new DateTime(2019, 06, 02),
                type = ActivityType.Land,
                cost = 30m
            };

            Activity l3 = new Activity()
            {
                Name = "Abseiling",
                description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                date = new DateTime(2019, 06, 03),
                type = ActivityType.Land,
                cost = 40m
            };

            Activity w1 = new Activity()
            {
                Name = "Kayaking",
                description = "Half day lakeland kayak with island picnic.",
                date = new DateTime(2019, 06, 01),
                type = ActivityType.Water,
                cost = 40m
            };

            Activity w2 = new Activity()
            {
                Name = "Surfing",
                description = "2 hour surf lesson on the wild atlantic way",
                date = new DateTime(2019, 06, 02),
                type = ActivityType.Water,
                cost = 25m
            };

            Activity w3 = new Activity()
            {
                Name = "Sailing",
                description = "Full day lakeland kayak with island picnic.",
                date = new DateTime(2019, 06, 03),
                type = ActivityType.Water,
                cost = 50m
            };

            Activity a1 = new Activity()
            {
                Name = "Parachuting",
                description = "Experience the thrill of free fall while you tandem jump from an airplane.",
                date = new DateTime(2019, 06, 01),
                type = ActivityType.Air,
                cost = 100m
            };

            Activity a2 = new Activity()
            {
                Name = "Hang Gliding",
                description = "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                date = new DateTime(2019, 06, 02),
                type = ActivityType.Air,
                cost = 80m
            };

            Activity a3 = new Activity()
            {
                Name = "Helicopter Tour",
                description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                date = new DateTime(2019, 06, 03),
                type = ActivityType.Air,
                cost = 200m
            };

            AllActivityList.Add(l1);
            AllActivityList.Add(l2);
            AllActivityList.Add(l3);
            AllActivityList.Add(w1);
            AllActivityList.Add(w2);
            AllActivityList.Add(w3);
            AllActivityList.Add(a1);
            AllActivityList.Add(a2);
            AllActivityList.Add(a3);
            SortList(AllActivityList);
        }
    }
}
