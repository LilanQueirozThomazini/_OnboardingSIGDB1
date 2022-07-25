using OnboardingSIGDB1.Domain.Interfaces;

namespace OnboardingSIGDB1.Domain.Base
{
    public class ValidadorBase<T>: IValidadorBase<T> where T : class
    {
        public INotificationContext _notificationContext { get; set; }
        public T entidade { get; set; }
    }
}
