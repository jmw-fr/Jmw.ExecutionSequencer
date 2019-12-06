// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer.UnitTests.Moqs
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Moq for <see cref="ISequenceUnitHandler{TExecutionContext, TResponse}"/>.
    /// </summary>
    public class SequenceUnitHandlerWithPropertyMoq :
        ISequenceUnitHandler<ExecutionContextMoq, string>
    {
        /// <inheritdoc/>
        public Task<string> HandleAsync(ExecutionContextMoq executionContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(Guid.NewGuid().ToString());
        }
    }
}
