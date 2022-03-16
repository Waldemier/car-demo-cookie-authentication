using Car.Demo.Common.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Car.Demo.Attributes;

public class AuthorizeUserAttribute: AuthorizeAttribute
{
    public AuthorizeUserAttribute(params RoleTypes[] roles)
    {
        Roles = string.Join(",", roles);
    }
}