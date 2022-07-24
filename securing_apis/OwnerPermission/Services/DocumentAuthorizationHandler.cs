﻿using Microsoft.AspNetCore.Authorization;
using OwnerPermission.Models;

namespace OwnerPermission.Services
{
    public class DocumentAuthorizationHandler :
				AuthorizationHandler<SameAuthorRequirement, Document>
	{
		protected override Task HandleRequirementAsync(
			AuthorizationHandlerContext context,
			SameAuthorRequirement requirement,
			Document resource)
		{
			if (context.User.Identity?.Name!.ToLower() == resource.Author)
			{
				context.Succeed(requirement);
			}

			return Task.CompletedTask;
		}
	}
}
