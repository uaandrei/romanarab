namespace RomanNumbersCalculator.BL.Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
    }
}
