namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IValidadorBase<T> where T : class
    {
        INotificationContext _notificationContext { get; set; }
        T entidade { get; set; }
    }
}
