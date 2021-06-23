using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Utility
{
    public static class AutoSolutionStoreProcedureUtility
    {
        public const string InsertAutoModel = "InsertAutoModel";
        public const string SelectAutoModel = "SelectAutoModel";
        public const string SelectAutoVersion = "SelectAutoVersion";
        public const string spGetAutoVersionLookUp = "spGetAutoVersionLookUp";
        
        public const string InsertRole = "spInsertRole";
        public const string UpdateRole = "spUpdateRole";
        public const string GetPagePermissions = "spGetPagePermissions";

        public const string spInsertUser = "spInsertUser";

        public const string spGetOnRoadPrice = "spGetOnRoadPrice";

        public static string spSelectAutoSpecification = "spSelectAutoSpecification";
    }


}
