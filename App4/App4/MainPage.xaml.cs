using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var path = ApplicationData.Current.LocalFolder.Path + @"\Users.db";
                var db = new SQLiteAsyncConnection(path);
                await db.CreateTableAsync<User>();
            }
            catch (Exception)
            { }

            //Button_Click_1.visibility = Visibility.Collapsed;
        }
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var path = ApplicationData.Current.LocalFolder.Path + @"\Users.db";
            var db = new SQLiteAsyncConnection(path);
            var data = new User
            {
                name=txt_name.Text,
                email=txt_email.Text
            
            };
            int i = await db.InsertAsync(data);
           
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string result = "";
            var path = ApplicationData.Current.LocalFolder.Path + @"\Users.db";
            var db = new SQLiteAsyncConnection(path);
            List<User> all = await db.QueryAsync<User>("Select* from Users");
            var count = all.Any() ? all.Count : 0;

            foreach (var item in all)
            {
                result += "email" + item.email.ToString() + "\nFstname" + item.name+"\n";
            }

            MessageDialog msg = new MessageDialog(result.ToString());
            await msg.ShowAsync();
        }
    }
}
