using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EraApp.ServiceReference1;
using Era.Core;

namespace EraApp
{
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //CookiesUtils.SetCookie("user", txtUserName.Text,TimeSpan.FromDays(1));
            //CookiesUtils.SetCookie("pwd", txtPassword.Password,TimeSpan.FromDays(1));
            ServiceReference1.Service1Client client
                = new Service1Client();
            client.GetLoginbyNamePassCompleted
                += (obj, e1) =>
                {
                    if (e1.Result.BoolValue)
                    {
                        CookiesUtils.SetCookie("user", txtUserName.Text);
                        CookiesUtils.SetCookie("pwd", txtPassword.Password);
                        string s = CookiesUtils.GetCookie("user");
                        MessageBox.Show(s);

                    }

                };
            client.GetLoginbyNamePassAsync(txtUserName.Text,
                                           txtPassword.Password);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            txtUserName.Text = CookiesUtils.GetCookie("user")??string.Empty;
            txtPassword.Password = CookiesUtils.GetCookie("pwd") ?? string.Empty;
            MessageBox.Show(HtmlPage.Document.Cookies);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ChinaCalendar cc = new ChinaCalendar();
            //this.textBlock3.Text = cc.GetDateTime("甲子|乙亥|庚申|丁亥").ToString("yyyy-MM-dd HH:mm:ss");
            this.textBlock3.Text = cc.GetDateTime(textBox1.Text).ToString("yyyy-MM-dd HH:mm:ss");
        }

    }
}