using System.Globalization;
using Lisova.Services.Context.Data;
using Lisova.Services.Models;
using Lisova.Services.Repositories;
using Lisova.Services.Tests.Comparers;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Lisova.Services.Tests.Repositories;

[TestFixture]
public sealed class EmployeeRepositoryReadTests
{
    private const string ConnectionString = "Data Source=./LisovaEmployees.db;Mode=Memory;Cache=Shared;";
    
    private static readonly object[] GetEmployees =
    {
        new object[] {
            new long[]
            {
                10000, 10001, 10002, 10003, 10004, 10005, 10006, 10007, 10008, 10009, 
                10010, 10011, 10012, 10013, 10014, 10015, 10016, 10017, 10018, 10019,
                10020, 10021, 10022, 10023, 10024, 10025, 10026, 10027, 10028, 10029,
                10030, 10031, 10032, 10033, 10034, 10035, 10036, 10037, 10038, 10039,
                10040, 10041, 10042, 10043, 10044, 10045, 10046, 10047, 10048, 10049,
                10050, 10051, 10052, 10053, 10054, 10055, 10056, 10057, 10058, 10059,
                10060, 10061, 10062, 10063, 10064, 10065, 10066, 10067, 10068, 10069,
                10070, 10071, 10072, 10073, 10074, 10075, 10076, 10077, 10078, 10079,
                10080, 10081, 10082, 10083, 10084, 10085, 10086, 10087, 10088, 10089,
                10090, 10091, 10092, 10093, 10094, 10095, 10096, 10097, 10098, 10099,
                10100, 10101, 10102, 10003, 10104, 10105, 10106, 10107, 10108, 10109,
                10110, 10111, 10112, 10113, 10114, 10115, 10116, 10117, 10118, 10119,
                10120, 10121, 10122, 10123, 10124, 10125, 10126, 10127
            } 
        }
    };
    
    private static readonly object[] GetEmployeesRange =
    {
        new object[] { 0, 1, new long[] { 10000 } },
        new object[] { 0, 10, new long[] { 10000, 10001, 10002, 10003, 10004, 10005, 10006, 10007, 10008, 10009 } },
        new object[] { 0, 20, new long[] { 10000, 10001, 10002, 10003, 10004, 10005, 10006, 10007, 10008, 10009, 10010, 10011, 10012, 10013, 10014, 10015, 10016, 10017, 10018, 10019 } },
        new object[] { 10, 1, new long[] { 10010 } },
        new object[] { 10, 10, new long[] { 10010, 10011, 10012, 10013, 10014, 10015, 10016, 10017, 10018, 10019 } },
        new object[] { 10, 20, new long[] { 10010, 10011, 10012, 10013, 10014, 10015, 10016, 10017, 10018, 10019, 10020, 10021, 10022, 10023, 10024, 10025, 10026, 10027, 10028, 10029 } }
    };

    private EmployeeRepository _employeeRepository = default!;
    
    [TestCaseSource(nameof(GetEmployees))]
    public void GetEmployees_ArgumentsAreValid_ReturnsEmployeesList(long[] employeeNo)
    {
        // Act
        var employees = _employeeRepository.GetEmployees();

        // Assert
        Assert.That(employees, Has.Count.EqualTo(employeeNo.Length));

        for (var i = 0; i < employees.Count; i++)
        {
            Assert.That(employees[i].EmployeeNo, Is.EqualTo(employeeNo[i]));
        }
    }
    
    [TestCase(-1, 1)]
    [TestCase(0, -1)]
    [TestCase(0, 0)]
    public void GetEmployeesRange_ArgumentsAreOutOfRange_ThrowsArgumentOutOfRangeException(int skip, int count)
    {
        _ = Assert.Throws<ArgumentOutOfRangeException>( () => _employeeRepository.GetEmployeesRange(skip: skip, count: count));
    }
    
    [TestCaseSource(nameof(GetEmployeesRange))]
    public void GetEmployeesRange_ArgumentsAreValid_ReturnsEmployeesList(int skip, int count, long[] employeeNo)
    {
        // Act
        var employees = _employeeRepository.GetEmployeesRange(skip: skip, count: count);

        // Assert
        Assert.That(employees, Has.Count.EqualTo(employeeNo.Length));

        for (var i = 0; i < employees.Count; i++)
        {
            Assert.That(employees[i].EmployeeNo, Is.EqualTo(employeeNo[i]));
        }
    }
    
    [Test]
    public void GetOrderAsync_OrderIsNotExist_ThrowsRepositoryException()
    {
        _ = Assert.Throws<ArgumentNullException>( () => _employeeRepository.GetEmployee(employeeNo: 0));
    }

    [TestCaseSource(nameof(GetEmployeeData))]
    public async Task GetOrderAsync_OrderIsExist_ReturnsOrder(Employee expected)
    {
        // Act
        var actual = _employeeRepository.GetEmployee(employeeNo: expected.EmployeeNo);

        // Assert
        Assert.That(actual, Is.Not.Null);
        var compareResult = EmployeeComparer.Compare(actual!, expected, out string message);
        Assert.That(compareResult, Is.True, message);
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var contextOptions = new DbContextOptionsBuilder<LisovaContext>().UseSqlite(ConnectionString);
        var context = new LisovaContext(contextOptions.Options);
        _employeeRepository = new EmployeeRepository(context);
    }
    
    private static IEnumerable<Employee> GetEmployeeData()
    {
        var cultureInfo = new CultureInfo("en-US")
        {
            NumberFormat =
            {
                CurrencyDecimalSeparator = ".",
                CurrencyGroupSeparator = ","
            }
        };

        var employee = new Employee(10000)
        {
            Fullname = "Walker Gonzales",
            BirthDate = DateTime.Parse("1995-02-19"),
            Location = "United Kingdom",
            HomeAddress = "Ap #582-441 Ac Ave",
            ContactPhone = "(8213) 25721"
        };
        
        employee.EmployeePositions.Add(new EmployeePosition(10001, new Position("YMB281_22")
        {
            PositionName = "Technical",
            Description = "malesuada augue ut lacus. Nulla tincidunt, neque vitae semper egestas,",
            Salary = decimal.Parse("83,842.81", NumberStyles.Currency, new CultureInfo("en-US")
            {
                NumberFormat = { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = "," }
            }),
        })
        {
            From = DateTime.Parse("2021-05-18"),
            To = DateTime.Parse("2008-08-24")
        });
        
        employee.EmployeeDepartments.Add(new EmployeeDepartment(10001, new Department("EDH228")
        {
            DepartmentName = "Accounting",
            Description = "sit amet diam eu dolor egestas",
        })
        {
            From = DateTime.Parse("2000-10-14"),
            To = DateTime.Parse("1995-01-18")
        });

        yield return employee;
    }
}