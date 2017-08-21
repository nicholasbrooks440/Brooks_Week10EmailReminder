using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Brooks_Week10EmailReminder.Resources;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Scheduler;

namespace Brooks_Week10EmailReminder
{// NOTE FOR TESTING ON THE EMULATOR, FIRST YOU NEED TO ADD EMAIL ACCOUNT ON DEVICE, THEN APP WILL WORK. 
    //(OTHERWISE "CANT SHARE ERROR" WILL APPEAR, MEANING IT DOENST HAVE EMAIL ACCOUNT ON PHONE TO SEND FROM)
    public partial class MainPage : PhoneApplicationPage
    {
        double min;
        double sec;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();        
            
        }

        private void setButton_Click(object sender, RoutedEventArgs e)
        {
            //Get the time
            //min
            if (double.TryParse(minTxtBox.Text, out min))
            {
                min = Int32.Parse(minTxtBox.Text);
            }
            else
            {
                min = 1;
            }
            //sec
            if (double.TryParse(secTxtBox.Text, out sec))
            {
                sec = Int32.Parse(secTxtBox.Text);
            }
            else
            {   //default 
                sec= 0;
            }
            //Use minute if > 0
            if (min> 0)
            {
                //Create reminder- name must be unique
                var emailReminder = Guid.NewGuid().ToString();
                var myReminder = new Microsoft.Phone.Scheduler.Reminder(emailReminder)
                {
                    //reminder time
                    BeginTime = DateTime.Now.AddMinutes((int)min),
                    //Tile for the reminder
                    Title = "Email Reminder",

                    //The desctription below the title
                    Content = "Click Here To Email Now",

                    //When the user taps the reminder
                    NavigationUri = new Uri("/Email.xaml?wake=true", UriKind.Relative),
                };

                ////Add the reminder
                ScheduledActionService.Add(myReminder);
            }
            else //Set seconds
            {
                //Create reminder- name must be unique
                var emailReminder = Guid.NewGuid().ToString();
                var myReminder = new Microsoft.Phone.Scheduler.Reminder(emailReminder)
                {
                    //reminder time
                    BeginTime = DateTime.Now.AddSeconds((int)sec),
                    //Tile for the reminder
                    Title = "Email Reminder",

                    //The desctription below the title
                    Content = "Click Here To Email Now",

                    //When the user taps the reminder
                    NavigationUri = new Uri("/Email.xaml?wake=true", UriKind.Relative),
                };

                ////Add the reminder
                ScheduledActionService.Add(myReminder);
            }
            
        }
    }
}