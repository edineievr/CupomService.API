using System.Security.Cryptography.Xml;
using CupomService.API.Models.Exceptions;

namespace CupomService.API.Models
{
    public abstract class Cupom
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Uses { get; set; }
        public bool IsActive { get; set; }

        protected Cupom()
        {

        }
        protected Cupom(int id, string title, string code, DateTime expirationDate, int uses)
        {
            if (id <= 0)
            {
                throw new DomainException("Id must be higher than 0.");
            }

            if (string.IsNullOrEmpty(title))
            {
                throw new DomainException("Title cannot be empty.");
            }

            if (string.IsNullOrEmpty(code))
            {
                throw new DomainException("Code cannot be empty");
            }

            if (expirationDate < DateTime.Now)
            {
                throw new DomainException("Invalid expiratin date.");
            }

            if (uses <= 0)
            {
                throw new DomainException("The cupom must have at least one use.");
            }

            Id = id;
            Title = title;
            Code = code;
            ExpirationDate = expirationDate;
            Uses = uses;
            IsActive = true;
        }
        public void SetInactive()
        {
            IsActive = false;
        }

        public virtual void UpdateCupom(string? code = null, string? title = null)
        {

            if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(title))
            {
                throw new DomainException("Provide at least one value to update.");
            }

            if (!string.IsNullOrEmpty(code))
            {
                Code = code;
            }

            if (!string.IsNullOrEmpty(title))
            {
                Title = title;
            }

        }
    }
}
