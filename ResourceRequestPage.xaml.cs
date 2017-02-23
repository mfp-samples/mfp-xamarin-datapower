using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WorklightSample
{
	public partial class ResourceRequestPage : ContentPage
	{

		private static StackLayout layout = null;
		private static StackLayout balancelayoutpanel = null;
		private DataPowerChallengeHandler datapowerChallengeHandler = null;
		
		
		public ResourceRequestPage()
		{
			InitializeComponent();
			getbalance.Clicked += OnGetBalanceButtonClicked;
			login.Clicked += OnLoginClicked;
			cancel.Clicked += OnCancelClicked;
			layout = loginlayout;
			balancelayoutpanel = balancelayout;
			datapowerChallengeHandler = DataPowerChallengeHandler.GetInstance();
			App.WorklightClient.client.RegisterChallengeHandler(datapowerChallengeHandler);
		}

	void OnCancelClicked(object sender, EventArgs e)
	{
			datapowerChallengeHandler.SetSubmitCancelled();
			ShowLoginLayout(false);
			ShowBalanceLayout(true);
			progresstext.IsVisible = false;
			getbalance.IsEnabled = true;

	}

		public static void ShowLoginLayout(bool visible)
		{



			Device.BeginInvokeOnMainThread(() =>
		   {
			   layout.IsVisible = visible;
			

   			});
		}

		public static void ShowBalanceLayout(bool visible)
		{
			
			Device.BeginInvokeOnMainThread(() =>
		   {
				balancelayoutpanel.IsVisible = visible;


		   });
		}

	void OnLoginClicked(object sender, EventArgs e)
	{
			
			datapowerChallengeHandler.SubmitLogin(UserName.Text, Password.Text);
			ShowLoginLayout(false);
			ShowBalanceLayout(true);
		
		}

		async void  OnGetBalanceButtonClicked(object sender, EventArgs e)
		{
			getbalance.IsEnabled = false;
			balancetext.Text = "";
			progresstext.IsVisible = true;
			var result = await App.WorklightClient.ProtectedInvokeAsync();
			progresstext.IsVisible = false;
			balancetext.Text = result.Response;
			getbalance.IsEnabled = true;	
		}



	}
}
