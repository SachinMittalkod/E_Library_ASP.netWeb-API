using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LibraryManagementSystem.API.DataModel.Entities
{
   
 
        public static class Policies
        {
            public static AuthorizationPolicy AdminPolicy()
            {
                return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                       .RequireRole(UserRoles.Admin)
                                                       .Build();
            }

            public static AuthorizationPolicy UserPolicy()
            {
                return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                       .RequireRole(UserRoles.User)
                                                       .Build();
            }
        }
    
}
