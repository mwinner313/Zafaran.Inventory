using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Zafaran.Warehouse.Core.Contracts.Repositories;
using Zafaran.Warehouse.Core.Contracts.Services;
using Zafaran.Warehouse.Core.Dtos.Warehouses;
using Zafaran.WareHouse.Core.Dtos;

namespace Zafaran.Warehouse.Core.Services.Warehouses
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IRepository<WareHouse.Core.Entities.Warehouse, int> _wareHouseRepository;
        private readonly IMapper _mapper;

        public WarehouseService(IRepository<WareHouse.Core.Entities.Warehouse, int> wareHouseRepository, IMapper mapper)
        {
            _wareHouseRepository = wareHouseRepository;
            _mapper = mapper;
        }

        public async Task<Response> Add(WarehouseAddOrUpdateModel model)
        {
            await _wareHouseRepository.AddAsync(_mapper.Map<WareHouse.Core.Entities.Warehouse>(model));
            return Response.Success();
        }

        public async Task<Response> Edit(WarehouseAddOrUpdateModel model)
        {
            var exiting =await _wareHouseRepository.GetByIdAsync(model.Id);
            _mapper.Map(model, exiting);
            await _wareHouseRepository.UpdateAsync(exiting);
            return Response.Success();
        }

        public async Task<Response> Delete(int id)
        {
            var exiting = await _wareHouseRepository.GetByIdAsync(id);
            await _wareHouseRepository.DeleteAsync(exiting);
            return Response.Success();
        }

        public async Task<List<WarehouseViewModel>> GetAll()
        {
            return await _wareHouseRepository.GetQueriable()
                .ProjectTo<WarehouseViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<WarehouseViewModel> GetById(int id)
        {
            return _mapper.Map<WarehouseViewModel> ( await _wareHouseRepository.GetByIdAsync(id));
        }
    }
}