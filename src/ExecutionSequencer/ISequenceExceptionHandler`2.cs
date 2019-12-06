// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface defining an exception handler.
    /// </summary>
    /// <typeparam name="TException">Type if the exception handled.</typeparam>
    /// <typeparam name="TExecutionContext">Type of the execution context object.</typeparam>
    public interface ISequenceExceptionHandler<TException, TExecutionContext>
        where TException : Exception
        where TExecutionContext : class, IExecutionContext
    {
        /// <summary>
        /// Handler of the exception called by the SequenceExecution engine.
        /// </summary>
        /// <param name="exception">Exception thrown.</param>
        /// <param name="executionContext">Current execution context.</param>
        /// <returns>Async task.</returns>
        Task HandleExceptionAsync(TException exception, TExecutionContext executionContext);
    }
}
