﻿namespace NServiceBus.Core.Tests.Transports.Learning
{
    using System.Collections.Generic;
    using ApprovalTests;
    using NUnit.Framework;

    public class HeaderSerializerTests
    {
        [Test]
        public void Can_round_trip_headers()
        {
            var input = new Dictionary<string, string>
            {
                {
                    "key 1",
                    "value 1"
                },
                {
                    "key 2",
                    "value 2"
                }
            };
            var serialized = HeaderSerializer.Serialize(input);

            Approvals.Verify(serialized);
            var deserialize = HeaderSerializer.Deserialize(serialized);
            CollectionAssert.AreEquivalent(input, deserialize);
        }
    }
}