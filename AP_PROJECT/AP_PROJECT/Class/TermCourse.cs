using System;
namespace AP_PROJECT.Class
{

    public class TermCourse

    {
        
        public Course Course { get;set; }
        public Term Term { set; get; }
        public Teacher Teacher { get; set; }
        public int Time { get; set; }
        public string Place { get; set; }
        public int Capacity { get; set; }

        public TermCourse()
        {
        }
    }
}
