namespace RomanNumbersCalculator.BL
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
    }
}
