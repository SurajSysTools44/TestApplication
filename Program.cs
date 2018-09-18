using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Program
    {
       
        static void Main(string[] args)
        {
           string DecryptedXML = DecryptXMLFile(@"D:\Build_Area_YahooBackup\Binaries\XML\Writer.xml");
            File.WriteAllText(@"X:\Sources\Release\GmailBackupLatest\bin\x86\Debug\XML\WriterDeCrypted.xml", DecryptedXML);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_FilePath"></param>
        /// <returns></returns>
        public static String DecryptXMLFile(String p_FilePath)
        {
            String decryptedFile = String.Empty;
            byte[] key = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            try
            {
               // if (IsXmlEncrypted(p_FilePath, out decryptedFile))
                {
                    FileStream fsCrypt = new FileStream(p_FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    RijndaelManaged RMCrypto = new RijndaelManaged();
                    CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);

                    StreamReader decryptedStreamReader = new StreamReader(cs);
                    decryptedFile = decryptedStreamReader.ReadToEnd();

                    cs.Close();
                    fsCrypt.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return decryptedFile;
        }

    }
}
