using Blazorise.DataGrid;
using Blazorise;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Trial.Project.Authors;
using Trial.Project.Permissions;
using Volo.Abp.Application.Dtos;
using System.Linq;


namespace Trial.Project.Blazor.Client.Pages
{
    public partial class Author
    {
        private IReadOnlyList<AuthorDto> AuthorList { get; set; }

        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; }
        private string CurrentSorting { get; set; }
        private int TotalCount { get; set; }
        private string Filter { get; set; }

        private bool CanCreateAuthor { get; set; }
        private bool CanEditAuthor { get; set; }
        private bool CanDeleteAuthor { get; set; }

        private CreateUpdateAuthorDto NewAuthor { get; set; }

        private Guid EditingAuthorId { get; set; }
        private CreateUpdateAuthorDto EditingAuthor { get; set; }

        private Modal CreateAuthorModal { get; set; }
        private Modal EditAuthorModal { get; set; }

        private Validations CreateValidationsRef;

        private Validations EditValidationsRef;

        public Author()
        {
            NewAuthor = new CreateUpdateAuthorDto();
            EditingAuthor = new CreateUpdateAuthorDto();
        }

        protected override async Task OnInitializedAsync()
        {
            await SetPermissionsAsync();
            await GetAuthorsAsync();
        }


        private async Task SetPermissionsAsync()
        {
            CanCreateAuthor = await AuthorizationService
                .IsGrantedAnyAsync(ProjectPermissions.Authors.Create);
            CanEditAuthor = await AuthorizationService
                .IsGrantedAnyAsync(ProjectPermissions.Authors.Edit);
            CanDeleteAuthor = await AuthorizationService
                .IsGrantedAnyAsync(ProjectPermissions.Authors.Delete);

        }
        private async Task GetAuthorsAsync()
        {
            var result = await AuthorAppService.GetListAsync(
                new PagedAndSortedAuthorDto
                {
                    MaxResultCount = PageSize,
                    SkipCount = CurrentPage * PageSize,
                    Sorting = CurrentSorting,
                    Filter = this.Filter
                });

            AuthorList = result.Items;
            TotalCount = (int)result.TotalCount;
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<AuthorDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page - 1;

            await GetAuthorsAsync();
            await InvokeAsync(StateHasChanged);
        }

        private void OpenCreateAuthorModal()
        {
            CreateValidationsRef.ClearAll();

            NewAuthor = new CreateUpdateAuthorDto();
            CreateAuthorModal.Show();
        }

        private void CloseCreateAuthorModal()
        {
            CreateAuthorModal.Hide();
        }

        private void OpenEditAuthorModal(AuthorDto author)
        {
            EditValidationsRef.ClearAll();
            EditingAuthorId = author.Id;
            EditingAuthor = ObjectMapper.Map<AuthorDto, CreateUpdateAuthorDto>(author);
            EditAuthorModal.Show();
        }

        private void CloseEditAuthorModal()
        {
            EditAuthorModal.Hide();
        }

        private async Task DeleteAuthorAsync(AuthorDto author)
        {
            var confirmMessage = L["AuthorDeletionConfirmationMessage", author.Name];
            if (!await Message.Confirm(confirmMessage))
            {
                return;
            }

            await AuthorAppService.DeleteAsync(author.Id);
            await GetAuthorsAsync();
        }

        private async Task CreateAuthorAsync()
        {
            if(await CreateValidationsRef.ValidateAll())
            {
                await AuthorAppService.CreateAsync(NewAuthor);
                await GetAuthorsAsync();
                CreateAuthorModal.Hide();
            }
        }

        private async Task UpdateAuthorAsync()
        {
            if(await EditValidationsRef.ValidateAll())
            {
                await AuthorAppService.UpdateAsync(EditingAuthorId, EditingAuthor);
                await GetAuthorsAsync();
                EditAuthorModal.Hide();
            }

        }
    }
}

