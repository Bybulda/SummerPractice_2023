namespace Laby_fund.task1;

public enum Practice: int{
    Cs,
    Yandex,
    Go,
    DataSet,
    Structures
}

public class Student: 
    IEquatable<int>, 
    IEquatable<string>, 
    IEquatable<Student>
{
    public Student(string? name, string? surname, string? patronymic, string? group, Practice? choice)
    {
        NameField = name ?? throw new ArgumentNullException(nameof(name));
        SurnameField = surname ?? throw new ArgumentNullException(nameof(surname));
        PatronymicField = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
        GroupField = group ?? throw new ArgumentNullException(nameof(group));
        PracticeField = choice ?? throw new ArgumentNullException(nameof(choice));
    }
    
    // Properties
    public string NameField
    {
        get;
    }

    public string SurnameField
    {
        get;
    }

    public string PatronymicField
    {
        get;
    }

    public string GroupField
    {
        get;
    }
    
    private Practice PracticeField
    {
        get;
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
    // properties end
    
    // overrides
    public override string ToString()
    {
        return $"Student: {SurnameField} {NameField} {PatronymicField}\nGroup: {GroupField}\nPractice type: {PracticeType}\nCurrent course: {CourseNumber}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj is Student stud)
        {
            return Equals(stud);
        }

        if (obj is string @string)
        {
            return Equals(@string);
        }

        if (obj is Practice @practice)
        {
            return @practice == PracticeField;
        }

        if (obj is int @int)
        {
            return Equals(@int);
        }
        return false;
    }

    public bool Equals(string? @string)
    {
        return NameField.Equals(@string) || PatronymicField.Equals(@string) || GroupField.Equals(@string) ||
               SurnameField.Equals(@string);
    }

    public bool Equals(int @int)
    {
        return CourseNumber.Equals(@int);
    }

    public bool Equals(Student? @student)
    {
        if (@student is null)
        {
            return false;
        }
        return NameField.Equals(@student.NameField) && PatronymicField.Equals(@student.PatronymicField) && GroupField.Equals(@student.GroupField) &&
               SurnameField.Equals(@student.SurnameField) && PracticeType == @student.PracticeType;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(NameField.GetHashCode(), SurnameField.GetHashCode(), PatronymicField.GetHashCode(),
            GroupField.GetHashCode(), PracticeField.GetHashCode());
    }
    // overrides end
}