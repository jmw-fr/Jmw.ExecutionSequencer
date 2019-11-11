// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface specification of an unit in the sequence.
    /// </summary>
    /// <typeparam name="TExecutionContext">Type of the execution context object.</typeparam>
    public interface ISequenceUnitHandler<TExecutionContext>
        where TExecutionContext : class, IExecutionContext
    {
        /// <summary>
        /// Handle a sequence unit.
        /// </summary>
        /// <param name="executionContext">Execution context.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task that represents the async operation.</returns>
        Task HandleAsync(TExecutionContext executionContext, CancellationToken cancellationToken);
    }
}
