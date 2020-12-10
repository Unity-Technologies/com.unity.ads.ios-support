using System.Collections.Generic;
using UnityEngine;

namespace Unity.Advertisement.IosSupport.Editor
{
    internal interface ISkAdNetworkParser
    {
        string GetExtension();
        HashSet<string> ParseSource(ISkAdNetworkSource source);
    }
}
