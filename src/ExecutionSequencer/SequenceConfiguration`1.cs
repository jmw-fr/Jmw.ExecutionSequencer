// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System;

    /// <summary>
    /// Configuration of an execution sequence.
    /// </summary>
    /// <typeparam name="TExecutionContext">Type of the execution context object.</typeparam>
    public class SequenceConfiguration<TExecutionContext>
        : ISequencerConfiguration<TExecutionContext>
        where TExecutionContext : class, IExecutionContext
    {
        private Sequence<TExecutionContext> sequence = null;

        /// <inheritdoc/>
        public ISequence<TExecutionContext> BeginWith<TSequenceUnit>()
            where TSequenceUnit : class, ISequenceUnitHandler<TExecutionContext>
        {
            if (sequence != null)
            {
                throw new InvalidOperationException(Properties.Resources.BeginWithAlreadyCalled);
            }

            sequence = new Sequence<TExecutionContext>();

            return sequence;
        }
    }
}
