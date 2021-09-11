namespace Application.Common.Models
{
    public class AppliedAmount
         : IEntity
    {
        public long Id { get; set; }

        public long LowerBound { get; set; }

        public long UpperBound { get; set; }

        public bool Decision { get; set; }
    }
}
