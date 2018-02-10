using System;

namespace SM.API.DTOs
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime LastActive { get; set; }
    }
}
