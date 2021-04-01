using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeritWeb.Pages
{
    public class TeamModel : PageModel
    {
        public  List<Employee> employees = new List<Employee>();
        public void OnGet()
        {
            AddEmployees();
        }
        public void AddEmployees()
        {
            employees.Add(new Employee("https://media-exp1.licdn.com/dms/image/C5603AQGkIo5JRvcLRw/profile-displayphoto-shrink_200_200/0/1597413361467?e=1618444800&v=beta&t=VBDy9Wc__UmeGE9UCZht5WqF5hsFrGzV5CjY4sXXmO0", "Johanna Pulli", "Scrum Master", "https://www.linkedin.com/in/johanna-pulli-b157781b4/"));
            employees.Add(new Employee("/images/empty.png", "Rosanna Cirillo", "Produktbeställare", ""));
            employees.Add(new Employee("https://media-exp1.licdn.com/dms/image/C4E03AQE4XHG5OBf9Rg/profile-displayphoto-shrink_200_200/0/1604400214139?e=1618444800&v=beta&t=KelE-ZE0XN_4_o6Xy1DJIlszaAjDoeAgCpS1j6sSK6U", "Helena Böös", "Programmerare", "https://www.linkedin.com/in/helena-lindholm-b%C3%B6%C3%B6s-ba8a301ba/"));
            employees.Add(new Employee("https://media-exp1.licdn.com/dms/image/C5603AQEsdNsGxC6U3w/profile-displayphoto-shrink_200_200/0/1604314378717?e=1618444800&v=beta&t=JzCx5KHqwZqWEqWrqANAoaUNn00Ivch17eluz_0KRxM", "Joakim Holm", "Programmerare", "https://www.linkedin.com/in/joakim-holm-a5b03a1bb/"));
            employees.Add(new Employee("https://media-exp1.licdn.com/dms/image/C4E03AQHWSmFjDchMBw/profile-displayphoto-shrink_200_200/0/1606643803371?e=1622678400&v=beta&t=zRibXMXeCtYeojzHRo4tsXx7J6ICxshTeq46MdbL0as", "Mikael Berglund", "Programmerare", "https://www.linkedin.com/in/mikael-berglund-4042901b7/"));
            employees.Add(new Employee("/images/empty.png", "Jimmy Borin", "Programmerare", "https://www.linkedin.com/in/jimmy-borin-957766127/"));
            employees.Add(new Employee("https://media-exp1.licdn.com/dms/image/C4D03AQG6cInZqxcQQg/profile-displayphoto-shrink_200_200/0/1612878850151?e=1618444800&v=beta&t=cXae2jLbaFXgPnkm_LU13wfch3hvDJBzTFlI7Zexq4o", "Max Skjöld", "Programmerare", "https://www.linkedin.com/in/max-skj%C3%B6ld-829b2518a/"));
            employees.Add(new Employee("/images/empty.png", "Sebastian Johansson", "Programmerare", ""));
        }
    }
    public class Employee
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string LinkedInUrl { get; set; }
        public Employee(string imageUrl, string name, string title, string linkedInUrl)
        {
            ImageUrl = imageUrl;
            Name = name;
            Title = title;
            LinkedInUrl = linkedInUrl;
        }
    }
}
