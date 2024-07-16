using Application.BusinessAspects;
using Application.Features.Auths.Rules;
using Application.Features.BlogComplaints.Rules;
using Application.Features.BlogFavorites.Rules;
using Application.Features.BlogLikeDislikes.Rules;
using Application.Features.Blogs.Rules;
using Application.Features.BlogTags.Rules;
using Application.Features.Categories.Rules;
using Application.Features.CommentComplaints.Rules;
using Application.Features.CommentLikeDislikes.Rules;
using Application.Features.Comments.Rules;
using Application.Features.ContactUsMessages.Rules;
using Application.Features.OperationClaims.Rules;
using Application.Features.Tags.Rules;
using Application.Features.Testimonials.Rules;
using Application.Features.UserOperationClaims.Rules;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.ImageService;
using Application.Services.UserService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<TagBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<UserOperationClaimBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<BlogBusinessRules>();
            services.AddScoped<CommentBusinessRules>();
            services.AddScoped<BlogTagBusinessRules>();
            services.AddScoped<ContactUsMessageBusinessRules>();
            services.AddScoped<CommentComplaintBusinessRules>();
            services.AddScoped<BlogComplaintBusinessRules>();
            services.AddScoped<BlogLikeDislikeBusinessRules>();
            services.AddScoped<CommentLikeDislikeBusinessRules>();
            services.AddScoped<BlogFavoriteBusinessRules>();
            services.AddScoped<TestimonialBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped<IAuthService, AuthManager>(); 
            services.AddScoped<IUserService, UserManager>(); 
            services.AddScoped<IImageService, ImageManager>();

           


            return services;

        }
    }
}
