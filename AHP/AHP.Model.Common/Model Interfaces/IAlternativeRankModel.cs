﻿using System;

namespace AHP.Model.Common.Model_Interfaces
{
    public interface IAlternativeRankModel
    {

        Guid AlternativeRankId { get; set; }
        int Alternative1 { get; set; }
        int Alternative2 { get; set; }
        float Preference { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }

        Guid CriteriaId { get; set; }
        ICriteriaModel Criteria { get; set; }

    }
}
