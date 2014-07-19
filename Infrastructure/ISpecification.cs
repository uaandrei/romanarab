namespace RomanNumbersCalculator.BL.RomanNumberSpecification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
    }
}
