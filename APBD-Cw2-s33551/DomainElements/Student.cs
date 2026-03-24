namespace DomainElements
{
    public class Student : User
    {
        public override int GetMaxRentals() => 2;
    }
}