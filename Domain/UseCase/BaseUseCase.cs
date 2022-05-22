using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UseCase
{
    public abstract class BaseUseCase<T, R>
    {
        public abstract Task<R> Execute(T p);
    }
}
