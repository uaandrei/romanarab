namespace Infrastructure
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
    }
}
