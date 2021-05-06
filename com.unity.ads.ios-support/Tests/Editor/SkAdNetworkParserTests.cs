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
        [TestCase(SkAdNetworkFileExtension.NONE, "Assets/SkAdNetworks", new[] {"yclnxrl5pm.skadnetwork","wg4vff78zm.skadnetwork","238da6jt44.skadnetwork","4pfyvq9l8r.skadnetwork","4468km3ulz.skadnetwork","m8dbw4sv7c.skadnetwork","wzmmz9fp6w.skadnetwork","zmvfpc5aq8.skadnetwork","5lm9lj6jb7.skadnetwork","mlmmfzh3r3.skadnetwork","8s468mfl3y.skadnetwork","44n7hlldy6.skadnetwork","5a6flpkh64.skadnetwork","2u9pt9hc89.skadnetwork","3rd42ekr43.skadnetwork","424m5254lk.skadnetwork","ppxm28t8ap.skadnetwork","v79kvwwj4g.skadnetwork","4fzdc2evr5.skadnetwork","cstr6suwn9.skadnetwork","3qy4746246.skadnetwork","bvpn9ufa9b.skadnetwork","9rd848q2bz.skadnetwork","f73kdq92p3.skadnetwork","ydx93a7ass.skadnetwork","44jx6755aq.skadnetwork","v72qych5uu.skadnetwork","glqzh8vgby.skadnetwork","hs6bdukanm.skadnetwork","prcb7njmu6.skadnetwork","c6k4g5qg8m.skadnetwork","3sh42y64q3.skadnetwork","578prtvx9j.skadnetwork","4dzt52r2t5.skadnetwork","7ug5zh24hu.skadnetwork","9t245vhmpl.skadnetwork","tl55sbb4fm.skadnetwork","22mmun2rn5.skadnetwork", "488r3q3dtq.skadnetwork","t38b2kh725.skadnetwork","f38h382jlk.skadnetwork","lr83yxwka7.skadnetwork","kbd757ywx3.skadnetwork","av6w8kgt66.skadnetwork","24t9a8vw3c.skadnetwork"})]
        public void ParserCanParseSourceAsExpected(string parserType, string sourceDataPath, string[] expectedResults) {
            var result = SkAdNetworkParser.GetParser(parserType).ParseSource(new SkAdNetworkLocalSource(sourceDataPath));
            Assert.That(result, Is.EquivalentTo(expectedResults), "Parser did not return the expected results");
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
