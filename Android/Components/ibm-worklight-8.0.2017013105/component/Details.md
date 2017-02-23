## IBM MobileFirst SDK

With the IBM MobileFirst Platform Foundation SDK, C# developers can build rich native enterprise grade mobile apps for iOS and Android devices by using IBM MobileFirst Platform Server.

*Note:  IBM MobileFirst Platform Foundation was earlier called IBM Worklight Foundation.*

#### Key Highlights
* **Do it all by using C#**
* Single, secure point of integration, management, and deployment that supports the full mobile app lifecycle
* Access your enterprise backend using MobileFirst Platform Adapters
* Enterprise grade security for your mobile applications
* Application management and version control
* Leverage rich analytics support of MobileFirst Platform
* Simplified push notification management service
* Possibility to use your own strongly-typed C# objects and async/await patterns.
* A unified C#API for iOS and Android.

###Dive In

A unified API is provided for iOS and Android. You can write most of the IBM MobileFirst Platform related code in a common shared project that will be used in both the Android project and the iOS project. You can write all the asynchronous code using async/await and event listeners to make your app responsive.

The following code is a simplified subset of the code that is located in the samples. This example show how you can call an IBM MobileFirst adapter that returns a feed of news articles and is formatted for pretty printing in platform agnostic code.

In the Android Activity, instantiate the Android specific     WorklightClient object.

```
		
		public class MainActivity : Activity
		{
			IWorklightClient client = Worklight.Xamarin.Android.WorklightClient.CreateInstance (this);
		}
	
```

In the iOS UIViewController instantiate the iOS specific WorklightClient

```
	
	public partial class Xtest_iOSViewController : UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			IWorklightClient client =  Worklight.Xamarin.iOS.WorklightClient.CreateInstance ();
		}
	}
	
```

After you created the instance of IWorklightClient, you can use it to write platform agnostic common code. You first connect to the MobileFirst Server, and register a Challenge handler for authentication. As you do so, you can write to the local logging as well as the server-based analytics logging.

```

		//all this is common code
		public async Task<WorklightResponse> Connect()
 		{
 			string appRealm = "SampleAppRealm";
			ChallengeHandler customCH = new CustomChallengeHandler (appRealm);
			client.RegisterChallengeHandler(customCH);
			WorklightResponse task = await client.Connect ();
			//lets log to the local client (not server)
			client.Logger("Xamarin").Trace ("connection");
			//write to the server the connection status
			client.Analytics.Log ("Connect response : " + task.Success);
			return task;
		}

```

Then call an adapter procedure

```
		
		//Common code
		StringBuilder uriBuilder = new StringBuilder()
					.Append("/adapters")
					.Append("/ResourceAdapter") //Name of the adapter
					.Append("/balance");    // Name of the adapter procedure

		WorklightResourceRequest rr = client.ResourceRequest(new Uri(uriBuilder.ToString(),UriKind.Relative,
			"GET",
			"accessRestricted");

		WorklightResponse resp = await rr.Send();

		result.Success = resp.Success;
		result.Response = resp.Success ? "Your account balance is " + resp.ResponseText : resp.Message; 

```

For more information see the sample inside the component for more details. 

