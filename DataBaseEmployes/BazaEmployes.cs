namespace Employee
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }

    public class EmployeeDatabase
    {
        private Dictionary<int, Employee> employees;

        public EmployeeDatabase()
        {
            employees = new Dictionary<int, Employee>();
        }

        public void AddEmployee(int id, string firstName, string lastName, string position)
        {
            Employee employee = new Employee
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Position = position
            };

            employees.Add(id, employee);
        }

        public void RemoveEmployee(int id)
        {
            employees.Remove(id);
        }

        public Employee GetEmployee(int id)
        {
            return employees.TryGetValue(id, out Employee employee) ? employee : new Employee();
        }

        public List<Employee> GetEmployee()
        {
            return new List<Employee>(employees.Values);
        }
    }
}
