// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface specification of an finally function in the sequence.
    /// </summary>
    /// <typeparam name="TExecutionContext">Type of the execution context object.</typeparam>
    public interface ISequenceFinishHandler<TExecutionContext>
        where TExecutionContext : class, IExecutionContext
    {
        /// <summary>
        /// Handle a finish sequence.
        /// </summary>
        /// <param name="executionContext">Execution context.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response from the handler.</returns>
        Task HandleFinishAsync(TExecutionContext executionContext, CancellationToken cancellationToken);
    }
}
