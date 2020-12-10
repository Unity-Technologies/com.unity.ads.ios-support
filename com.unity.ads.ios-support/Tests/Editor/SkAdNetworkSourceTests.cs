#if UNITY_2018_1_OR_NEWER && UNITY_IOS
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Unity.Advertisement.IosSupport.Editor.Tests
{
    public class SkAdNetworkSourceTests
    {
        [Test]
        [Category("WorksInIsolation")]
        [TestCase("ExpectedPath/To/File")]
        public void LocalSourcePathSetOnCreate(string expectedPath)
        {
            Assert.That(new SkAdNetworkLocalSource(expectedPath).Path, Is.EqualTo(expectedPath), "Path was not properly set in constructor");
        }

        [Test]
        [Category("WorksInIsolation")]
        [TestCase("ExpectedPath/To/File")]
        public void RemoteSourcePathSetOnCreate(string expectedPath)
        {
            Assert.That(new SkAdNetworkRemoteSource(expectedPath).Path, Is.EqualTo(expectedPath), "Path was not properly set in constructor");
        }

        [Test]
        [TestCase("Assets/SkAdNetworks.json")]
        [TestCase("Assets/SkAdNetworks.xml")]
        [TestCase("Assets/SkAdNetworks")]
        public void LocalSourceCanOpenStream(string testFilePath)
        {
            Assert.NotNull(new SkAdNetworkLocalSource(testFilePath).Open(), "Unable to open stream");
        }

        [Test]
        [TestCase("Assets/SkAdNetworksInvalidFilePath.json")]
        [TestCase("Assets/SkAdNetworksInvalidFilePath.xml")]
        [TestCase("Assets/SkAdNetworksInvalidFilePath")]
        public void LocalSourceInvalidFileThrowsException(string testFilePath)
        {
            Assert.Throws<FileNotFoundException>(() => new SkAdNetworkLocalSource(testFilePath).Open(), "FileNotFoundException should be thrown when the filepath is invalid");
        }

        [Test]
        [Category("WorksInIsolation")]
        [TestCase(SkAdNetworkFileExtension.XML, 1)]
        [TestCase(SkAdNetworkFileExtension.JSON, 2)]
        [TestCase(SkAdNetworkFileExtension.NONE, 2)]
        public void LocalSourceProviderFindsExpectedFiles(string extension, int expectedCount)
        {
            Assert.That(new SkAdNetworkLocalSourceProvider().GetSources("SKAdNetworks", extension).Count(), Is.EqualTo(expectedCount), "GetSources() did not return the expected count");
        }
    }
}
#endif
