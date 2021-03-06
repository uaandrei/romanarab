﻿using System.Collections.Generic;

namespace Infrastructure
{
    public interface INumberProvider
    {
        List<string> Units { get; }
        List<string> Tens { get; }
        List<string> Thousands { get; }
        List<string> Hundreds { get; }
    }
}
