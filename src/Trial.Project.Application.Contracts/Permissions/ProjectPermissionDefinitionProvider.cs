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

        var bookPermissions = myGroup.AddPermission(ProjectPermissions.Books.Default, L("Permission:Books"));
        bookPermissions.AddChild(ProjectPermissions.Books.Create, L("Permission:Books.Create"));
        bookPermissions.AddChild(ProjectPermissions.Books.Edit, L("Permission:Books.Edit"));
        bookPermissions.AddChild(ProjectPermissions.Books.Delete, L("Permission:Books.Delete"));


        var authorPermissions = myGroup.AddPermission(ProjectPermissions.Authors.Default, L("Permission:Authors"));
        authorPermissions.AddChild(ProjectPermissions.Authors.Create, L("Permission:Authors.Create"));
        authorPermissions.AddChild(ProjectPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorPermissions.AddChild(ProjectPermissions.Authors.Delete, L("Permission:Authors.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProjectResource>(name);
    }
}
