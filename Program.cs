using GenericSortMethod;

class Program
{
    delegate void SortDelegate<T>(List<T> collection ,Comparison<T> comparison);
    static void Main(string[] args)
    {
        var student = new List<StudentModel> 
        {
            new StudentModel 
            {
                Id = 100,
                Name = "Ram",
                Age = 15,
                Score = 99,
            },
            new StudentModel
            {
                Id = 121,
                Name = "Arjun",
                Age = 19,
                Score = 89.9,
            },
            new StudentModel
            {
                Id = 101,
                Name = "Rahul",
                Age = 15,
                Score = 99.9,
            },
            new StudentModel
            {
                Id = 102,
                Name = "Riya",
                Age = 16,
                Score = 78.5,
            }
        };

        SortDelegate<StudentModel> sortDelegate = Sort;

        // Sort part 
        sortDelegate(student, (x, y) => x.Name.CompareTo(y.Name));
        Console.WriteLine("Sorted by Name:");
        DisplayStudents(student);

        

    }
    static void Sort<T>(List<T> Collection,Comparison<T> comparison)
    {
        for(int i = 0; i < Collection.Count-1; i++)
        {
            int minIndex = i;
            for (int j = i+1; j < Collection.Count; j++)
            {
                if (comparison(Collection[j], Collection[minIndex]) < 0) 
                {
                    minIndex = j;
                }

            }
            if(minIndex != i)
            {
                T temp = Collection[i];
                Collection[i] = Collection[minIndex];
                Collection[minIndex] = temp;
            }

        }
    }
    static void DisplayStudents(List<StudentModel> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, Score: {student.Score}");
        }
    }
}
