// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the sequencer interface.
    /// </summary>
    public interface ISequencer
    {
        /// <summary>
        /// Execute a sequence.
        /// </summary>
        /// <typeparam name="TExecutionContext">Type of the execution context object.</typeparam>
        /// <param name="sequence">Sequence to execute.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>A task that represents the sequence operation.</returns>
        Task ExecuteSequenceAsync<TExecutionContext>(ISequence<TExecutionContext> sequence, CancellationToken cancellationToken = default)
            where TExecutionContext : class, IExecutionContext;
    }
}
