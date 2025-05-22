using CupomService.API.Models.Exceptions;
using CupomService.API.Models;
using CupomService.API.Services.Interfaces;

namespace CupomService.API.Services
{
    public class CupomService : ICupomService
    {
        private readonly List<Cupom> _cupons = new List<Cupom>();

        public Task CreateCupomAsync(Cupom cupom)
        {
            if (cupom == null)
            {
                throw new DomainException("Invalid cupom.");
            }

            _cupons.Add(cupom);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Cupom>> GetAllAsync()
        {
            return await Task.FromResult(_cupons);
        }

        public Task<Cupom> GetCupomByIdAsync(int id)
        {
            var cupom = _cupons.FirstOrDefault(x => x.Id == id);

            if (cupom == null)
            {
                throw new DomainException("Not found.");
            }

            return Task.FromResult(cupom);
        }
        public async Task<Cupom> GetCupomByCodeAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new DomainException("Code cannot be null, please verify!");
            }

            var cupom = _cupons.Find(x => x.Code == code);

            if (cupom == null)
            {
                throw new DomainException("Not found.");
            }

            return await Task.FromResult(cupom);
        }        

        public async Task<Cupom> UpdatePercentageCupomAsync(int id, string code, string title, decimal percentageUpdated)
        {
            var cupom = await GetCupomByIdAsync(id);

            if (cupom == null)
            {
                throw new DomainException("Cupom not found");
            }

            if (cupom is not PercentageCupom percentageCupom)
            {
                throw new DomainException("Cupom is not of type percentage");
            }

            percentageCupom.UpdateCupom(code, title, percentageUpdated);
            
            return percentageCupom;
        }

        public async Task<Cupom> UpdateFixedValueCupomAsync(int id, string code, string title, decimal valueUpdated)
        {
            var cupom = await GetCupomByIdAsync(id);

            if (cupom == null)
            {
                throw new DomainException("Cupom not found.");
            } 
            
            if (cupom is not FixedValueCupom fixedValueCupom)
            {
                throw new DomainException("Cupom is not of type Fixed Value.");
            }

            fixedValueCupom.UpdateCupom(code, title, valueUpdated);  
            
            return fixedValueCupom;
        }

        public async Task InactivateCupomAsync(int id)
        {
            var cupom = await GetCupomByIdAsync(id);

            if (cupom == null)
            {
                throw new DomainException("Cupom not found.");
            }

            cupom.SetInactive();
        }
    }
}