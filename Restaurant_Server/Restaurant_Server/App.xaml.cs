﻿using Restaurant_Server.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant_Server
{
    public partial class App : Application
    {
        public static LicentaDB Database { get; private set; }
        public App()
        {
            InitializeComponent();

            Database = new LicentaDB(new RestService_S());
            MainPage = new NavigationPage( new MainPage());
            //MainPage = new AddFel();
            //MainPage = new Page1();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
