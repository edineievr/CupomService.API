using CupomService.API.Models;

namespace CupomService.API.Services.Interfaces
{
    public interface ICupomService
    {
        Task CreateCupomAsync(Cupom cupom);
        Task<IEnumerable<Cupom>> GetAllAsync();
        Task<Cupom> GetCupomByIdAsync(int id);        
        Task<Cupom> GetCupomByCodeAsync(string code);
        Task<Cupom> UpdateCupomAsync(int id, string code, string title);
        Task<Cupom> UpdatePercentageCupomAsync(int id, string code, string title, decimal percentageUpdated);
        Task<Cupom> UpdateFixedValueCupomAsync(int id, string code, string title, decimal valueUpdated);
        Task InactivateCupomAsync(int id);
    }
}
