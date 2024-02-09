using Org.BouncyCastle.Asn1.Mozilla;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	internal class HMAC
	{
		public string Hmac { get; set; }
		public string Data {  get; set; }
        public SecureKey SecureKey { get; set; }
		public int BitLength { get; set; }
        public HMAC(string data, SecureKey secureKey,int bitLength) 
		{
			Data = data;
			SecureKey = secureKey;
			BitLength = bitLength;
			Hmac = Generate();
		}
		private string Generate()
		{
			SHA_3 sha_3 = new SHA_3(BitLength);
			string hashData = sha_3.CreateHash(Encoding.Default.GetBytes(Data));
			string dataKey = hashData + SecureKey.HashKey;
			return sha_3.CreateHash(Encoding.Default.GetBytes(dataKey));
		}
		
	}
}
