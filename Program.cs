using System;
using System.Collections.Generic;

class Student
{
    public string FullName { get; set; }
    public int ID { get; set; }
    public string Group { get; set; }

    public Student(string fullName, int id, string group)
    {
        FullName = fullName;
        ID = id;
        Group = group;
    }
}

class CourseProgress
{
    public string CourseName { get; set; }
    public double Score { get; set; }
    public string CurrentTopic { get; set; }

    public CourseProgress(string courseName, double score, string currentTopic)
    {
        CourseName = courseName;
        Score = score;
        CurrentTopic = currentTopic;
    }
}

class CourseSystem
{
    private Dictionary<Student, List<CourseProgress>> students = new();

    public void AddStudent(string fullName, int id, string group)
    {
        var student = new Student(fullName, id, group);
        students[student] = new List<CourseProgress>();
        Console.WriteLine($"Added student: {fullName}");
    }

    public void AddCourse(int studentId, string courseName, double score, string topic)
    {
        foreach (var student in students.Keys)
        {
            if (student.ID == studentId)
            {
                students[student].Add(new CourseProgress(courseName, score, topic));
                Console.WriteLine($"Added course {courseName} to {student.FullName}");
                return;
            }
        }
        Console.WriteLine("Student not found.");
    }

    public void ShowStudentsByGroup(string group)
    {
        Console.WriteLine($"Students in group {group}:");
        foreach (var student in students.Keys)
        {
            if (student.Group == group)
                Console.WriteLine($"- {student.FullName} (ID: {student.ID})");
        }
    }

    public void ShowTopStudents()
    {
        List<(Student, double)> avgScores = new();
        foreach (var entry in students)
        {
            double total = 0;
            foreach (var course in entry.Value)
                total += course.Score;

            avgScores.Add((entry.Key, entry.Value.Count > 0 ? total / entry.Value.Count : 0));
        }

        avgScores.Sort((a, b) => b.Item2.CompareTo(a.Item2));

        Console.WriteLine("Top students:");
        foreach (var (student, score) in avgScores)
            Console.WriteLine($"{student.FullName} (Avg Score: {score:F2})");
    }
}

class Program
{
    static void Main()
    {
        CourseSystem system = new();

        system.AddStudent("Marina", 101, "KI1");
        system.AddStudent("Bob", 102, "KI1");

        system.AddCourse(101, "Math", 90, "Algebra");
        system.AddCourse(102, "Math", 85, "Geometry");
        

        system.ShowStudentsByGroup("KI1");
        system.ShowTopStudents();
    }
}
