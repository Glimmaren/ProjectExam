namespace Customer.Interfaces
{
    public interface IUnitOfWork
    {
        IRoleRepository RoleRepository { get; }
        ICompanyGrouprRepository CompanyGroupRepository { get; }
        ICompanyCategoryRepository CompanyCategoryRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IPersonRepository PersonRepository { get; }

        Task<bool> CompleteAsync();
        bool HasChanges();
    }
}
