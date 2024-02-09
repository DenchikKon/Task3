using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	internal class SecureKey
	{
		public int BitLengthKey { get; }
		public string HashKey { get; }
		public SecureKey(int bitLengthKey)
		{
			BitLengthKey = bitLengthKey;
			HashKey = Generate();
		}
		private string Generate()
		{
			RandomNumberGenerator RandomData = RandomNumberGenerator.Create();
			byte[] key = new byte[BitLengthKey];
			RandomData.GetBytes(key);
			SHA_3 sha3 = new SHA_3(BitLengthKey);
			return sha3.CreateHash(key);
		}
	}
}
