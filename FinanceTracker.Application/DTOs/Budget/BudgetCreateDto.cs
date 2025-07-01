namespace FinanceTracker.Application.DTOs.Budget
{
    public class BudgetCreateDto
    {
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Limit { get; set; }
    }
}