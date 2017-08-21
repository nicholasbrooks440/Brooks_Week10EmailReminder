using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Brooks_Week10EmailReminder
{
    public partial class Email : PhoneApplicationPage
    {   
        public Email()
        {            
            InitializeComponent();
            
           
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Use the Email Task
            var task = new EmailComposeTask();
            task.Show();
        }
    }
}