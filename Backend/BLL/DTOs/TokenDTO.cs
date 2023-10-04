using System;
namespace BLL.DTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }
        public string Tkey { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public string UserEmail { get; set; }
    }
}
