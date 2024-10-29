using MediatR;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Car.Commands
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommnad, string>
    {
        private readonly ICarRepository _carRepository;
        public DeleteCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<string> Handle(DeleteCarCommnad request, CancellationToken cancellationToken)
        {
             await _carRepository.DeleteAsync(request.Car_ID);
            return "Success";
        }
    }
}
