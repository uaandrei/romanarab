namespace RomanNumbersCalculator.BL
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> _specification1;
        private ISpecification<T> _specification2;

        public AndSpecification(ISpecification<T> specification1, ISpecification<T> specification2)
        {
            _specification1 = specification1;
            _specification2 = specification2;
        }

        public bool IsSatisfiedBy(T candidate)
        {
            return _specification1.IsSatisfiedBy(candidate) && _specification2.IsSatisfiedBy(candidate);
        }
    }
}
