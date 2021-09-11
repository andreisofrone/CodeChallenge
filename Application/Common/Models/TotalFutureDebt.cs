namespace Application.Common.Models
{
    public class TotalFutureDebt
           : IEntity
    {
        public long Id { get; set; }

        public long LowerBound { get; set; }

        public long UpperBound { get; set; }

        public int InterestRate { get; set; }
    }
}
