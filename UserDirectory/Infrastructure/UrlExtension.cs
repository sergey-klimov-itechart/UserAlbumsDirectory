﻿using Microsoft.AspNetCore.Http;

namespace UserDirectory.Infrastructure
{
    public static class UrlExtension
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue
                ? $"{request.Path}{request.QueryString}"
                : request.Path.ToString();
    }
}