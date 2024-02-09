using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	internal class SHA_3
	{
		public int BitLength { get; set; }
		public SHA_3(int bitLegth) 
		{
			BitLength = 256;
		}
		public string CreateHash(byte[] data)
		{
			Sha3Digest sha3 = new Sha3Digest(256);
			sha3.BlockUpdate(data, 0, data.Length);
			byte[] hashBytes = new byte[sha3.GetDigestSize()];
			sha3.DoFinal(hashBytes, 0);
			return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
		}
	}
}
