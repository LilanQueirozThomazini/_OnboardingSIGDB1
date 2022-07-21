using OnboardingSIGDB1.Domain.Interfaces;

namespace OnboardingSIGDB1.Domain.Base
{
    public class ValidadorBase<TEntity> where TEntity : class
    {
        public INotificationContext notificationContext { get; set; }
        public TEntity entidade { get; set; }
    }
}
