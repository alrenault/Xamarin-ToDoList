﻿using Ex4.ViewModels;
using Storm.Mvvm.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ex4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPlace : BaseContentPage
    {
		public NewPlace ()
		{
			InitializeComponent ();
            BindingContext = new NewPlaceViewModel();

        }
    }
}