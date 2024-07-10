using Application.Localization;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Application.Extensions
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("Accept-Language"))
            {
                var cultureHeader = context.Request.Headers["Accept-Language"];

                if (cultureHeader.Any())
                {
                    var requestLanguage = cultureHeader.First().Split(',').First().Trim();
                    var language = LocalizationConstants.SupportedLanguages.FirstOrDefault(x => x.Code == requestLanguage)?.Code ?? LocalizationConstants.DefaultLanguague;

                    var culture = new CultureInfo(language);
                    CultureInfo.CurrentCulture = culture;
                    CultureInfo.CurrentUICulture = culture;
                }
            }

            await _next(context);
        }
    }
}
