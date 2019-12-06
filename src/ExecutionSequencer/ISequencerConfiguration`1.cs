// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System;

    /// <summary>
    /// Interface specification for configuring an ExecutionSequencer Engine.
    /// </summary>
    /// <typeparam name="TExecutionContext">Type of the execution context object.</typeparam>
    public interface ISequencerConfiguration<TExecutionContext>
        where TExecutionContext : class, IExecutionContext
    {
        /// <summary>
        /// Define the beginning sequence unit for the sequence.
        /// </summary>
        /// <typeparam name="TSequenceUnit">Type of the sequence unit.</typeparam>
        /// <returns>Returns the sequence object.</returns>
        /// <exception cref="InvalidOperationException">The BeginWith function has already been called.</exception>
        ISequence<TExecutionContext> BeginWith<TSequenceUnit>()
            where TSequenceUnit : class, ISequenceUnitHandler<TExecutionContext>;
    }
}
