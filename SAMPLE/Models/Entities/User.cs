using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SAMPLE.Models.Entities
{
    [JsonObject(IsReference = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public string ImageName { get; set; }
        [AllowNull]
        public string Token { get; set; }
        [AllowNull]
        public string RefreshToken { get; set; }
        [AllowNull]
        public DateTime? TokenExpire { get; set; }
        [AllowNull]
        public DateTime? RefreshTokenExpire { get; set; }
    }
}
