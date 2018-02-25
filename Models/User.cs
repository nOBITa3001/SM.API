using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SM.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public DateTime LastActive { get; set; }

        public ICollection<Prediction> Predictions { get; set; }
    }
}