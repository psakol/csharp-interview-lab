using DelegatesExamples.Models;

namespace DelegatesExamples.Services;

/// <summary>
/// Demonstrates delegates using employee-related examples.
/// </summary>
public class EmployeeService
{
    private readonly List<Employee> _employees =
    [
        new()
        {
            Id = 1,
            Name = "John Smith",
            Department = "IT",
            Designation = "Senior Developer",
            Salary = 95000,
            Age = 32,
            IsActive = true
        },

        new()
        {
            Id = 2,
            Name = "Alice Johnson",
            Department = "HR",
            Designation = "HR Manager",
            Salary = 72000,
            Age = 35,
            IsActive = true
        },

        new()
        {
            Id = 3,
            Name = "David Brown",
            Department = "Finance",
            Designation = "Financial Analyst",
            Salary = 81000,
            Age = 30,
            IsActive = true
        },

        new()
        {
            Id = 4,
            Name = "Sophia Wilson",
            Department = "IT",
            Designation = "Solution Architect",
            Salary = 125000,
            Age = 40,
            IsActive = true
        },

        new()
        {
            Id = 5,
            Name = "Michael Lee",
            Department = "Sales",
            Designation = "Sales Executive",
            Salary = 60000,
            Age = 28,
            IsActive = false
        }
    ];

    /// <summary>
    /// Returns all employees.
    /// </summary>
    public IEnumerable<Employee> GetEmployees()
    {
        return _employees;
    }

    /// <summary>
    /// Demonstrates Predicate&lt;T&gt;.
    /// </summary>
    public IEnumerable<Employee> FilterEmployees(
        Predicate<Employee> predicate)
    {
        return _employees.Where(employee => predicate(employee));
    }

    /// <summary>
    /// Demonstrates Func&lt;T,TResult&gt;.
    /// </summary>
    public IEnumerable<TResult> SelectEmployees<TResult>(
        Func<Employee, TResult> selector)
    {
        return _employees.Select(selector);
    }

    /// <summary>
    /// Demonstrates Action&lt;T&gt;.
    /// </summary>
    public void ProcessEmployees(
        Action<Employee> action)
    {
        foreach (var employee in _employees)
        {
            action(employee);
        }
    }

    /// <summary>
    /// Demonstrates callbacks using delegates.
    /// </summary>
    public void CalculateBonus(
        Employee employee,
        Func<Employee, decimal> bonusCalculator,
        Action<Employee, decimal> onCompleted)
    {
        var bonus = bonusCalculator(employee);

        onCompleted(employee, bonus);
    }

    /// <summary>
    /// Demonstrates Comparison&lt;T&gt;.
    /// </summary>
    public List<Employee> SortEmployees(
        Comparison<Employee> comparison)
    {
        var employees = _employees.ToList();

        employees.Sort(comparison);

        return employees;
    }

    /// <summary>
    /// Demonstrates Predicate&lt;T&gt; using List.FindAll().
    /// </summary>
    public List<Employee> FindEmployees(
        Predicate<Employee> predicate)
    {
        return _employees.FindAll(predicate);
    }

    /// <summary>
    /// Demonstrates Action delegate for logging.
    /// </summary>
    public void ExecuteWithLogging(
        Action action,
        Action<string> logger)
    {
        logger("Operation Started");

        action();

        logger("Operation Completed");
    }

    /// <summary>
    /// Demonstrates Func delegate with a return value.
    /// </summary>
    public decimal CalculatePayroll(
        Func<IEnumerable<Employee>, decimal> calculator)
    {
        return calculator(_employees);
    }

    /// <summary>
    /// Demonstrates delegate callbacks.
    /// </summary>
    public void NotifyEmployee(
        Employee employee,
        Action<Employee> notification)
    {
        notification(employee);
    }
}