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

        public void UpdateCupom(string? code = null, string? title = null, decimal? percentageUpdated = null)
        {
            base.UpdateCupom(code, title);

            if (percentageUpdated != null)
            {
                if (percentageUpdated <= 0)
                {
                    throw new DomainException("Insert a value above 0.");
                }

                Percentage = percentageUpdated.Value;
            }

            

        }
    }
}
