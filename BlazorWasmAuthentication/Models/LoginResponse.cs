﻿namespace BlazorWasmAuthentication.Models
{
    public class LoginResponse
    {
        public required string JwtToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
