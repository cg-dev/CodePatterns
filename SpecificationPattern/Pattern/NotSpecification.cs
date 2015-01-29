using SpecificationPattern.Abstracts;
using SpecificationPattern.Interfaces;

//public class NotSpecification<T> : CompositeSpecification<T>
//{
//    ISpecification<T> leftSpecification;
//    ISpecification<T> rightSpecification;

//    public NotSpecification(ISpecification<T> left)
//    {
//        this.leftSpecification = left;
//    }

//    public override bool IsSatisfiedBy(T o)
//    {
//        return !this.leftSpecification.IsSatisfiedBy(o);
//    }
//}

public class NotSpecification<T> : CompositeSpecification<T>
{
    ISpecification<T> leftSpecification;
    ISpecification<T> rightSpecification;

    public NotSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
    {
        this.leftSpecification = leftSide;
        this.rightSpecification = rightSide;
    }

    public override bool IsSatisfiedBy(T obj)
    {
        return leftSpecification.IsSatisfiedBy(obj) && !rightSpecification.IsSatisfiedBy(obj);
    }
}