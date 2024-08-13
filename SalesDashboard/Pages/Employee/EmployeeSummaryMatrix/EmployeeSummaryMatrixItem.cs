namespace SalesDashboard.Pages.Employee.EmployeeSummaryMatrix
{
    public class EmployeeSummaryMatrixItem
    {
        public required string DepartmentName { get; set; }

        public required string EmployeeName { get; set; }

        public required int Age { get; set; }

        public required double YearsOfEmployment { get; set; }

        public required double VacationDaysPerYear { get; set; }

        public required double SickLeaveDaysPerYear { get; set; }

        public required decimal MonthlySalary { get; set; }
    }
}
