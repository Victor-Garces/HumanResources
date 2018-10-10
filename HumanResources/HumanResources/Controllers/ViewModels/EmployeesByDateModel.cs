using System;

namespace HumanResources.Controllers.ViewModels
{
    public sealed class EmployeesByDateModel
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
