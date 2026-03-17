using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
            job1._company = "Google";
            job1._jobTitle = "Software Engineer";
            job1._startYear = 2024;
            job1._endYear = 2025;

        Job job2 = new Job();
            job2._company = "Microsoft";
            job2._jobTitle = "Data Scientist";
            job2._startYear = 2025;
            job2._endYear = 2026;

        Resume resume = new Resume();
            resume._jobs.Add(job1);
            resume._jobs.Add(job2);

        resume.Display();
    }
}