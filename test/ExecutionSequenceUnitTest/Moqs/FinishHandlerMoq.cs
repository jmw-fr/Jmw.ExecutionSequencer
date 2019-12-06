// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer.UnitTests.Moqs
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Moq of <see cref="ISequenceFinishHandler{TExecutionContext}"/>.
    /// </summary>
    public class FinishHandlerMoq :
        ISequenceFinishHandler<ExecutionContextMoq>
    {
        /// <inheritdoc/>
        public Task HandleFinishAsync(ExecutionContextMoq executionContext, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
