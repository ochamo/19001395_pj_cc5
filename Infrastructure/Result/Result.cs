using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Result
{
    public class Result
    {
        public bool Success { get; }

        public ErrorModel Error { get; private set; }

        public bool IsFailure => !Success;

        protected Result(bool success, ErrorModel error)
        {
            if (success && error != null)
                throw new InvalidOperationException();
            if (!success && error == null)
                throw new InvalidOperationException();
            this.Success = success;
            this.Error = error;
        }

        public static Result Fail(ErrorModel message)
        {
            return new Result(false, message);
        }

        public static Result<T> Fail<T>(ErrorModel errorModel)
        {
            return new Result<T>(default(T), false, errorModel);
        }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, null);
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; set; }

        protected internal Result(T value, bool success, ErrorModel error)
            : base(success, error)
        {
            Value = value;
        }

    }
}
