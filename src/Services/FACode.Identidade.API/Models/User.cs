using System;
using Microsoft.AspNetCore.Identity;

namespace FACode.Identidade.API.Models
{
    public class User : IdentityUser<Guid>
    {
        public virtual string Nome { get; set; }
        public virtual string Responsabilidade { get; set; }
        public virtual byte[] Avatar { get; set; }
    }
}