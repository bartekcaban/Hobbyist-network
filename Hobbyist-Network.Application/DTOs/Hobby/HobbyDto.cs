﻿using Hobbyist_Network.Domain.Enums;
using System;

namespace Hobbyist_Network.Application.DTOs.Hobby
{
    public class HobbyDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryIcon { get; set; }
        public Guid UserId { get; set; }
        public Level Level { get; set; }
    }
}
