namespace LEGO.AsyncAPI.E2E.Tests.readers.samples.AsyncApi.AsyncApiTagObject
{
    using AsyncAPI.Tests;
    using Models;
    using Xunit;

    public class ShouldProduceTag: ShouldConsumeProduceBase<Tag>
    {
        public ShouldProduceTag(): base(typeof(ShouldProduceTag))
        {
        }

        [Fact]
        public void ShouldProduceMinimalSpec()
        {
            Assert.Equal(GetString("Minimal.json"), asyncApiWriter.Write(new Tag()));
        }
        
        [Fact]
        public void ShouldProduceCompleteSpec()
        {
            Assert.Equal(GetStringWithMockedExtensions("Complete.json"), asyncApiWriter.Write(MockData.Tag()));
        }
    }
}