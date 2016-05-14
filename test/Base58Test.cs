﻿using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using NUnit.Framework;
using SimpleBase;

namespace Base32Test
{
    [TestFixture]
    [Parallelizable]
    class Base58Test
    {
        [Test]
        public void Encode_NullBuffer_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Base58.Encode(null, Base58.BitcoinAlphabet));
        }

        [Test]
        public void Encode_NullAlphabet_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Base58.Encode(new byte[1], null));
        }

        [Test]
        public void Encode_EmptyBuffer_ReturnsEmptyString()
        {
            Assert.AreEqual(String.Empty, Base58.Encode(new byte[] { }, Base58.BitcoinAlphabet));
        }

        [Test]
        [TestCase("0000010203", "11Ldp")]
        [TestCase("009C1CA2CBA6422D3988C735BB82B5C880B0441856B9B0910F", "1FESiat4YpNeoYhW3Lp7sW1T6WydcW7vcE")]
        [TestCase("000860C220EBBAF591D40F51994C4E2D9C9D88168C33E761F6", "1mJKRNca45GU2JQuHZqZjHFNktaqAs7gh")]
        [TestCase("0000000000", "11111")]
        public void Encode_Bitcoin_ReturnsExpectedResults(string input, string expectedOutput)
        {
            var buffer = SoapHexBinary.Parse(input).Value;
            string result = Base58.Encode(buffer, Base58.BitcoinAlphabet);
            Assert.AreEqual(expectedOutput, result);
        }
    }
}