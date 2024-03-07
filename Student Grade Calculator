class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Student Name");
        string name = Console.ReadLine();
        while (name == "")
        {
            name = Console.ReadLine();
        }

        Console.WriteLine("Enter Number of Subjects");
        int numberOfSubjects = Convert.ToInt32(Console.ReadLine());
        while (numberOfSubjects == null || numberOfSubjects < 0)
        {
            numberOfSubjects = Convert.ToInt32(Console.ReadLine());
        }

        Dictionary<string, double> subjects = new Dictionary<string, double>();

        for (int i = 0; i < numberOfSubjects; i++)
        {
            Console.WriteLine("Enter Subject Name");
            string currentSubject = Console.ReadLine();
            while (currentSubject == "")
            {
                currentSubject = Console.ReadLine();
            }
            Console.WriteLine("Enter Marks");
            double currentSubjectMarks = Convert.ToDouble(Console.ReadLine());
            while (currentSubjectMarks < 0 && currentSubjectMarks > 100 || currentSubjectMarks == null)
            {
                currentSubjectMarks = Convert.ToDouble(Console.ReadLine());
            }

            subjects.Add(currentSubject, currentSubjectMarks);
        }
        double average = CalculateAverage(subjects);
        Console.WriteLine($"Student Name: {name}");
        foreach (var mark in subjects)
        {
            Console.WriteLine($"{mark.Key}: {mark.Value}");
        }

        Console.WriteLine($"Average: {average}");
    }

    public static double CalculateAverage(Dictionary<string, double> marks)
    {
        double sum = 0;
        foreach (var mark in marks)
        {
            sum += mark.Value;
        }
        return sum / marks.Count;
    }
}
