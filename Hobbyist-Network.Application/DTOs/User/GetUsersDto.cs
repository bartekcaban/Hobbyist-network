using System;
using System.Collections.Generic;
using System.Text;
using Hobbyist_Network.Domain.Entities;

namespace Hobbyist_Network.Application.DTOs.User
{
    public class GetUsersDto
    {
        public GetUsersDto(int key, Domain.Entities.User value)
        {
            Key = key;
            Value = value;
        }

        public int Key { get; set; }
        public Domain.Entities.User Value { get; set; }
    }
}
