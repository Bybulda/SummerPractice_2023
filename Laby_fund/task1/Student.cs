namespace Laby_fund.task1;

public enum Practice: int{
    Cs,
    Yandex,
    Go,
    DataSet,
    Structures
}

public class Student
{
    public Student(string? name, string? surname, string? patronymic, string? group, Practice? choice)
    {
        NameField = name ?? throw new ArgumentNullException(nameof(name));
        SurnameField = surname ?? throw new ArgumentNullException(nameof(surname));
        PatronymicField = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
        GroupField = group ?? throw new ArgumentNullException(nameof(group));
        PracticeField = choice ?? throw new ArgumentNullException(nameof(choice));
    }

    public string NameField
    {
        get;
        private set;
    }

    public string SurnameField
    {
        get;
        private set;
    }

    public string PatronymicField
    {
        get;
        private set;
    }

    public string GroupField
    {
        get;
        private set;
    }
    
    private Practice PracticeField
    {
        get;
        set;
    }

    public string PracticeType
    {
        get
        {
            string[] type = { "C#", "Yandex", "Go", "Dataset", "Structures" };
            return type[(int) PracticeField];
        }
    }

    public int CourseNumber
    {
        get
        {
            var number = GroupField.Split("-");
            return Convert.ToInt32(number[1].Substring(0, 1));

        }
    }
}