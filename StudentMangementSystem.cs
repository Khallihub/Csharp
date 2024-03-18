using Newtonsoft.Json;

namespace StudentMangementSystem
{
    public class Student
    {
        public String Name { get; set; }
        public int Age { get; set; }
        public readonly int RollNumber;
        public double Grade { get; set; }

        public Student(String name, int age, int rollNumber, double grade)
        {
            Name = name;
            Age = age;
            RollNumber = rollNumber;
            Grade = grade;
        }
    }

    public class StudentList<T> where T : Student
    {
        static List<T> students = new List<T>();

        public void AddStudent(T student)
        {
            students.Add(student);
        }
        public void RemoveStudent(T student)
        {
            students.Remove(student);
        }
        public void UpdateStudent(int rollNumber, string name, int age, double grade)
        {
            T? student = students.Find(s => s.RollNumber == rollNumber);
            if (student != null)
            {
                student.Name = name;
                student.Age = age;
                student.Grade = grade;
            }
        }

        public void SortByAge()
        {
            students.Sort((s1, s2) => s1.Age.CompareTo(s2.Age));
        }
        public void SortByRollNumber()
        {
            students.Sort((s1, s2) => s1.RollNumber.CompareTo(s2.RollNumber));
        }
        public void DisplayStudents()
        {
            foreach (T student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, RollNumber: {student.RollNumber}, Grade: {student.Grade}");
            }
        }
        public List<T> SearchStudents(string? Name, int? RollNumber)
        {
            if (Name == null && RollNumber == null)
            {
                return [];
            }
            return students.Where(s => (Name == null ? false : ((Student)s).Name.ToLower().Contains(Name.ToLower())) || ((Student)s).RollNumber == RollNumber).ToList();
        }

        public void SaveToFile(string filePath)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(students, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void LoadFromFile(string filePath)
        {
            students = [];
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }
            try
            {
                string jsonData = File.ReadAllText(filePath);
                List<T>? loadedStudents = JsonConvert.DeserializeObject<List<T>>(jsonData);
                if (loadedStudents == null)
                {
                    students = [];
                }
                if (loadedStudents != null)
                {
                    students = loadedStudents;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


    }
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            Student student1 = new Student("John", 20, 1, 90);
            Student student2 = new Student("Jane", 21, 2, 80);
            Student student3 = new Student("Doe", 22, 3, 70);
            StudentList<Student> studentList = new StudentList<Student>();
            studentList.AddStudent(student1);
            studentList.AddStudent(student2);
            studentList.AddStudent(student3);


            studentList.DisplayStudents();
            studentList.SaveToFile("students.json");
            StudentList<Student> loadedStudentList = StudentList<Student>.LoadFromFile("students.json");
            loadedStudentList.DisplayStudents();
            Console.WriteLine(loadedStudentList.SearchStudents("p", 5).Count);
            */

            Console.WriteLine("Your Student Management System is ready");
            StudentList<Student> studentList = new StudentList<Student>();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter 1 to add a student");
                Console.WriteLine("Enter 2 to display students");
                Console.WriteLine("Enter 3 to remove a student");
                Console.WriteLine("Enter 4 to update a student");
                Console.WriteLine("Enter 5 to sort students by age");
                Console.WriteLine("Enter 6 to sort students by roll number");
                Console.WriteLine("Enter 7 to search students");
                Console.WriteLine("Enter 8 to save students to file");
                Console.WriteLine("Enter 9 to load students from file");
                Console.WriteLine("Enter 0 to exit");
                Console.WriteLine();
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter student name");
                        string? name = Console.ReadLine();
                        if (name == "" || name == null)
                        {
                            Console.WriteLine("Student name cannot be empty");
                            break;
                        }
                        Console.WriteLine("Enter student age");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter student roll number");
                        int rollNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter student grade");
                        double grade = Convert.ToDouble(Console.ReadLine());
                        Student student = new Student(name, age, rollNumber, grade);
                        studentList.AddStudent(student);
                        Console.WriteLine("Student added successfully");
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        studentList.DisplayStudents();
                        break;
                    case 3:
                        Console.WriteLine("Enter student roll number");
                        rollNumber = Convert.ToInt32(Console.ReadLine());
                        Student? studentToRemove = studentList.SearchStudents(null, rollNumber).FirstOrDefault();
                        if (studentToRemove != null)
                        {
                            studentList.RemoveStudent(studentToRemove);
                            Console.WriteLine("Student removed successfully");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        Console.WriteLine("Enter student roll number");
                        rollNumber = Convert.ToInt32(Console.ReadLine());
                        Student? studentToUpdate = studentList.SearchStudents(null, rollNumber).FirstOrDefault();
                        if (studentToUpdate != null)
                        {
                            Console.WriteLine("Enter new student name");
                            name = Console.ReadLine();
                            if (name == "" || name == null)
                            {
                                Console.WriteLine("Student name cannot be empty");
                                break;
                            }
                            Console.WriteLine("Enter new student age");
                            age = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter new student grade");
                            grade = Convert.ToDouble(Console.ReadLine());
                            studentList.UpdateStudent(rollNumber, name, age, grade);
                            Console.WriteLine("Student updated successfully");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                        Thread.Sleep(2000);
                        break;
                    case 5:
                        studentList.SortByAge();
                        Console.WriteLine("Students sorted by age");
                        Thread.Sleep(2000);
                        break;
                    case 6:
                        studentList.SortByRollNumber();
                        Console.WriteLine("Students sorted by roll number");
                        Thread.Sleep(2000);
                        break;
                    case 7:
                        Console.WriteLine("Enter student name");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter student roll number");
                        rollNumber = Convert.ToInt32(Console.ReadLine());
                        List<Student> searchResults = studentList.SearchStudents(name, rollNumber);
                        if (searchResults.Count == 0)
                        {
                            Console.WriteLine("No students found");
                        }
                        else
                        {
                            foreach (Student s in searchResults)
                            {
                                Console.WriteLine($"Name: {s.Name}, Age: {s.Age}, RollNumber: {s.RollNumber}, Grade: {s.Grade}");
                            }
                        }
                        Thread.Sleep(2000);
                        break;
                    case 8:
                        studentList.SaveToFile("students.json");
                        Console.WriteLine("Students saved to file");
                        Thread.Sleep(2000);
                        break;
                    case 9:
                        StudentList<Student>.LoadFromFile("students.json");
                        Thread.Sleep(2000);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                if (choice == 0)
                {
                    break;
                }
            }
        }
    }
}
