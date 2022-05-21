using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ICellphoneRepository
    {
        public Task CreateCellphone(CreateCellphoneDto cellphoneDto);

        public Task GetCellPhone(GetCellPhoneDto getCellPhoneDto);
    }
}
