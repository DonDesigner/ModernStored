using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.API.Security
{
    public class TokenOptions
    {
        public string Issuer { get; set; } //Emissor - Quem está pedindo o Token
        public string Subject { get; set; } //Assunto
        public string Audience { get; set; } // Quem está recebendo o Token
        public DateTime NotBefore { get; set; } = DateTime.UtcNow; //Não antes que
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow; // Emitido em... //quando foi pedido
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromDays(2); //valido por...
        public DateTime Expiration => IssuedAt.Add(ValidFor);

        public Func<Task<string>> JtiGenerator => () => Task.FromResult(Guid.NewGuid().ToString());

        public SigningCredentials SigningCredentials { get; set; }

    }
}
