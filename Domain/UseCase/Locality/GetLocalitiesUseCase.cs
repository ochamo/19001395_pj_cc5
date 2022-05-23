using Business.UseCase;
using Domain.Repository;
using Infrastructure;
using Infrastructure.Dto.Locality;
using Infrastructure.Model;
using Infrastructure.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Locality
{
    public class GetLocalitiesUseCase : BaseUseCase<None, Result<List<LocalityModel>>>
    {
        private readonly ILocalityRepository LocalityRepository;

        public GetLocalitiesUseCase(ILocalityRepository localityRepository)
        {
            LocalityRepository = localityRepository;
        }

        public override async Task<Result<List<LocalityModel>>> Execute(None p)
        { 
            try
            {
                var localities = new List<LocalityModel>();
                var departments = await LocalityRepository.GetDepartments();

                foreach(var department in departments)
                {
                    var munis = await LocalityRepository.GetMunis(new GetMuniDTO(department.IdDep));
                    localities.Add(new LocalityModel() {
                        IdDep = department.IdDep,
                        NombreDep = department.NombreDep,
                        munis = munis
                    });
                }

                return Result.Ok(localities);

            } catch (Exception ex)
            {
                return Result.Fail<List<LocalityModel>>(new ErrorModel(ErrorCodes.LocalitiesNotLoaded));
            }
        }
    }
}
