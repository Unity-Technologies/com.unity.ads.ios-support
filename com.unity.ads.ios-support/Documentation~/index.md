# Using the iOS 14 support package
This package supports Apple's SKAdNetwork and AppTrackingTransparency frameworks for your made-with-Unity iOS application, by aggregating proper ad network IDs and providing access to relevant Apple developer APIs.

## Installing the package
1. Download this repo to your hard drive.
2. In the Unity Editor, open the [Unity Package Manager](https://docs.unity3d.com/Manual/Packages.html) window. 
3. Click the **+** button and select **Add package from disk...**.
4. Navigate to the location where you downloaded the repo and select the iOS14 Support package (_..\com.unity.ads.ios-support-master\com.unity.ads.ios-support\package.json_) to install the package. If successful, the iOS14 Support package will appear in the package manager list (note that you must have **All packages** selected to view it). 

## SKAdNetwork ID support
The iOS14 Support package will automatically aggregate an updated [list of advertising sources](https://unityads.unity3d.com/help/ios/skadnetwork-ids) in your game's [_Info.plist_](https://developer.apple.com/documentation/bundleresources/information_property_list) file when you build the application: 

1. [Build](https://docs.unity3d.com/Manual/BuildSettings.html) your project for iOS.
2. Check the resulting *Info.plist* file to ensure that your `SKAdNetworkItems` are as expected. If necessary, manually add any additional `SKAdNetworkIdentifier` dictionaries to the array.

For more information, see documentation on [modifying the properties list](https://unityads.unity3d.com/help/ios/integration-guide-ios#modifying-the-properties-list).
