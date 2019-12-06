// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using Dawn;

    /// <summary>
    /// Represents fluent configuration for
    /// <see cref="ISequence{TExecutionContext}.ContinueWith{TSequenceUnitHandler, TResponse}"/>.
    /// </summary>
    /// <typeparam name="TExecutionContext">Type of the execution context object.</typeparam>
    /// <typeparam name="TResponse">Type of the sequance unit return value.</typeparam>
    internal class SequenceReturnAction<TExecutionContext, TResponse> :
        ISequenceReturnAction<TExecutionContext, TResponse>
        where TExecutionContext : class, IExecutionContext
    {
        private readonly Sequence<TExecutionContext> sequence;

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceReturnAction{TExecutionContext, TResponse}"/> class.
        /// </summary>
        /// <param name="sequence">Current sequence.</param>
        public SequenceReturnAction(Sequence<TExecutionContext> sequence)
        {
            this.sequence = Guard.Argument(sequence, nameof(sequence)).NotNull().Value;
        }

        /// <inheritdoc/>
        public ISequence<TExecutionContext> IgnoreSequenceReturn()
        {
            // TODO
            return this.sequence;
        }

        /// <inheritdoc/>
        public ISequence<TExecutionContext> SetExecutionContext<TMember>(System.Linq.Expressions.Expression<System.Func<TExecutionContext, TMember>> destinationMember)
        {
            // TODO
            return this.sequence;
        }

        /// <inheritdoc/>
        public ISequence<TExecutionContext> SetSequenceReturn()
        {
            throw new System.NotImplementedException();
        }
    }
}
