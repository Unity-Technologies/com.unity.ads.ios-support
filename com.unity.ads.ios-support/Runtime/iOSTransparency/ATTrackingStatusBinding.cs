using System;
using UnityEngine;
using System.Runtime.InteropServices;

namespace Unity.Advertisement.IosSupport
{
    public class ATTrackingStatusBinding
    {
#if UNITY_IOS
        [DllImport("__Internal")] private static extern void InterfaceTrackingAuthorizationRequest();
        [DllImport("__Internal")] private static extern int InterfaceGetTrackingAuthorizationStatus();
#endif

        /// <summary>
        /// The enumerated states of an authorization tracking request.
        /// </summary>
        public enum AuthorizationTrackingStatus
        {
            NOT_DETERMINED = 0,
            RESTRICTED,
            DENIED,
            AUTHORIZED
        }

        /// <summary>
        /// This method allows you to <a href="https://developer.apple.com/documentation/apptrackingtransparency/attrackingmanager/3547037-requesttrackingauthorization">request the user permission dialogue</a>.
        /// </summary>
        public static void RequestAuthorizationTracking()
        {
#if UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                InterfaceTrackingAuthorizationRequest();
            }
#endif
        }

        /// <summary>
        /// This method allows you to check the app tracking transparency (ATT) <a href="https://developer.apple.com/documentation/apptrackingtransparency/attrackingmanager/3547038-trackingauthorizationstatus">authorization status</a>.
        /// </summary>
        /// <returns>An <c>AuthorizationTrackingStatus</c> enum value.</returns>
        public static AuthorizationTrackingStatus GetAuthorizationTrackingStatus()
        {
#if UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                return (AuthorizationTrackingStatus)InterfaceGetTrackingAuthorizationStatus();
            }
#endif
            return AuthorizationTrackingStatus.NOT_DETERMINED;
        }
    }
}
