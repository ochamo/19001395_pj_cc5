using BillingReport;
using Business.UseCase;
using Domain.Repository;
using Domain.UseCase.Cellphone;
using Infrastructure;
using Infrastructure.Dto.Address;
using Infrastructure.Dto.Carrito;
using Infrastructure.Dto.Cellphone;
using Infrastructure.Dto.Factura;
using Infrastructure.Dto.Pago;
using Infrastructure.Dto.Pedido;
using Infrastructure.Model;
using Infrastructure.Result;

namespace Domain.UseCase.Factura
{
    public class CreateFacturaUseCase : BaseUseCase<FacturaDTO, Result>
    {
        private readonly ICellphoneRepository CellPhoneRepository;
        private readonly IPedidoRepository PedidoRepository;
        private readonly IFacturaRepository FacturaRepository;
        private readonly IBillingService BillingService;
        private readonly IPaymentRepository PaymentRepository;
        private readonly IAddressRepository AddressRepository;

        public CreateFacturaUseCase(ICellphoneRepository cellPhoneRepository, IPedidoRepository pedidoRepository, IFacturaRepository facturaRepository, IBillingService billingService, IPaymentRepository paymentRepository, IAddressRepository addressRepository)
        {
            CellPhoneRepository = cellPhoneRepository;
            PedidoRepository = pedidoRepository;
            FacturaRepository = facturaRepository;
            BillingService = billingService;
            PaymentRepository = paymentRepository;
            AddressRepository = addressRepository;
        }

        public override async Task<Result> Execute(FacturaDTO p)
        {
            try
            {
                var item = await CellPhoneRepository.GetCellphoneDetail(new GetCellphoneDetailDTO(p.ItemToPurchase));
                var pedidoId = await PedidoRepository.CreatePedido(p.PedidoInfo);

                var pagoId = await PaymentRepository.CreatePayment(p.PagoInfo);

                var createFacturaDto = new CreateFacturaDTO(usuarioId: p.UsuarioId, pagoId: pagoId, pedidoId: pedidoId, nitN: p.NitN, nombreCli: p.NombreCli);

                var facturaId = await FacturaRepository.CreateFactura(createFacturaDto);

                
                await CellPhoneRepository.UpdateStockCellphone(new UpdateStockDto(-1, item.IdCelular));
                await FacturaRepository.CreateFilasFactura(new CreateFacturaFilaDto()
                {
                    Cant = 1,
                    CelularId = item.IdCelular,
                    FacturaId = facturaId,
                    Prec = item.Precio
                });

                var address = await AddressRepository.GetAddress(new GetSingleAddressDto(p.PedidoInfo.IdDirecc));
                var billingArgs = new BillingArgs()
                {
                    BillingId = facturaId,
                    ClientBillingId = p.NitN,
                    ClientBillingName = p.NombreCli,
                    ClientEmail = p.Email,
                    DeliveryAddress = $"{address.NombreDep}, {address.NombreMuni}, {address.Avenida}, {address.Calle}, Z. {address.Zona}",
                    TotalPurchase = p.PagoInfo.Tot,
                    BillingItemModels = new List<BillingItemModel>()
                    {
                        new BillingItemModel(item.Modelo, 1, item.Precio)
                    }
                };

                BillingService.SendBill(billingArgs);

                return Result.Ok();
            } catch(Exception ex)
            {
                return Result.Fail(new ErrorModel(ErrorCodes.GeneralError));
            }
        }
    }
}
