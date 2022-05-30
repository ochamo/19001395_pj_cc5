using Domain.Repository;
using Infrastructure.Dto.Pago;
using Infrastructure.Model.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Payment
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ISqlDataAccess Db;

        public PaymentRepository(ISqlDataAccess db)
        {
            Db = db;
        }

        public Task<int> CreatePayment(CreatePagoDto paymentDto) => Db.SaveData(Procedures.InsertPago, paymentDto);
        public Task<PagoModel> GetPago(GetPagoDto getPagoDto) => Db.Single<PagoModel, GetPagoDto>(Procedures.GetPago, getPagoDto);
    }
}
