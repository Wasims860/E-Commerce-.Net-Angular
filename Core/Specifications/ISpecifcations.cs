namespace Core.Specifications;

public interface ISpecifcations<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get;}
}
