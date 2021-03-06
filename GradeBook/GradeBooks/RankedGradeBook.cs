using System;
using System.Linq;
using GradeBook.Enums;
namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook (string name, bool isweighted) : base (name,isweighted)
        {
            Type=GradeBookType.Ranked;        
        }
       /// public\soverride\schar\sGetLetterGrade\s?[(]\s?double\saverageGrade\s?[)])"
        public override char GetLetterGrade (double averageGrade)
        {
        if (Students.Count<5){
            throw new InvalidOperationException();
        }

            var thershold = (int)Math.Ceiling(Students.Count * 0.2);
           var grades = Students.OrderByDescending (e =>e.AverageGrade).Select (e =>e.AverageGrade).ToList();
           if (grades[thershold -1]<= averageGrade)
           return 'A';
           else if (grades [thershold * 2 -1] <= averageGrade)
           return 'B';
           else if (grades [thershold * 3 -1] <= averageGrade)
           return 'C';
           else if (grades [thershold * 4 -1] <= averageGrade)
           return 'D';
           else return 'F';

        } 
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
            Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            return;
        }
          base.CalculateStatistics(); 
        }
          public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
            Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            return;
            }
          base.CalculateStudentStatistics(name); 

        }


    }   
}    
