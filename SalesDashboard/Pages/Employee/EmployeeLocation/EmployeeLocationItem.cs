namespace SalesDashboard.Pages.Employee.EmployeeLocation
{
    public class EmployeeLocationItem
    {
        public required int BusinessEntityId { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string JobTitle { get; set; }

        public required string DepartmentName { get; set; }

        public required string? Address { get; set; }

        public required string? City { get; set; }

        public required string? StateProvinceName { get; set; }

        public required string? CountryRegionName { get; set; }

        public required double? Latitude { get; set; }

        public required double? Longitude { get; set; }
    }
}
