class PenaltyService
{
    private const decimal DailyPenalty = 5.0m;

    public decimal CalculatePenalty(Rental rental)
    {
        if (!rental.ReturnDate.HasValue) return 0;
        var overdueDays = (rental.ReturnDate.Value - rental.DueDate).Days;
        return overdueDays > 0 ? overdueDays * DailyPenalty : 0;
    }
}