using System;
using System.Collections.Generic;
using System.Linq;
public class InstructorStudentPair
{
    public int InstructorID { get; set; }
    public string StudentName { get; set; }
    public InstructorStudentPair(int instructorID, string studentName)
    {
        InstructorID = instructorID;
        StudentName = studentName;
    }
}
class Program
{
    static void Main()
    {
        List<InstructorStudentPair> InstructorStudent = new List<InstructorStudentPair>()
        {
            new InstructorStudentPair(1, "Basant"),
            new InstructorStudentPair(2, "Basant"),
            new InstructorStudentPair(1, "Avery"),
            new InstructorStudentPair(1, "Shanu"),
            new InstructorStudentPair(2, "Shanu"),
            new InstructorStudentPair(1, "Neha"),
            new InstructorStudentPair(2, "Avery"),
            new InstructorStudentPair(2, "Neha")
        };
        var studentsWithInstructor1 = InstructorStudent
            .Where(pair => pair.InstructorID == 1)
            .Select(pair => pair.StudentName)
            .Distinct()
            .ToList();
        foreach (var student in studentsWithInstructor1)
        {
            Console.WriteLine(student);
        }
    }
}