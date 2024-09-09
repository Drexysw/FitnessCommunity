﻿namespace FitnessCommunity.Infrastructure.Database.Abstractions
{
    public class JwtOptions 
    {
        public string? Issuer { get; init; }
        public string? Audience { get; init; }
        public string? Key { get; init; }
    }
}
