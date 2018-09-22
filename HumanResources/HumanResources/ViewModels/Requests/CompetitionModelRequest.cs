using HumanResources.Enums;

namespace HumanResources.ViewModels.Requests
{
    public sealed class CompetitionModelRequest
    {
        public string Description { get; set; }
        public CompetitionStatus Status { get; set; }
    }
}
