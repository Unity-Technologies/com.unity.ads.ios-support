#if UNITY_IOS

using System;
using System.Collections.Generic;
using UnityEngine.iOS;

namespace Unity.Advertisement.IosSupport
{
    using TrackingStatus = ATTrackingStatusBinding.AuthorizationTrackingStatus;

    public static class ATTracking
    {
        static Dictionary<int, TrackingStatus> Statuses = new Dictionary<int, TrackingStatus>()
        {
            { 0, TrackingStatus.NOT_DETERMINED},
            { 1, TrackingStatus.RESTRICTED},
            { 2, TrackingStatus.DENIED},
            { 3, TrackingStatus.AUTHORIZED}
        };
        public static bool SupportediOSVersion => new Version(Device.systemVersion) > new Version("14.5");

        public static bool IsTrackingAccepted()
        {
            // check with iOS to see if the user has accepted or declined tracking
            var status = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();

            if (SupportediOSVersion)
            {
                return status == TrackingStatus.AUTHORIZED;
            }
            else
            {
                return true;
            }
        }

        public static bool RequestAuthorizationTracking(Action<TrackingStatus> callback = null)
        {
            var authStatus = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();

            if (SupportediOSVersion)
            {
                if (authStatus == TrackingStatus.NOT_DETERMINED)
                {
                    ATTrackingStatusBinding.RequestAuthorizationTracking((requestStatus) =>
                    {
                        if (callback != null)
                            callback.Invoke(Statuses[requestStatus]);
                    });
                    return true;
                }
            }
            return false;
        }
    }
}
#endif