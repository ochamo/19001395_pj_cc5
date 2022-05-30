
namespace Infrastructure.Dto.Cellphone
{
    public class UpdateStockDto
    {
        public int Cant { get; set; }
        public int IdCel { get; set; }

        public UpdateStockDto(int cant, int idCel)
        {
            Cant = cant;
            IdCel = idCel;
        }

        public UpdateStockDto()
        {

        }

    }
}
