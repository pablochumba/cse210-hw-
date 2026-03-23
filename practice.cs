public class Person
{
    private int _age = 0;

    public void SetAge(int age)
    {
        if (age >= 0 && age <= 120)
        {
            _age = age;
        }
    }

    public int GetAge()
    {
        return _age;
    }

    
}