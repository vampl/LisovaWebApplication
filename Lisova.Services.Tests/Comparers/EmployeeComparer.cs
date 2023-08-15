using Lisova.Services.Models;

namespace Lisova.Services.Tests.Comparers;

/// <summary>
/// Comparer class to proper check two instances while testing
/// </summary>
public class EmployeeComparer
{
    /// <summary>
    /// Gets result of comparison of two employee instances. 
    /// </summary>
    /// <param name="employee1">The instance of first employee to compare.</param>
    /// <param name="employee2">The instance of second employee to compare.</param>
    /// <param name="message">The out massage to return text details of comparison.</param>
    /// <returns>Returns result of comparison, true - instances are equal, either - false.</returns>
    public static bool Compare(Employee employee1, Employee employee2, out string message)
    {
        message = string.Empty;

        if (ReferenceEquals(employee1, employee2))
        {
            return true;
        }

        if (employee1.EmployeeNo != employee2.EmployeeNo)
        {
            message = $"{nameof(employee1.EmployeeNo)} != {nameof(employee2.EmployeeNo)}";
            return false;
        }

        if (employee1.Fullname != employee2.Fullname)
        {
            message = $"{nameof(employee1.Fullname)} != {nameof(employee2.Fullname)}";
            return false;
        }

        if (employee1.BirthDate != employee2.BirthDate)
        {
            message = $"{nameof(employee1.BirthDate)} != {nameof(employee2.BirthDate)}";
            return false;
        }
        
        if (employee1.Location != employee2.Location)
        {
            message = $"{nameof(employee1.Location)} != {nameof(employee2.Location)}";
            return false;
        }
        
        if (employee1.HomeAddress != employee2.HomeAddress)
        {
            message = $"{nameof(employee1.HomeAddress)} != {nameof(employee2.HomeAddress)}";
            return false;
        }
        
        if (employee1.ContactPhone != employee2.ContactPhone)
        {
            message = $"{nameof(employee1.ContactPhone)} != {nameof(employee2.ContactPhone)}";
            return false;
        }
        
        if (employee1.EmployeePositions.Count != employee2.EmployeePositions.Count)
        {
            message = $"{nameof(employee1.EmployeePositions.Count)} != {nameof(employee2.EmployeePositions.Count)}";
            return false;
        }
        
        foreach (var e1E2 in employee1.EmployeePositions.Zip(employee2.EmployeePositions, Tuple.Create))
        {
            if (Equals(e1E2.Item1, e1E2.Item2, out var innerMessage)) 
                continue;
            
            message = innerMessage;
            return false;
        }
        
        if (employee1.EmployeeDepartments.Count != employee2.EmployeeDepartments.Count)
        {
            message = $"{nameof(employee1.EmployeeDepartments.Count)} != {nameof(employee2.EmployeeDepartments.Count)}";
            return false;
        }
        
        foreach (var e1E2 in employee1.EmployeeDepartments.Zip(employee2.EmployeeDepartments, Tuple.Create))
        {
            if (Equals(e1E2.Item1, e1E2.Item2, out var innerMessage)) 
                continue;
            
            message = innerMessage;
            return false;
        }

        return true;
    }
    
    /// <summary>
    /// Gets result of comparison of two employee position instances. 
    /// </summary>
    /// <param name="employeePosition1">The instance of first employee position to compare.</param>
    /// <param name="employeePosition2">The instance of second employee position to compare.</param>
    /// <param name="innerMessage">The out massage to return text details of comparison.</param>
    /// <returns>Returns result of comparison, true - instances are equal, either - false.</returns>
    private static bool Equals(EmployeePosition employeePosition1, EmployeePosition employeePosition2, out string innerMessage)
    {
        innerMessage = string.Empty;

        if (employeePosition1.EmployeeNo != employeePosition2.EmployeeNo)
        {
            innerMessage = $"{nameof(employeePosition1.EmployeeNo)} != {nameof(employeePosition2.EmployeeNo)}";
            return false;
        }

        if (!Equals(employeePosition1.Position, employeePosition2.Position, out innerMessage))
        {
            innerMessage = $"{nameof(employeePosition1.Position)} != {nameof(employeePosition2.Position)}";
            return false;
        }
        
        if (employeePosition1.From != employeePosition2.From)
        {
            innerMessage = $"{nameof(employeePosition1.From)} != {nameof(employeePosition2.From)}";
            return false;
        }
        
        if (employeePosition1.To != employeePosition2.To)
        {
            innerMessage = $"{nameof(employeePosition1.To)} != {nameof(employeePosition2.To)}";
            return false;
        }
        
        return true;
    }
    
    /// <summary>
    /// Gets result of comparison of two position instances. 
    /// </summary>
    /// <param name="position1">The instance of first position to compare.</param>
    /// <param name="position2">The instance of second position to compare.</param>
    /// <param name="innerMessage">The out massage to return text details of comparison.</param>
    /// <returns>Returns result of comparison, true - instances are equal, either - false.</returns>
    private static bool Equals(Position position1, Position position2, out string innerMessage)
    {
        innerMessage = string.Empty;

        if (position1.PositionCode != position2.PositionCode)
        {
            innerMessage = $"{nameof(position1.PositionCode)} != {nameof(position2.PositionCode)}";
            return false;
        }

        if (position1.PositionName != position2.PositionName)
        {
            innerMessage = $"{nameof(position1.PositionName)} != {nameof(position2.PositionName)}";
            return false;
        }
        
        if (position1.Description != position2.Description)
        {
            innerMessage = $"{nameof(position1.Description)} != {nameof(position2.Description)}";
            return false;
        }
        
        if (position1.Salary != position2.Salary)
        {
            innerMessage = $"{nameof(position1.Salary)} != {nameof(position2.Salary)}";
            return false;
        }
        
        return true;
    }
    
    /// <summary>
    /// Gets result of comparison of two employee department instances. 
    /// </summary>
    /// <param name="employeeDepartment1">The instance of first employee department to compare.</param>
    /// <param name="employeeDepartment2">The instance of second employee department to compare.</param>
    /// <param name="innerMessage">The out massage to return text details of comparison.</param>
    /// <returns>Returns result of comparison, true - instances are equal, either - false.</returns>
    private static bool Equals(EmployeeDepartment employeeDepartment1, EmployeeDepartment employeeDepartment2, out string innerMessage)
    {
        innerMessage = string.Empty;
        
        if (employeeDepartment1.EmployeeNo != employeeDepartment2.EmployeeNo)
        {
            innerMessage = $"{nameof(employeeDepartment1.EmployeeNo)} != {nameof(employeeDepartment2.EmployeeNo)}";
            return false;
        }

        if (!Equals(employeeDepartment1.Department, employeeDepartment2.Department, out innerMessage))
        {
            innerMessage = $"{nameof(employeeDepartment1.Department)} != {nameof(employeeDepartment2.Department)}";
            return false;
        }
        
        if (employeeDepartment1.From != employeeDepartment2.From)
        {
            innerMessage = $"{nameof(employeeDepartment1.From)} != {nameof(employeeDepartment2.From)}";
            return false;
        }
        
        if (employeeDepartment1.To != employeeDepartment2.To)
        {
            innerMessage = $"{nameof(employeeDepartment1.To)} != {nameof(employeeDepartment2.To)}";
            return false;
        }

        return true;
    }
    
    /// <summary>
    /// Gets result of comparison of two department instances. 
    /// </summary>
    /// <param name="department1">The instance of first department to compare.</param>
    /// <param name="department2">The instance of second department to compare.</param>
    /// <param name="innerMessage">The out massage to return text details of comparison.</param>
    /// <returns>Returns result of comparison, true - instances are equal, either - false.</returns>
    private static bool Equals(Department department1, Department department2, out string innerMessage)
    {
        innerMessage = string.Empty;
        
        if (department1.DepartmentCode != department2.DepartmentCode)
        {
            innerMessage = $"{nameof(department1.DepartmentCode)} != {nameof(department2.DepartmentCode)}";
            return false;
        }

        if (department1.DepartmentName != department2.DepartmentName)
        {
            innerMessage = $"{nameof(department1.DepartmentName)} != {nameof(department2.DepartmentName)}";
            return false;
        }
        
        if (department1.Description != department2.Description)
        {
            innerMessage = $"{nameof(department1.Description)} != {nameof(department2.Description)}";
            return false;
        }
        
        return true;
    }
}