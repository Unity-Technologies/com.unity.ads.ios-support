using UnityEngine;

namespace Unity.Advertisement.IosSupport.Samples
{
    [ExecuteInEditMode]
    public class AutoSwitchLayout : MonoBehaviour
    {
        public Transform portraitModeLayoutTransform;
        public Transform landscapeModeLayoutTransform;

        float m_PreviousAspectRatio;

        private void Update()
        {
            var aspectRatio = 1f * Screen.width / Screen.height;

            if (!Mathf.Approximately(aspectRatio, m_PreviousAspectRatio) 
                && portraitModeLayoutTransform
                && landscapeModeLayoutTransform)
            {
                m_PreviousAspectRatio = aspectRatio;

                if (aspectRatio > 1f)
                {
                    landscapeModeLayoutTransform.gameObject.SetActive(true);
                    portraitModeLayoutTransform.gameObject.SetActive(false);
                }
                else
                {
                    portraitModeLayoutTransform.gameObject.SetActive(true);
                    landscapeModeLayoutTransform.gameObject.SetActive(false);
                }
            }
        }
    }
}
