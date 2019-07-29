﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AHP.Service.Common;
using AHP.Repository.Common;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Service
{
    public class CriteriaService : ICriteriaService
    {
        #region Constructors
        public CriteriaService(ICriteriaRepository repository, IUnitOfWorkFactory uowFactory)
        {
            this.Repository = repository;
            this.uowFactory = uowFactory;
        }
        #endregion Constructors

        #region Properties        
        protected ICriteriaRepository Repository { get; private set; }
        protected IUnitOfWorkFactory uowFactory; 
        #endregion Properties

        #region Methods

        public async Task<bool> AddCriteriaAsync(ICriteriaModel criteria)
        {
            using (var uow = uowFactory.CreateUnitOfWork())
            {

                Repository.InsertCriteria(criteria);
                await Repository.SaveAsync();
                uow.Commit();
            }
            return true;
        }
        public async Task<bool> DeleteCriteria(int criteriaId)
        {
            using (var uow = uowFactory.CreateUnitOfWork())
            {
                await Repository.DeleteCriteriaAsync(criteriaId);
                await Repository.SaveAsync();
                uow.Commit();
            }
            return true;
        }
        public async Task<List<ICriteriaModel>> GetCriterias(int pageNumber, int pageSize = 10)
        {
            var criterias = await Repository.GetCriteriasAsync(pageNumber, pageSize);
            return criterias;
        }
        public async Task<List<ICriteriaModel>> GetCriteriasByProjectId(int projectId,int pageNumber, int pageSize = 10)
        {
            var criterias = await Repository.GetCriteriasByProjectId(projectId, pageNumber, pageSize);
            return criterias;
        }

        public async Task<List<ICriteriaModel>> GetCriteriasByProjectIdWithCRaAR(int projectId)
        {
            var criterias = await Repository.GetCriteriasByProjectIdWithCRaAR(projectId);
            return criterias;
        }

        public async Task<bool> AddRange(List<ICriteriaModel> criteria)
        {
            using (var uow = uowFactory.CreateUnitOfWork())
            {
                Repository.AddRange(criteria);
                await Repository.SaveAsync();
                uow.Commit();
            }
            return true;
        }

        #endregion Methods

    }
}
