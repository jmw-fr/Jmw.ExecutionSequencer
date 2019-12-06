// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer.UnitTests.Moqs
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Moq for <see cref="ISequenceExceptionHandler{TException, TExecutionContext}"/>.
    /// </summary>
    /// <typeparam name="TException">Type of exception to handle.</typeparam>
    public class ExceptionHandlerMoq<TException>
        : ISequenceExceptionHandler<TException, ExecutionContextMoq>
        where TException : Exception
    {
        /// <inheritdoc/>
        public Task HandleExceptionAsync(TException exception, ExecutionContextMoq executionContext)
        {
            return Task.CompletedTask;
        }
    }
}
