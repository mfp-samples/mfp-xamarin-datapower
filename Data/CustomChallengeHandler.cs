using System;
using System.Collections.Generic;
using Worklight;
using Newtonsoft.Json.Linq;

namespace WorklightSample
{
	public class CustomChallengeHandler : SecurityCheckChallengeHandler
	{

		public LoginFormInfo LoginFormParameters{get;  set;}

		private bool authSuccess = false;
		private bool isAdapterAuth = false;
		private bool shouldSubmitLoginForm = false;
		private bool shouldSubmitAnswer = false; 

		public JObject challengeAnswer = null;

		public CustomChallengeHandler(string realm)
		{
			this.SecurityCheck = realm;
		}

		public override string SecurityCheck
		{
			get; set;
		}

		public  override JObject GetChallengeAnswer()
		{
			return challengeAnswer; 
		}

		public override bool ShouldSubmitChallengeAnswer()
		{
			return shouldSubmitAnswer;
		}

		public override void HandleChallenge(object challenge)
		{
			Console.WriteLine ("We were challenged.. so we are handling it");
			Dictionary<String,String > parms = new Dictionary<String, String> ();

			JObject creds = new JObject();
			creds.Add("username", "user");
			creds.Add("password", "user");
			challengeAnswer = creds; 
			shouldSubmitAnswer = true; 

		}

		public override void HandleSuccess(JObject identity)
		{
			Console.WriteLine("Success " + identity.ToString());
		}

		public override void HandleFailure(JObject error)
		{
			Console.WriteLine("Failure " + error.ToString());
		}
	}
}

