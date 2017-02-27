using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WorklightSample
{
	public partial class ResourceRequestPage : ContentPage
	{


		private DataPowerChallengeHandler datapowerChallengeHandler = null;
		
		
		public ResourceRequestPage()
		{
			InitializeComponent();
			getbalance.Clicked += OnGetBalanceButtonClicked;
			datapowerChallengeHandler = DataPowerChallengeHandler.GetInstance();
			datapowerChallengeHandler.BackPage = this;
			App.WorklightClient.client.RegisterChallengeHandler(datapowerChallengeHandler);
		}

	

		async void  OnGetBalanceButtonClicked(object sender, EventArgs e)
		{
		//	getbalance.IsEnabled = false;
			balancetext.Text = "";
			progresstext.IsVisible = true;
			var result = await App.WorklightClient.ProtectedInvokeAsync();
			progresstext.IsVisible = false;
			balancetext.Text = result.Response;
			getbalance.IsEnabled = true;	
		}
	}
}
