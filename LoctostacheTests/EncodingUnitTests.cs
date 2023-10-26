// Ignore Spelling: Loctostache

using Loctostache.Helpers;
using System.Text;

namespace LoctostacheTests
{
    public class EncodingUnitTests
    {
        [Fact]
        public void ValidateEncodingASCII()
        {
            var testBytes = new byte[4] { 0x00, 0x00, 0x00, 0x00 };
            var validASCII = EncodingHelper.GetEncodingFromBom(testBytes);
            Assert.Equal(Encoding.ASCII, validASCII);
        }

        [Fact]
        public void ValidateEncodingUTF8()
        {
            var testBytes = new byte[4] { 0xef, 0xbb, 0xbf, 0x00 };
            var validUTF8 = EncodingHelper.GetEncodingFromBom(testBytes);
            Assert.Equal(Encoding.UTF8, validUTF8);
        }

        [Fact]
        public void ValidateEncodingMoreThan4Bytes()
        {
            var testBytes = new byte[10] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            var validASCII = EncodingHelper.GetEncodingFromBom(testBytes);
            Assert.Equal(Encoding.ASCII, validASCII);
        }
    }
}