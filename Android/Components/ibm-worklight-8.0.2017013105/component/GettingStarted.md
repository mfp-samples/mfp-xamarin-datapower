## More Information

1. [IBM MobileFirst Platform Foundation home page](http://mobilefirstplatform.ibmcloud.com)
2. [IBM MobileFirst Platform Foundation Knowledge Center](https://www.ibm.com/support/knowledgecenter/SSHS8R_8.0.0/wl_welcome.html)
3.  The C# API guide is bundled inside the component
4.  The sample Xamarin solution for Android and iOS is bundled in the component

## Pre-requisites for a New Solution

 1.  You need an instance of the IBM MobileFirst Server on the development machine or an instance of MobileFirst Foundation on IBM Bluemix.  Install MobileFirst CLI (Command line Interface) from the [ IBM Worklight download page](https://mobilefirstplatform.ibmcloud.com/downloads/)
 2.  Create a Xamarin Solution
 3.  Add a Android and/or iOS project in the solution
 4.  Add this component to the project 
 5. The MobileFirst SDK needs a property file that contains information on how to connect to the Worklight Server. This information is pre-populated with some data (like the IP address of the server, application name etc) in the Worklight project the add-in created. Add it to the Xamarin Application projects.
  1. Android: Add the < Solution folder>\worklight\< SolutionName>\apps\android< SolutionName>\mfpclient.properties file to the Xamarin Android **Assets** folder and set the build action to **AndroidAsset**. (e.g: \Xtest\worklight\Xtest\apps\androidXtest\mfpclient.properties)
  2. iOS: Add the < Solution folder>\worklight\< SolutionName>\apps\iOS< SolutionName>\worklight.plist file to the Xamarin iOS **resources** folder and set the build action to **bundleResource** (e.g: \Xtest\worklight\Xtest\apps\iOSXtest\mfpclient.plist)
 8. To use the JSONStore API, Worklight SDK needs some native files. These need to be added to the project.
   1. Android: Add to the **Assets** folder the files from < Solution folder>\worklight\< SolutionName>\apps\android< SolutionName>/jsonstore/assets . Set the **BuildAction** for these files to **AndroidAsset**.
   1. iOS: No action needed.

**Note:** 

When you add the Worklight Xamarin Component to your project, the following DLLs get referenced in the project

1. Android:   
   * MobileFirst.Xamarin.Android.dll
   * Worklight.Android.dll
   * MobileFirst.Android.JSONStore.dll
   * MobileFirst.Android.Push
2.  iOS :  
   * MobileFirst.Xamarin.iOS.dll
   * Worklight.iOS.dll
   * MobileFirst.iOS.JSONStore.dll
   * MobileFirst.iOS.Push

## Sample Application Quickstart

###Pre-requisites
 

1.  You need a instance of the Worklight Server on the development machine.  Install Worklight CLI (Command line Interface) from the [ IBM Worklight download page](http://www.ibm.com/developerworks/mobile/worklight/download/cli.html)

###Open the samples in Xamarin Studio:

1. Open Xamarin Studio.
2. Create a new Solution and add a project to it
3. Add this component from the component store
4. Double-click on the IBM MobileFirst Component
5. Navigate to the **Samples** tab
3. Open the sample

###Prepare the MobileFirst Server

1.  From the add-in - click on **Start Server** - 1. this command might take some time the first time you run it.
2.  Click on **Open Console** and log into the console, by using the following credentials: username =  admin, and password =  admin
3.  You now see two apps and a SampleHTTPAdapter in the console
4.  Run the app in the simulator/real device


###Configure and run the iOS Sample

1. Right-click the **WorklightSample.iOS** project and select **Set As Startup Project**
2. Expand the **Worklightsample.iOS** project and double-click the file **worklight.plist** to open it in the property value editor.
3. In the property value editor find the entry for "host" and update its value to the "Server host" value.
4. Run the sample project by clicking Xamarin menu **Run > Start Debugging**

###Using JSONStore in the Android Sample
 1. To use the JSONStore API, Worklight SDK needs some native files. These need to be added to the project.
   1. Android: Copy the files under < Solution folder>\worklight\< SolutionName>\apps\android< SolutionName>/jsonstore/assets to the **Assets** folder. Set the **BuildAction** for these files to **AndroidAsset**.
   1. iOS: No action needed.

##Additional Info

###Appendix I

To setup a Xamarin development environment with MobileFirst Foundation IBM Bluemix.

 1. Login to [bluemix.net](https://bluemix.net) and create an instance of [MobileFirst Foundation service](https://console.ng.bluemix.net/catalog/services/mobile-foundation/).
 2. Go through the wizard to start your server
 3. Create a new application. Select the environment and accordingly provide the bundle if of your app (iOS) or package name of your app (Android).
 4. If your application requires any adapters, build and deploy the adapters from the console.

### Appendix II
Documentation Links

1. [IBM MobileFirst Knowledge Center](https://www.ibm.com/support/knowledgecenter/SSHS8R_8.0.0/wl_welcome.html)
2. [IBM MobileFirst Developer Center] (http://mobilefirstplatform.ibmcloud.com)
3. [IBM MobileFirst Command Line Interface Reference](https://www.ibm.com/support/knowledgecenter/SSHS8R_8.0.0/com.ibm.worklight.admin.doc/admin/c_administering_ibm_worklight_applications_through_command_line.html)