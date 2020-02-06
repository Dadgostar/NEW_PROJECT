using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectAP
{
    public class Module
    {
        public static List<Student> StudentTable = new List<Student>();
        public static List<Teacher> TeacherTable = new List<Teacher>();
        public static List<TermCourse> termCourseTable = new List<TermCourse>();
        public static List<TermCourseStudent> termCourseStudentTable = new List<TermCourseStudent>();
        public static bool EditPassword(Person user , string newPassword, string oldPassword, string confirm, Person person)
        {
            if (!AccessTo(person, user, "EditPassword"))
                return false;        
            if (newPassword != confirm || user.Password != oldPassword)
                return false;
            user.Password = newPassword;
            return true;
            
            
        }


        public static Person Login(string userName, string passWord)
        {
            throw new NotImplementedException();
        }

        public static List<Tuple<Term,double,double>> GetTermAvgGrade(Student student)
        {
            var TermList = termCourseStudentTable.Select(x => x).Where(x => x.Student == student && x.Status=="passed").Select(x => x.TermCourse.Term).OrderBy(x=>x.TermNum).Distinct();
            List<Tuple<Term, double,double>> result = new List<Tuple<Term, double,double>>();
            foreach (var term in TermList)
            {
                var CoursesInTermList = termCourseStudentTable.Select(x => x).Where(x => x.Student == student && x.TermCourse.Term.TermNum == term.TermNum);
                var Sum = CoursesInTermList.Select(x=>x.Mark*x.TermCourse.Course.ECT).Sum();
                var Count = CoursesInTermList.Select(x => x.TermCourse.Course.ECT).Sum();
                result.Add(new Tuple<Term, double,double>(term, Count, Sum/Count));
            }
            return result;
        }

        public static double GetAvgGrade(Student student)
        {
            var temp = GetTermAvgGrade(student);
            var sum = temp.Select(x => x.Item2 * x.Item3).Sum();
            var Count = temp.Select(x => x.Item2).Sum();
            return sum / Count;
        }
        private static bool AccessTo(Person person, Person user, string AccessTo)
        {
            return true;
        }
        public Module()
        {

        }


    }
   
}

