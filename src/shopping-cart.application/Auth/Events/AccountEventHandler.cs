using shopping_cart.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Domain.Repositories;
using VietBND.Domain.Uow;
using VietBND.MediatR.Events;

namespace shopping_cart.application.Auth.Events
{
    public class StoreRefreshTokenEvent : IEvent
    {
        public long UserId { get; set; }
        public string Token { get; set; }
        public string IpAddress { get; set; }
    }
    public class AccountEventHandler : IEventHandler<StoreRefreshTokenEvent>
    {
        private readonly IRepository<RefreshToken, Guid> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountEventHandler(IRepository<RefreshToken, Guid> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(StoreRefreshTokenEvent notification, CancellationToken cancellationToken)
        {
            await _repository.InsertAsync(new RefreshToken()
            {
                Expires = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                Token = notification.Token,
                UserId = notification.UserId
            });
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
