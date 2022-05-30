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
        private readonly ICarritoRepository CarritoRepository;
        private readonly IPaymentRepository PaymentRepository;
        private readonly IAddressRepository AddressRepository;

        public CreateFacturaUseCase(ICellphoneRepository cellPhoneRepository, IPedidoRepository pedidoRepository, IFacturaRepository facturaRepository, IBillingService billingService, ICarritoRepository carritoRepository, IPaymentRepository paymentRepository, IAddressRepository addressRepository)
        {
            CellPhoneRepository = cellPhoneRepository;
            PedidoRepository = pedidoRepository;
            FacturaRepository = facturaRepository;
            BillingService = billingService;
            CarritoRepository = carritoRepository;
            PaymentRepository = paymentRepository;
            AddressRepository = addressRepository;
        }

        public override async Task<Result> Execute(FacturaDTO p)
        {
            try
            {
                var carrito = await CarritoRepository.GetCarrito(new GetCarritoDto(p.UsuarioId));

                var pedidoId = await PedidoRepository.CreatePedido(p.PedidoInfo);

                var pagoId = await PaymentRepository.CreatePayment(p.PagoInfo);

                var createFacturaDto = new CreateFacturaDTO(usuarioId: p.UsuarioId, pagoId: pagoId, pedidoId: pedidoId, nitN: p.NitN, nombreCli: p.NombreCli);

                var facturaId = await FacturaRepository.CreateFactura(createFacturaDto);

                foreach (var item in carrito)
                {
                    await CellPhoneRepository.UpdateStockCellphone(new UpdateStockDto(item.Cantidad, item.IdCelular));
                    await FacturaRepository.CreateFilasFactura(new CreateFacturaFilaDto()
                    {
                        Cant = item.Cantidad,
                        CelularId = item.IdCelular,
                        FacturaId = facturaId,
                        Prec = item.Precio
                    });
                }

                await CarritoRepository.DeleteCarrito(new DeleteCarritoUsuarioDto(p.UsuarioId));
                var address = await AddressRepository.GetAddress(new GetSingleAddressDto(p.PedidoInfo.IdDirecc));
                var billingArgs = new BillingArgs()
                {
                    BillingId = facturaId,
                    ClientBillingId = p.NitN,
                    ClientBillingName = p.NombreCli,
                    ClientEmail = p.Email,
                    DeliveryAddress = $"{address.NombreDep}, {address.NombreMuni}, {address.Avenida}, {address.Calle}, Z. {address.Zona}",
                    TotalPurchase = p.PagoInfo.Total,
                    BillingItemModels = carrito.Select(p => new BillingItemModel(p.Modelo, p.Cantidad, p.Precio)).ToList()
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
