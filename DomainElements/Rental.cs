class Rental
{
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentDate { get; set; }
    public int DurationDays { get; set; }
    public DateTime? ReturnDate { get; set; }

    public DateTime DueDate => RentDate.AddDays(DurationDays);
    public bool IsReturnedOnTime => ReturnDate.HasValue && ReturnDate.Value <= DueDate;
}