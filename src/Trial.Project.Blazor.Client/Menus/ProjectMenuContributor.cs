using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Trial.Project.Localization;
using Trial.Project.MultiTenancy;
using Trial.Project.Permissions;
using Volo.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace Trial.Project.Blazor.Client.Menus;

public class ProjectMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public ProjectMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<ProjectResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                ProjectMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home"
            )
        );
        var bookStoreMenu = new ApplicationMenuItem(
                "BookStore",
                l["Menu:BookStore"],
                icon: "fa fa:book"
                );
        context.Menu.AddItem(bookStoreMenu);

        if(await context.IsGrantedAsync(ProjectPermissions.Books.Default))
        {
            bookStoreMenu.AddItem(
                new ApplicationMenuItem(
                "BookStore.Books",
                l["Menu:Books"],
                url: "/books"
                ));
        }
        //if (await context.IsGrantedAsync(ProjectPermissions.Authors.Default))
        //{
        bookStoreMenu.AddItem(
            new ApplicationMenuItem(
                "BookStore.Authors",
                l["Menu:Authors"],
                url: "/authors"
                ));
        //}

        var administration = context.Menu.GetAdministration();

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        
    }

    private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        if (!OperatingSystem.IsBrowser())
        {
            return Task.CompletedTask;
        }

        var authServerUrl = _configuration["AuthServer:Authority"] ?? "";
        var accountStringLocalizer = context.GetLocalizer<AccountResource>();

        context.Menu.AddItem(new ApplicationMenuItem(
                "Account.Manage",
                accountStringLocalizer["MyAccount"],
                $"{authServerUrl.EnsureEndsWith('/')}Account/Manage",
                icon: "fa fa-cog",
                order: 1000,
                target: "_blank")
            .RequireAuthenticated());

        return Task.CompletedTask;
    }
}
