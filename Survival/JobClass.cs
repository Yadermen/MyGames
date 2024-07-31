using System;


namespace Works
{
    public class Job
    {

       

        public Job(string jobName, float salary, float expSalary, float jobPrice, float expPrice)
        {
            JobName = jobName;
            Salary = salary;
            ExpSalary = expSalary;
            JobPrice = jobPrice;
            ExpPrice = expPrice;
        }
        public string JobName { get; private set; }
        public float Salary { get; private set; }
        public float ExpSalary { get; private set; }
        public float JobPrice { get; private set; }
        public float ExpPrice { get; private set; }
    }




}
}
