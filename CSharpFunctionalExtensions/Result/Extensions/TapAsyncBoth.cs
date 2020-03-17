using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result> Tap(this Task<Result> resultTask, Func<Task> func)
        {
            Result result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Func<Task> func)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Func<T, Task> func)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func(result.Value).DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            var funcResult = await result.Bind(func).DefaultAwait();
            return funcResult.Map(() => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Func<Task> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func(result.Value).DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T>> Tap<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return await result.Bind(func).Map(_ => result.Value).DefaultAwait();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T, E>> Tap<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<Result<K, E>>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return await result.Bind(func).Map(_ => result.Value).DefaultAwait();
        }
    }
}
