﻿using Ex4.Modele;
using Ex4.Views;
using Storm.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ex4.ViewModels{
	public class LoginViewModel : ViewModelBase{
        public string TitleLabel { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        private string _email;
        public string Email{
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password{
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public LoginViewModel(){
            LoginCommand = new Command(LoginClicked);
            RegisterCommand = new Command(RegisterClicked);
            TitleLabel = "Connexion";
        }

        private void LoginClicked(object _){
            OpenListPlace();
        }

        private async void OpenListPlace(){
            await RestService.Rest.LogIn(Email, Password);

            if (Token.IsInit()){
                await NavigationService.PushAsync<MainPage>(new Dictionary<string, object>());
            }
            else{
                await Application.Current.MainPage.DisplayAlert("Identifiants éronnés", "Vos identifiants sont invalides. Veuillez réiterer votre demande.", "OK");
            }

            // Vider le champ password dans tous les cas
            Password = "";
        }

        private void RegisterClicked(object _){
            OpenSignin();
        }

        private async void OpenSignin(){
            await NavigationService.PushAsync<Register>(new Dictionary<string, object>());
        }


        public override async Task OnResume()
        {
            await base.OnResume();
            Token.Destroy();
        }

    }
}