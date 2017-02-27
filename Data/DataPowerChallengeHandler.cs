using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json.Linq;
using Worklight;
using Xamarin.Forms;

namespace WorklightSample
{
	public class DataPowerChallengeHandler : GatewayChallengeHandler
	{
		private static String securityCheckName = "LtpaBasedSSO";
		private static DataPowerChallengeHandler ourInstance = new DataPowerChallengeHandler(securityCheckName);
		private Dictionary<String, String> parms;
		public static ManualResetEvent waitForLoginChallenge = new ManualResetEvent(false);
	

		public static DataPowerChallengeHandler GetInstance()
		{
			return ourInstance;
		}

		private DataPowerChallengeHandler(String realm)
		{
			SecurityCheck = realm;
		}

		public override bool canHandleResponse(WorklightResponse response)
		{
			if (response == null
			    || response.ResponseText == null ||
			    response.ResponseText.IndexOf("j_security_check") == -1)
			{
				return false;
			}
			return true;
		}

		public override LoginFormInfo GetLoginFormParameters()
		{
			return LoginFormInfo;
		}


		public Page BackPage
		{
			get;
			set;
		}

		public void SubmitLogin(String userName, String password)
		{	
			parms = new Dictionary<string, string>();
			parms.Add("j_username", userName);
			parms.Add("j_password", password);
			LoginFormInfo = new LoginFormInfo("/j_security_check", parms, null, 0, "post");
			SubmitLoginForm = true;
			SubmitSuccess = true;
			//ResourceRequestPage.ShowLoginLayout(true);
			//ResourceRequestPage.ShowBalanceLayout(false);
			waitForLoginChallenge.Set();

		}

		public string SecurityCheck
		{
			get; set;
		}

		public override string GetRealm()
		{
			return SecurityCheck;
		}

		private LoginFormInfo LoginFormInfo
		{
			get;
			set;
		}

		public bool ShouldSubmitAnswer
		{
			get;
			set;
		}

		private bool SubmitLoginForm
		{
			get;
			set;
		}

		public override void HandleChallenge(WorklightResponse challenge)
		{
			waitForLoginChallenge.Reset();

			Device.BeginInvokeOnMainThread(() =>
		   {
				App.Current.MainPage = new NavigationPage(new LoginPage(BackPage));

		   });

			//ResourceRequestPage.ShowLoginLayout(true);
			//ResourceRequestPage.ShowBalanceLayout(false);
			waitForLoginChallenge.WaitOne();
		}

		public override void OnFailure(WorklightResponse response)
		{
			SubmitSuccess = false;
		}

		public bool SubmitSuccess
		{
			get;
			set;
		}

		public override void OnSuccess(WorklightResponse challenge)
		{
			SubmitSuccess = true;
		}

		public void SetSubmitCancelled()
		{
			SubmitSuccess = false; 
			waitForLoginChallenge.Set();
		}
			

		public override bool ShouldSubmitLoginForm()
		{
			return SubmitLoginForm;
		}

		public override bool ShouldSubmitSuccess()
		{
			return SubmitSuccess;
		}

		//public override bool ShouldSubmitChallengeAnswer()
		//{
		//	return ShouldSubmitAnswer;
		//}

		//public override JObject GetChallengeAnswer()
		//{
		//	return challengeAnswer;
		//}


	}
}
