#if UNITY_2018_1_OR_NEWER && UNITY_IOS
using NUnit.Framework;
using UnityEngine;

namespace Unity.Advertisement.IosSupport.Editor.Tests
{
    public class SkAdNetworkParserTests
    {
        [Test]
        [Category("WorksInIsolation")]
        [TestCase(SkAdNetworkFileExtension.XML)]
        [TestCase(SkAdNetworkFileExtension.JSON)]
        [TestCase(SkAdNetworkFileExtension.NONE)]
        public void ParserHandlesExtensionType(string parserType)
        {
            Assert.That(SkAdNetworkParser.GetParser(parserType).GetExtension(), Is.EqualTo(parserType), "GetExtension did not match the expected value");
        }

        [Test]
        [TestCase(SkAdNetworkFileExtension.XML, "Assets/SkAdNetworks.xml", new[] {"4DZT52R2T5.skadnetwork", "123456.skadnetwork"})]
        [TestCase(SkAdNetworkFileExtension.JSON, "Assets/SkAdNetworks.json", new[] {"4DZT52R2T5.skadnetwork", "bvpn9ufa9b.skadnetwork"})]
        [TestCase(SkAdNetworkFileExtension.JSON, "Assets/AdditionalTestData/SkAdNetworks.json", new[] {"4FZDC2EVR5.skadnetwork", "V72QYCH5UU.skadnetwork"})]
        [TestCase(SkAdNetworkFileExtension.NONE, "Assets/SkAdNetworks", new[] {"238da6jt44.skadnetwork", "488r3q3dtq.skadnetwork", "TL55SBB4FM.skadnetwork", "4DZT52R2T5.skadnetwork", "wg4vff78zm.skadnetwork", "YCLNXRL5PM.skadnetwork", "zmvfpc5aq8.skadnetwork", "ydx93a7ass.skadnetwork", "44jx6755aq.skadnetwork", "44n7hlldy6.skadnetwork", "4FZDC2EVR5.skadnetwork", "c6k4g5qg8m.skadnetwork", "v79kvwwj4g.skadnetwork", "424M5254LK.skadnetwork", "3sh42y64q3.skadnetwork", "mlmmfzh3r3.skadnetwork", "9T245VHMPL.skadnetwork", "av6w8kgt66.skadnetwork", "WZMMZ9FP6W.skadnetwork", "4PFYVQ9L8R.skadnetwork", "5lm9lj6jb7.skadnetwork", "4468km3ulz.skadnetwork", "3RD42EKR43.skadnetwork", "8s468mfl3y.skadnetwork", "hs6bdukanm.skadnetwork", "prcb7njmu6.skadnetwork", "lr83yxwka7.skadnetwork", "ppxm28t8ap.skadnetwork", "M8DBW4SV7C.skadnetwork", "v72qych5uu.skadnetwork", "bvpn9ufa9b.skadnetwork", "7UG5ZH24HU.skadnetwork", "KBD757YWX3.skadnetwork", "22mmun2rn5.skadnetwork", "9RD848Q2BZ.skadnetwork", "5a6flpkh64.skadnetwork", "2U9PT9HC89.skadnetwork", "GLQZH8VGBY.skadnetwork", "t38b2kh725.skadnetwork", "F38H382JLK.skadnetwork", "f73kdq92p3.skadnetwork", "cstr6suwn9.skadnetwork"})]
        public void ParserCanParseSourceAsExpected(string parserType, string sourceDataPath, string[] expectedResults)
        {
            Assert.That(SkAdNetworkParser.GetParser(parserType).ParseSource(new SkAdNetworkLocalSource(sourceDataPath)), Is.EquivalentTo(expectedResults), "Parser did not return the expected results");
        }

        [Test]
        [TestCase(SkAdNetworkFileExtension.XML, "Assets/SkAdNetworks_Bad1.xml", new[] {"123456.skadnetwork"})]    //Invalid Key
        [TestCase(SkAdNetworkFileExtension.JSON, "Assets/SkAdNetworks_Bad1.json", new[] {"bvpn9ufa9b.skadnetwork"})]    //Invalid Key
        [TestCase(SkAdNetworkFileExtension.XML, "Assets/SkAdNetworks_Bad2.xml", new string[] {})]    //Data format corrupted
        [TestCase(SkAdNetworkFileExtension.JSON, "Assets/SkAdNetworks_Bad2.json", new string[] {})]    //Data format corrupted
        [TestCase(SkAdNetworkFileExtension.JSON, "Assets/SkAdNetworks_Bad", new string[] {})]    //Invalid protocol
        [TestCase(SkAdNetworkFileExtension.JSON, "Assets/SkAdNetworks_Bad2", new string[] {})]    //Invalid url
        [TestCase(SkAdNetworkFileExtension.JSON, "Assets/SkAdNetworks_Bad3", new string[] {})]    //Valid url to Data in an invalid format
        public void ParserCanHandleInvalidFiles(string parserType, string sourceDataPath, string[] expectedResults)
        {
            Assert.That(SkAdNetworkParser.GetParser(parserType).ParseSource(new SkAdNetworkLocalSource(sourceDataPath)), Is.EquivalentTo(expectedResults), "Parser did not return the expected results");
        }

        [Test]
        [Category("WorksInIsolation")]
        [TestCase("-1")]
        [TestCase(null)]
        [TestCase("a")]
        [TestCase("xmls")]
        [TestCase("xml*")]
        [TestCase("*xml")]
        [TestCase(".xml")]
        public void InvalidParserType(string parserType)
        {
            Assert.IsNull(SkAdNetworkParser.GetParser(parserType));
        }
    }
}
#endif
