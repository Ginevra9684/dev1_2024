class Transaction
{
    public int Id { get; set; }

    public User User { get; set; }

    public Subscription Type { get; set; }

    public DateTime Date { get; set; }
}