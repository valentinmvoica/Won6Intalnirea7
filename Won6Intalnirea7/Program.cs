using System;
using System.Collections.Generic;

namespace Won6Intalnirea7
{
    class Program
    {
        static void Main(string[] args)
        {
            try { 
            StudentAggregator.GetAverage(new List<IStudent>());
            Console.WriteLine("Hello World!");
        }
    }
}



public static class StudentAggregator { 
    public static int GetAverage(List<IStudent> students) {
        var average = 0;

        students.ForEach(s =>
        {
            int studentAverage = 0;

            s.Marks.ForEach(m => studentAverage += m);
            
            average += studentAverage / s.Marks.Count;
        }
        );

        average = average / students.Count;
        return average;
    }
}

public interface IStudent
{
    int Age { get; set; }
    int Id { get; set; }
    List<int> Marks { get; }
    string Name { get; set; }
}

public class Student : IStudent
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public List<int> Marks
    {
        get
        {
            var result = new List<int>();

            /// fetch marks from database

            return result;
        }
    }
}