﻿using AutoFixture.Xunit2;
using Xunit;

namespace TheAwesomeTextAdventure.UnitTests.AutoFixture
{
    public class AutoInlineDataAttribute : CompositeDataAttribute
    {
        public AutoInlineDataAttribute(params object[] values)
            : base(new InlineDataAttribute(values), new AutoNSubstituteDataAttribute())
        {
        }
    }
}
