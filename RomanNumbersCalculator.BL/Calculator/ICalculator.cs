﻿namespace RomanNumbersCalculator.BL.Calculator
{
    public interface ICalculator<T>
    {
        T Add(T value1, T value2, out bool hasTransport);
    }
}
