using EmployeeRecordsAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecordsAPI.Helpers
{
    public static class CreateResponse
    {
        public static UserManagerResponse Create(string Message, bool IsSuccess, IEnumerable<string> Errors)
        {
            UserManagerResponse response = new UserManagerResponse
            {
                Message = Message,
                IsSuccess = IsSuccess,
                Errors = Errors
            };

            return response;
        }
    }
}
