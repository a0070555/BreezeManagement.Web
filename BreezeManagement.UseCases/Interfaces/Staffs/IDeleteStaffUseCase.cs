namespace BreezeManagement.UseCases.Interfaces.Staffs
{
    public interface IDeleteStaffUseCase
    {
        Task ExecuteAsync(int staffId);
    }
}