using System;
using UnityEngine;
using System.Runtime.InteropServices;

namespace Unity.Advertisement.IosSupport
{
    using AOT;
    public class ATTrackingStatusBinding
    {
#if UNITY_IOS
        [DllImport("__Internal")] private static extern void InterfaceTrackingAuthorizationRequest(RequestAuthorizationTrackingCompleteHandler callback);
        [DllImport("__Internal")] private static extern int InterfaceGetTrackingAuthorizationStatus();
#endif
        public delegate void RequestAuthorizationTrackingCompleteHandler(int status);
        private static RequestAuthorizationTrackingCompleteHandler _requestAuthorizationTrackingCompleteCallback = null;

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
            RequestAuthorizationTracking(null);
        }

        /// <summary>
        /// This method allows you to <a href="https://developer.apple.com/documentation/apptrackingtransparency/attrackingmanager/3547037-requesttrackingauthorization">request the user permission dialogue</a>.
        /// </summary>
        public static void RequestAuthorizationTracking(RequestAuthorizationTrackingCompleteHandler callback)
        {
#if UNITY_IOS
            if (Application.platform != RuntimePlatform.IPhonePlayer) return;
            if (_requestAuthorizationTrackingCompleteCallback != null)
            {
                throw new InvalidOperationException("App tracking transparency request is already triggered and awaiting completion");
            }
            _requestAuthorizationTrackingCompleteCallback = callback;

            InterfaceTrackingAuthorizationRequest(AppTransparencyTrackingRequestCompleted);
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
        
        [MonoPInvokeCallback(typeof(RequestAuthorizationTrackingCompleteHandler))]
        public static void AppTransparencyTrackingRequestCompleted(int status)
        {
            _requestAuthorizationTrackingCompleteCallback?.Invoke(status);
            _requestAuthorizationTrackingCompleteCallback = null;
        }
        
    }
}
