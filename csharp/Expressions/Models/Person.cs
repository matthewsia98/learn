namespace Expressions.Models;

public class Person
{
    public string Name { get; set;}
    public int Height { get; set; }
    public double Weight { get; set;}
    public DateTime BirthDate { get; set; }
    public List<string> Hobbies { get; set; }
    public Person Mother { get; set;}
    public Person Father { get; set;}
    public List<Person> Children { get; set; }
}
