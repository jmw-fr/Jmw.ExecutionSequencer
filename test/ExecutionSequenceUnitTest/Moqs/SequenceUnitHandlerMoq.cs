// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer.UnitTests.Moqs
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Moq for <see cref="ISequenceUnitHandler{TExecutionContext}"/>.
    /// </summary>
    public class SequenceUnitHandlerMoq :
        ISequenceUnitHandler<ExecutionContextMoq>
    {
        /// <inheritdoc/>
        public Task HandleAsync(ExecutionContextMoq executionContext, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
