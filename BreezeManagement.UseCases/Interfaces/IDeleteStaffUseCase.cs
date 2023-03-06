namespace BreezeManagement.UseCases.Interfaces
{
    public interface IDeleteStaffUseCase
    {
        Task ExecuteAsync(int staffId);
    }
}