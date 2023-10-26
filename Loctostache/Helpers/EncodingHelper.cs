// Ignore Spelling: Loctostache

using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("LoctostacheTests")]
namespace Loctostache.Helpers
{
    internal static class EncodingHelper
    {
        internal static Encoding GetEncodingFromBom(byte[] bom)
        {
            bom = bom[0..3];
            var fileEncoding = Encoding.ASCII;
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76)
            {
#pragma warning disable SYSLIB0001 // Type or member is obsolete
                fileEncoding = Encoding.UTF7;
#pragma warning restore SYSLIB0001 // Type or member is obsolete
            }
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
            {
                fileEncoding = Encoding.UTF8;
            }

            if (bom[0] == 0xff && bom[1] == 0xfe && bom[2] == 0 && bom[3] == 0)
            {
                fileEncoding = Encoding.UTF32;
            }
            if (bom[0] == 0xff && bom[1] == 0xfe)
            {
                fileEncoding = Encoding.Unicode;
            }
            if (bom[0] == 0xfe && bom[1] == 0xff)
            {
                fileEncoding = Encoding.BigEndianUnicode;
            }
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff)
            {
                fileEncoding = new UTF32Encoding(true, true);
            }
            return fileEncoding;
        }
    }
}
