using MediatR;

namespace Hobbyist_Network.Application.Commands.HobbyCategory
{
    public class AddHobbyCategoryCommand : IRequest
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
