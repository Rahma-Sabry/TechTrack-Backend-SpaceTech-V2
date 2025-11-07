using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Domain.Common.Errors;
using TechPathNavigator.Domain.Common.Messages;
using TechTrack.Domain.DTOs.CompanyTechnology;
using TechTrack.Domain.Interfaces.IRepo;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.Domain.Models;
using TechTrack.DTOs;
using TechTrack.Infrastructure.Extensions;
using TechTrack.Infrastructure.Service;

public class CompanyTechnologyService : ICompanyTechnologyService
{
    private readonly ICompanyTechnologyRepository _repo;

    public CompanyTechnologyService(ICompanyTechnologyRepository repo)
    {
        _repo = repo;
    }

    public async Task<string> CreateAsync(CompanyTechnologyCreateDto dto)
    {
        if (await _repo.ExistsPairAsync(dto.CompanyId, dto.TechnologyId))
            return ErrorMessages.CompanyTechnology_PairExists;

        var companyTech = dto.ToModel();

        await _repo.AddAsync(companyTech);
        return ApiMessages.CompanyTechnologyCreated;
    }

    public async Task<string> DeleteAsync(int id)
    {
        var ct = await _repo.GetByIdAsync(id);
        if (ct == null) return ErrorMessages.CompanyTechnology_CompanyInvalid;

        await _repo.DeleteAsync(ct);
        return ApiMessages.CompanyTechnologyDeleted;
    }

    public async Task<IEnumerable<CompanyTechnologyGetDto>> GetAllAsync()
    {
        var cts = await _repo.GetAllAsync();
        return cts.Select(ct => ct.ToGetDto());
    }

    public async Task<CompanyTechnologyGetDto?> GetByIdAsync(int id)
    {
        var ct = await _repo.GetByIdAsync(id);
        if (ct == null) return null;
        return ct.ToGetDto();
    }

    public async Task<string> UpdateAsync(int id, CompanyTechnologyUpdateDto dto)
    {
        var ct = await _repo.GetByIdAsync(id);
        if (ct == null) return ErrorMessages.CompanyTechnology_CompanyInvalid;

        ct = dto.ToModel(ct);

        await _repo.UpdateAsync(ct);
        return ApiMessages.CompanyTechnologyUpdated;
    }
}
