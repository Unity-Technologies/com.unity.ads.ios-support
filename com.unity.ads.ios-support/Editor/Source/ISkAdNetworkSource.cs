using System.IO;
using UnityEngine;

namespace Unity.Advertisement.IosSupport.Editor
{
    internal interface ISkAdNetworkSource
    {
        string Path { get; }
        Stream Open();
    }
}
