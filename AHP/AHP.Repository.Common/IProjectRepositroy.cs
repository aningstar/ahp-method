﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHP.DAL.Entities;
using AHP.Model.Common;
using AHP.Model.Common.Model_Interfaces;

namespace AHP.Repository.Common
{
    public interface IProjectRepository
    {
        //Interface body

        #region Methods

        //Methods for interface

        //Methods for getting project
        //Example for checking if first project was added
        Task<IProjectModel> CompareProjects(string projectName, string userName);
        Task<List<IProjectModel>> GetProjectsAsync(int PageNumber, int PageSize = 10);
        Task<IProjectModel> GetProjectByIdAsync(Guid ProjectId);
        Task<IProjectModel> InsertProject(IProjectModel project);
        Task<IProjectModel> GetProjectsByIdWithAandC(Guid id);
        Task<IProjectModel> UpdateProject(IProjectModel project);
        Task<bool> DeleteProject(Guid ProjectId);
        Task<int> CountProjects();
      
        
        #endregion Methods
    }
}
