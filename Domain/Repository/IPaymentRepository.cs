using Infrastructure.Dto.Pago;
using Infrastructure.Model.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IPaymentRepository
    {
        public Task<int> CreatePayment(CreatePagoDto paymentDto);

        public Task<PagoModel> GetPago(GetPagoDto getPagoDto);

    }
}
