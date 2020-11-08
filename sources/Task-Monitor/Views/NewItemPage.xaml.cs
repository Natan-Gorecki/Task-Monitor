using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TaskMonitor.Models;
using TaskMonitor.ViewModels;

namespace TaskMonitor.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Task Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}