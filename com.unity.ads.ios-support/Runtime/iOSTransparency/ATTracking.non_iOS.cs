#if !UNITY_IOS

using System;

namespace Unity.Advertisement.IosSupport
{
    using TrackingStatus = ATTrackingStatusBinding.AuthorizationTrackingStatus;

    public static class ATTracking
    {
        public static bool SupportediOSVersion => false;
        public static bool IsTrackingAccepted()
        {
            return true;
        }
        public static bool RequestAuthorizationTracking(Action<TrackingStatus> callback = null)
        {
            // Do nothing
            return false;
        }
    }
}
#endif