using LinqExamples;

List<Employee> employees =
[
    new Employee { Id = 1, Name = "John", Department = "IT", Salary = 65000, Age = 30 },
    new Employee { Id = 2, Name = "Alice", Department = "HR", Salary = 45000, Age = 27 },
    new Employee { Id = 3, Name = "David", Department = "IT", Salary = 85000, Age = 38 },
    new Employee { Id = 4, Name = "Mary", Department = "Finance", Salary = 72000, Age = 35 },
    new Employee { Id = 5, Name = "Robert", Department = "IT", Salary = 55000, Age = 25 },
    new Employee { Id = 6, Name = "Sophia", Department = "Finance", Salary = 90000, Age = 42 }
];

Console.WriteLine("========== WHERE ==========");

var highSalary =
    employees.Where(x => x.Salary > 60000);

foreach (var emp in highSalary)
{
    Console.WriteLine($"{emp.Name} - {emp.Salary}");
}

Console.WriteLine();

Console.WriteLine("========== SELECT ==========");

var names =
    employees.Select(x => x.Name);

foreach (var name in names)
{
    Console.WriteLine(name);
}

Console.WriteLine();

Console.WriteLine("========== ORDER BY ==========");

var ordered =
    employees.OrderBy(x => x.Salary);

foreach (var emp in ordered)
{
    Console.WriteLine($"{emp.Name} - {emp.Salary}");
}

Console.WriteLine();

Console.WriteLine("========== ORDER BY DESC ==========");

var desc =
    employees.OrderByDescending(x => x.Salary);

foreach (var emp in desc)
{
    Console.WriteLine($"{emp.Name} - {emp.Salary}");
}

Console.WriteLine();

Console.WriteLine("========== FIRST ==========");

var firstIT =
    employees.First(x => x.Department == "IT");

Console.WriteLine(firstIT.Name);

Console.WriteLine();

Console.WriteLine("========== FIRST OR DEFAULT ==========");

var marketing =
    employees.FirstOrDefault(x => x.Department == "Marketing");

Console.WriteLine(marketing == null
    ? "No Marketing employee found."
    : marketing.Name);

Console.WriteLine();

Console.WriteLine("========== ANY ==========");

Console.WriteLine(employees.Any(x => x.Department == "HR"));

Console.WriteLine();

Console.WriteLine("========== ALL ==========");

Console.WriteLine(employees.All(x => x.Salary > 30000));

Console.WriteLine();

Console.WriteLine("========== COUNT ==========");

Console.WriteLine(employees.Count());

Console.WriteLine();

Console.WriteLine("========== MAX ==========");

Console.WriteLine(employees.Max(x => x.Salary));

Console.WriteLine();

Console.WriteLine("========== MIN ==========");

Console.WriteLine(employees.Min(x => x.Salary));

Console.WriteLine();

Console.WriteLine("========== AVERAGE ==========");

Console.WriteLine(employees.Average(x => x.Salary));

Console.WriteLine();

Console.WriteLine("========== SUM ==========");

Console.WriteLine(employees.Sum(x => x.Salary));

Console.WriteLine();

Console.WriteLine("========== GROUP BY ==========");

var groups =
    employees.GroupBy(x => x.Department);

foreach (var group in groups)
{
    Console.WriteLine(group.Key);

    foreach (var emp in group)
    {
        Console.WriteLine($"   {emp.Name}");
    }
}

Console.WriteLine();

Console.WriteLine("========== TAKE ==========");

foreach (var emp in employees.Take(3))
{
    Console.WriteLine(emp.Name);
}

Console.WriteLine();

Console.WriteLine("========== SKIP ==========");

foreach (var emp in employees.Skip(3))
{
    Console.WriteLine(emp.Name);
}

Console.WriteLine();

Console.WriteLine("========== DISTINCT ==========");

var departments =
    employees
        .Select(x => x.Department)
        .Distinct();

foreach (var department in departments)
{
    Console.WriteLine(department);
}
