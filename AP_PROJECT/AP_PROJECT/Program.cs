using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectAP
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Course> l = new List<Course>();
            l.Add(new Course() { Id = 1 , ECT = 3 , Name = "madar", type = "asli"});
            l.Add(new Course() { Id = 2, ECT = 3, Name = "madar 2", type = "asli" });
            l.Add(new Course() { Id = 3, ECT = 3, Name = "madar 4", type = "asli" });
            l.Add(new Course() { Id = 5, ECT = 3, Name = "madar 5", type = "asli" });
            
            foreach (var item in l.Select(x=> x).Where(x => x.Id < 4))
            {
                Console.WriteLine(item.Name);

            }
        }
    }
}
