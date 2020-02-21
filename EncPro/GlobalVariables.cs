using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using EncModel.Log;
using EncModel.Raps;
using EncModel.ChartReview;

namespace EncPro
{
    public class GlobalVariables
    {
        public static List<string> DMEProcCodes { get; set; }
        public static string DestinationFolder { get; set; }
        public static List<List<LoadLog>> SchedulePages { get; set; }
        public static int TotalCCII { get; set; }
        public static int TotalCCIP { get; set; }
        public static int TotalCMCI { get; set; }
        public static int TotalCMCP { get; set; }
        public static int TotalDHCSI { get; set; }
        public static int TotalDHCSP { get; set; }
        public static List<RapsRecord> rapsRecords { get; set; }
        public static List<ChartReviewRecord> chartReviewRecords { get; set; }
        public static string Encrypt(string TextToEncrypt)
        {
            string result = "";
            string publickey = "fespring";
            string secretkey = "frosaday";

            byte[] secretkeyByte = Encoding.UTF8.GetBytes(secretkey);
            byte[] publickeybyte = Encoding.UTF8.GetBytes(publickey);
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] inputbyteArray = Encoding.UTF8.GetBytes(TextToEncrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                cs.FlushFinalBlock();
                result = Convert.ToBase64String(ms.ToArray());
            }
            return result;
        }
        public static string Decrypt(string TextToDecrypt)
        {
            string result = "";
            string publickey = "fespring";
            string privatekey = "frosaday";
            byte[] privatekeyByte = Encoding.UTF8.GetBytes(privatekey);
            byte[] publickeybyte = Encoding.UTF8.GetBytes(publickey);
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] inputbyteArray = new byte[TextToDecrypt.Replace(" ", "+").Length];
            inputbyteArray = Convert.FromBase64String(TextToDecrypt.Replace(" ", "+"));
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                result = encoding.GetString(ms.ToArray());
            }
            return result;
        }
    }
}
