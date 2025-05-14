using CupomService.API.Models.Exceptions;

namespace CupomService.API.Models
{
    public class PercentageCupom : Cupom
    {
        public decimal Percentage { get; set; }

        public PercentageCupom(int id, string title, string code, DateTime expirationDate, int uses, decimal percentage) :
            base(id, title, code, expirationDate, uses)
        {
            if (percentage <= 0)
            {
                throw new DomainException("Percentage discount cannot be lower than 0.");
            }

            Percentage = percentage;
        }
    }
}
