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
		public delegate void RequestAuthorizationTrackingCompleteHandler();
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
        /// Takes a callback delegate that will be invoked when the request is completed on the native side, it will also be invoked if ATT is not available.
		/// </summary>
        /// <param name="completedCallback">The callback to be invoked when the request is completed</param>
        public static void RequestAuthorizationTracking(RequestAuthorizationTrackingCompleteHandler completedCallback)
		{
			if (_requestAuthorizationTrackingCompleteCallback != null)
			{
				throw new InvalidOperationException("app tracking transparency is already triggered and awaiting completion");
			}
			_requestAuthorizationTrackingCompleteCallback = completedCallback;

			if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
#if UNITY_IOS
                InterfaceTrackingAuthorizationRequest(AppTransparencyTrackingRequestCompleted);
#endif
            }
			else
			{
				AppTransparencyTrackingRequestCompleted();
			}
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

        /// <summary>
        /// The static callback that will be invoked from native code and invoke the callback passed in <see cref="RequestAuthorizationTracking"/>
        /// </summary>
		[MonoPInvokeCallback(typeof(RequestAuthorizationTrackingCompleteHandler))]
        public static void AppTransparencyTrackingRequestCompleted()
		{
			_requestAuthorizationTrackingCompleteCallback?.Invoke();
			_requestAuthorizationTrackingCompleteCallback = null;
		}
	}
}
