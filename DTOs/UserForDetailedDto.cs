using System;

namespace SM.API.DTOs
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public DateTime LastActive { get; set; }
    }
}