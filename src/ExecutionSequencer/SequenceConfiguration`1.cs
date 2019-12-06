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
        /// <summary>
        /// Gets the configured sequence.
        /// </summary>
        public Sequence<TExecutionContext> Sequence { get; private set; }

        /// <inheritdoc/>
        public ISequence<TExecutionContext> BeginWith<TSequenceUnit>()
            where TSequenceUnit : class, ISequenceUnitHandler<TExecutionContext>
        {
            if (Sequence != null)
            {
                throw new InvalidOperationException(Properties.Resources.BeginWithAlreadyCalled);
            }

            Sequence = new Sequence<TExecutionContext>();

            return Sequence.ContinueWith<TSequenceUnit>();
        }
    }
}
