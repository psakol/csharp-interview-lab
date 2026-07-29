namespace AsyncAwaitExamples.Models;

/// <summary>
/// Represents an employee used throughout the Async/Await examples.
/// </summary>
public sealed class Employee
{
    /// <summary>
    /// Unique employee identifier.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Employee full name.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Department the employee belongs to.
    /// </summary>
    public required string Department { get; init; }

    /// <summary>
    /// Employee designation.
    /// </summary>
    public required string Designation { get; init; }

    /// <summary>
    /// Annual salary.
    /// </summary>
    public decimal Salary { get; init; }

    /// <summary>
    /// Employee age.
    /// </summary>
    public int Age { get; init; }

    /// <summary>
    /// Employee email address.
    /// </summary>
    public required string Email { get; init; }

    /// <summary>
    /// Indicates whether the employee is currently active.
    /// </summary>
    public bool IsActive { get; init; } = true;

    /// <summary>
    /// Date the employee joined the organization.
    /// </summary>
    public DateTime JoiningDate { get; init; }

    /// <summary>
    /// Returns a readable string representation.
    /// </summary>
    public override string ToString()
    {
        return $"{Id} | {Name} | {Department} | {Designation} | ₹{Salary:N0}";
    }
}
