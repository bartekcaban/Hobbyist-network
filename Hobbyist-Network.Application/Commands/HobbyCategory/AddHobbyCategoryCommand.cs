using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Application.Commands.HobbyCategory
{
    class AddHobbyCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }
}
