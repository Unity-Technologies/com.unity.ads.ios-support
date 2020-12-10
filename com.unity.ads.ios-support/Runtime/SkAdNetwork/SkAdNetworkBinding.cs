using System;
using UnityEngine;
using System.Runtime.InteropServices;

namespace Unity.Advertisement.IosSupport
{
    public class SkAdNetworkBinding
    {
#if UNITY_IOS
        [DllImport("__Internal")] private static extern void InterfaceSkAdNetworkUpdateConversionValue(int conversionValue);
        [DllImport("__Internal")] private static extern void InterfaceSkAdNetworkRegisterAppForNetworkAttribution();
#endif

        /// <summary>
        /// This method allows you to <a href="https://developer.apple.com/documentation/storekit/skadnetwork/3566697-updateconversionvalue?language=objc">update the attribution conversion value</a>.
        /// </summary>
        public static void SkAdNetworkUpdateConversionValue(int conversionValue)
        {
#if UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                InterfaceSkAdNetworkUpdateConversionValue(conversionValue);
            }
#endif
        }

        /// <summary>
        /// This method allows you to <a href="https://developer.apple.com/documentation/storekit/skadnetwork/2943654-registerappforadnetworkattributi?language=objc">register for attribution</a>.
        /// </summary>
        public static void SkAdNetworkRegisterAppForNetworkAttribution()
        {
#if UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                InterfaceSkAdNetworkRegisterAppForNetworkAttribution();
            }
#endif
        }
    }
}
