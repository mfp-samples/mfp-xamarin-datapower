using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WorklightSample
{
	public partial class LoginPage : ContentPage

	{
	private Page backPage;	

		public LoginPage(Page backPage)
		{
			InitializeComponent();
			this.backPage = backPage;
		}

		void Login_Clicked(object sender, System.EventArgs e)
		{
			DataPowerChallengeHandler datapowerChallengeHandler = DataPowerChallengeHandler.GetInstance();
			datapowerChallengeHandler.SubmitLogin(UserName.Text, Password.Text);
			//Navigation.PopAsync();
			App.Current.MainPage = datapowerChallengeHandler.BackPage;
		}

		void Cancel_Clicked(object sender, System.EventArgs e)
		{
			
			DataPowerChallengeHandler.GetInstance().SetSubmitCancelled();
			App.Current.MainPage = DataPowerChallengeHandler.GetInstance().BackPage;
		}
	}
}
