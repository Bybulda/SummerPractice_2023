namespace Laby_fund.task1;

class Test
{
    static int Main()
    {
        try
        {
            var stud = new Student("Nikita", "Smirnov", 
                "Evhgenoevich", "M8O-211B-21", Practice.Cs);
            Console.WriteLine($"My name is {stud.NameField}\nMy surname is {stud.SurnameField}\nMy patronymic is {stud.PatronymicField}\n" +
                              $"I am from group {stud.GroupField}\nThe course is {stud.CourseNumber}\nI practice on {stud.PracticeType}");
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
            return -1;
        }
        
        return 0;
    }
}
