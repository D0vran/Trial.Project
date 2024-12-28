using Trial.Project.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Trial.Project.Permissions;

public class ProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProjectPermissions.GroupName, L("Permission:BookStore"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ProjectPermissions.MyPermission1, L("Permission:MyPermission1"));

        var permissions = myGroup.AddPermission(ProjectPermissions.Books.Default, L("Permission:Books"));
        permissions.AddChild(ProjectPermissions.Books.Create, L("Permission:Books.Create"));
        permissions.AddChild(ProjectPermissions.Books.Edit, L("Permission:Books.Edit"));
        permissions.AddChild(ProjectPermissions.Books.Delete, L("Permission:Books.Delete"));
        
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProjectResource>(name);
    }
}
