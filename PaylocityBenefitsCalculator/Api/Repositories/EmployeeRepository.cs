﻿using Api.Models;

namespace Api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IEnumerable<Employee> _employees;
        public EmployeeRepository() 
        {
            _employees = new List<Employee>
            {
                new()
                {
                    Id = 1,
                    FirstName = "LeBron",
                    LastName = "James",
                    Salary = 75420.99m,
                    DateOfBirth = new DateTime(1984, 12, 30)
                },
                new()
                {
                    Id = 2,
                    FirstName = "Ja",
                    LastName = "Morant",
                    Salary = 92365.22m,
                    DateOfBirth = new DateTime(1999, 8, 10),
                    Dependents = new List<Dependent>
                    {
                        new()
                        {
                            Id = 1,
                            FirstName = "Spouse",
                            LastName = "Morant",
                            Relationship = Relationship.Spouse,
                            DateOfBirth = new DateTime(1998, 3, 3)
                        },
                        new()
                        {
                            Id = 2,
                            FirstName = "Child1",
                            LastName = "Morant",
                            Relationship = Relationship.Child,
                            DateOfBirth = new DateTime(2020, 6, 23)
                        },
                        new()
                        {
                            Id = 3,
                            FirstName = "Child2",
                            LastName = "Morant",
                            Relationship = Relationship.Child,
                            DateOfBirth = new DateTime(2021, 5, 18)
                        }
                    }
                },
                new()
                {
                    Id = 3,
                    FirstName = "Michael",
                    LastName = "Jordan",
                    Salary = 143211.12m,
                    DateOfBirth = new DateTime(1963, 2, 17),
                    Dependents = new List<Dependent>
                    {
                        new()
                        {
                            Id = 4,
                            FirstName = "DP",
                            LastName = "Jordan",
                            Relationship = Relationship.DomesticPartner,
                            DateOfBirth = new DateTime(1974, 1, 2)
                        }
                    }
                }
            };
        }
        public Employee GetEmployeeByID(int id)
        {
            return _employees.First(x => x.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}
