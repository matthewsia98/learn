namespace Expressions.Models;

public class Person
{
    public string Name { get; set; }
    public int Height { get; set; }
    public double Weight { get; set; }
    public DateTime BirthDate { get; set; }
    public PList<string> Hobbies { get; set; }
    public Person Mother { get; set; }
    public Person Father { get; set; }
    public PList<Person> Children { get; set; }
}

public class PList<T> : List<T>
{
    public override string ToString()
    {
        return $"[{string.Join(", ", this)}]";
    }
}
