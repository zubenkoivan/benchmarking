﻿using System.Text;
using Algorithms.Compression;
using Xunit;

namespace Algorithms.Tests
{
    public class HuffmanCodeTests
    {
        [Fact]
        public void Should_Compress()
        {
            HuffmanCode.Compress(Encoding.ASCII.GetBytes(TestData.Text.ToUpperInvariant()));
        }
    }
}