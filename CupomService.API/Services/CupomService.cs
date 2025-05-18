using CupomService.API.Models.Exceptions;
using CupomService.API.Models;
using CupomService.API.Services.Interfaces;

namespace CupomService.API.Services
{
    public class CupomService : ICupomService
    {
        private readonly List<Cupom> _cupons = new List<Cupom>();

        public async Task CreateCupomAsync(Cupom cupom)
        {
            if (cupom == null)
            {
                throw new DomainException("Invalid cupom.");
            }

            _cupons.Add(cupom);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Cupom>> GetAllAsync()
        {
            return await Task.FromResult(_cupons);
        }

        public async Task<Cupom> GetCupomByIdAsync(int id)
        {
            var cupom = _cupons.Find(x => x.Id == id);

            if (cupom == null)
            {
                throw new DomainException("Not found.");
            }

            return await Task.FromResult(cupom);
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

        /*public async Task<Cupom> UpdateCupomAsync(int id, string code, string title)
        {
            var cupom = await GetCupomByIdAsync(id);

            if (cupom == null)
            {
                throw new DomainException("Cupom not found.");
            }

            cupom.UpdateCupom(code, title);


        }*/

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