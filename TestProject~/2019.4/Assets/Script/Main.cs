using Unity.Advertisement.IosSupport;
using UnityEngine;
public class Main : MonoBehaviour
{
    private ATTrackingStatusBinding.AuthorizationTrackingStatus m_PreviousStatus;
    private bool m_Once;

    // Start is called before the first frame update
    private void Start()
    {
        var status = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
        Debug.LogFormat("Tracking status at start: {0}", status);
        m_PreviousStatus = status;

        SkAdNetworkBinding.SkAdNetworkUpdateConversionValue(0);
        SkAdNetworkBinding.SkAdNetworkRegisterAppForNetworkAttribution();
    }

    // Update is called once per frame
    private void Update()
    {
        if(!m_Once)
        {
            m_Once = true;
            ATTrackingStatusBinding.RequestAuthorizationTracking();
        }

        var status = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
        if(m_PreviousStatus != status)
        {
            m_PreviousStatus = status;
            Debug.LogFormat("Tracking status updated: {0}", status);
        }
    }
}
