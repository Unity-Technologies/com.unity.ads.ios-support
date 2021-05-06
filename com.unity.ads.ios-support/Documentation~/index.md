# Using this package

This package supports Apple's SKAdNetwork and AppTrackingTransparency frameworks for your made-with-Unity iOS application, by aggregating proper ad network IDs and providing access to relevant Apple developer APIs.

For more information about iOS 14 technical integration, including this package's support functionality, please see the full [iOS 14 technical documentation](https://unityads.unity3d.com/help/monetization/ios14).

## Installing the package

### From the public Github repository

1. Go to the [public repo page on Github](https://github.com/Unity-Technologies/com.unity.ads.ios-support).
1. Download that repo to your hard drive.
2. In the Unity Editor, open the [Unity Package Manager](https://docs.unity3d.com/Manual/Packages.html) window. 
3. Click the **+** button and select **Add package from disk...**.
4. Navigate to the location where you downloaded the repo and select the iOS14 Support package (_..\com.unity.ads.ios-support-master\com.unity.ads.ios-support\package.json_) to install the package. If successful, the iOS14 Support package will appear in the package manager list (note that you must have **All packages** selected to view it). 

### From Unity Package Manager

1. In the Unity Editor, select **Window** > **Package** Manager to open the Package Manager.
2. Select the **Advertisement** package from the list, then select the most recent verified version.
3. Click the **Install** or **Update** button.

## Apple developer API extensions

This package provides access to the following Apple developer APIs:

```
public static void SkAdNetworkUpdateConversionValue(int conversionValue)
```
This method allows you to [update the attribution conversion value](https://developer.apple.com/documentation/storekit/skadnetwork/3566697-updateconversionvalue?language=objc).

```
SkAdNetworkRegisterAppForNetworkAttribution()
```
This method allows you to [register for attribution](https://developer.apple.com/documentation/storekit/skadnetwork/2943654-registerappforadnetworkattributi?language=objc).

```
public static void RequestAuthorizationTracking()
```
This method allows you to [request the user permission dialogue](https://developer.apple.com/documentation/apptrackingtransparency/attrackingmanager/3547037-requesttrackingauthorization).

```
public static AuthorizationTrackingStatus GetAuthorizationTrackingStatus()
```
This method allows you to check the app tracking transparency (ATT) [authorization status](https://developer.apple.com/documentation/apptrackingtransparency/attrackingmanager/3547038-trackingauthorizationstatus).

## Sample Project

You can import a Context Screen sample scene and assets from the Package Manager screen for this package (Unity 2019.1 and newer).

The SampleProject~ folder included in the Github public repo is a complete Unity project, compatible with Unity 2018.4.33f1 and up.

This sample provides a fully customizable example of a context screen you could use to give context to users before showing the native App Tracking Transparency dialog.
