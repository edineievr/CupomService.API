using CupomService.API.Models.Exceptions;

namespace CupomService.API.Models
{
    public class FixedValueCupom : Cupom
    {
        public decimal Value { get; set; }
        public FixedValueCupom(int id, string title, string code, DateTime expirationDate, int uses, decimal value) : 
            base(id, title, code, expirationDate, uses)
        {
            if (value <= 0)
            {
                throw new DomainException("Discount value cannot be lower than 0.");
            }

            Value = value;
        }

        public void UpdateCupom(string? code = null, string? title = null, decimal? valueUpdated = null)
        {
            base.UpdateCupom(code, title);

            if (valueUpdated != null)
            {
                if (valueUpdated <= 0)
                {
                    throw new DomainException("Insert a value above 0.");
                }

                Value = valueUpdated.Value;
            }

        }
    }
}
