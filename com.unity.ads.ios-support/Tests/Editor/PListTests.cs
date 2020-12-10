#if UNITY_2018_1_OR_NEWER && UNITY_IOS
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEditor.iOS.Xcode;

namespace Unity.Advertisement.IosSupport.Editor.Tests
{
    public class PListTests
    {
        [SetUp]
        public void BeforeEach()
        {
            File.Copy("Assets/Info_Test.plist", "Assets/Info.plist");
        }

        [TearDown]
        public void AfterEach()
        {
            File.Delete("Assets/Info.plist");
        }

        [Test]
        [TestCase("Assets/", "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n<plist version=\"1.0\">\n  <dict>\n    <key>CFBundleDevelopmentRegion</key>\n    <string>en</string>\n    <key>CFBundleDocumentTypes</key>\n    <dict>\n      <key>SKAdNetworkItems</key>\n      <dict />\n    </dict>\n    <key>CFBundleExecutable</key>\n    <string>$(EXECUTABLE_NAME)</string>\n    <key>CFBundleIdentifier</key>\n    <string>$(PRODUCT_BUNDLE_IDENTIFIER)</string>\n    <key>CFBundleInfoDictionaryVersion</key>\n    <string>6.0</string>\n    <key>CFBundleName</key>\n    <string>$(PRODUCT_NAME)</string>\n    <key>CFBundlePackageType</key>\n    <string>BNDL</string>\n    <key>CFBundleShortVersionString</key>\n    <string>1.0</string>\n    <key>CFBundleSignature</key>\n    <string>????</string>\n    <key>CFBundleVersion</key>\n    <string>1</string>\n    <key>NSAppTransportSecurity</key>\n    <dict>\n      <key>NSAllowsArbitraryLoads</key>\n      <true />\n    </dict>\n    <key>SKAdNetworkItems</key>\n    <array>\n      <dict>\n        <key>SKAdNetworkIdentifier</key>\n        <string>4DZT52R2T5.skadnetwork</string>\n      </dict>\n      <dict>\n        <key>SKAdNetworkIdentifier</key>\n        <string>123456.skadnetwork</string>\n      </dict>\n    </array>\n  </dict>\n</plist>\n")]
        public void WriteSkAdNetworkIdsToInfoPlist(string rootFolder, string expectedContents)
        {
            var ids = new HashSet<string> { "4DZT52R2T5.skadnetwork", "123456.skadnetwork" };
            PostProcessBuildPlist.WriteSkAdNetworkIdsToInfoPlist(ids, rootFolder);
            Assert.That(File.ReadAllText(rootFolder + "Info.plist"), Is.EqualTo(expectedContents), "Info.plist was not updated as expected");
        }

        [Test]
        [TestCase("4DZT52R2T5.skadnetwork", true)]
        [TestCase("invalid.skadnetwork", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void PlistContainsAdNetworkId(string adNetworkId, bool expectedValue)
        {
            var plistArray = new PlistElementArray();
            plistArray.AddDict().SetString("SKAdNetworkIdentifier", "4DZT52R2T5.skadnetwork");
            Assert.That(PostProcessBuildPlist.PlistContainsAdNetworkId(plistArray, adNetworkId), Is.EqualTo(expectedValue));
        }
    }
}
#endif
