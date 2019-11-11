// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System;

    /// <summary>
    /// Represent an execution sequence.
    /// </summary>
    /// <typeparam name="TExecutionContext">Type of the execution context.</typeparam>
    public interface ISequence<TExecutionContext>
        where TExecutionContext : class, IExecutionContext
    {
        /// <summary>
        /// Sets the next <see cref="ISequenceUnitHandler{TExecutionContext}"/> in the sequence.
        /// </summary>
        /// <typeparam name="TSequenceUnitHandler">Type of the sequence unit object.</typeparam>
        /// <returns>Returns the current sequence.</returns>
        ISequence<TExecutionContext> Then<TSequenceUnitHandler>()
            where TSequenceUnitHandler : class, ISequenceUnitHandler<TExecutionContext>;

        /// <summary>
        /// Sets the next <see cref="ISequenceUnitHandler{TExecutionContext}"/> in the sequence.
        /// </summary>
        /// <typeparam name="TSequenceUnitHandler">Type of the sequence unit object.</typeparam>
        /// <typeparam name="TResponse">Type of the sequence unit result.</typeparam>
        /// <returns>Returns the sequence action to configure.</returns>
        ISequenceReturnAction<TExecutionContext, TResponse> Then<TSequenceUnitHandler, TResponse>()
            where TSequenceUnitHandler : class, ISequenceUnitHandler<TExecutionContext, TResponse>;

        /// <summary>
        /// Sets an exception handler for a specific exception.
        /// </summary>
        /// <typeparam name="TException">Type of exception to handle.</typeparam>
        /// <typeparam name="TExceptionHandler">Type of the handler object.</typeparam>
        /// <returns>Returns the current sequence.</returns>
        ISequence<TExecutionContext> Catch<TException, TExceptionHandler>()
            where TException : Exception
            where TExceptionHandler : class, ISequenceExceptionHandler<TException, TExecutionContext>;

        /// <summary>
        /// Finally handler for the execution sequence.
        /// </summary>
        /// <typeparam name="TFinallyHandler">Type of the finally handler.</typeparam>
        void Finally<TFinallyHandler>()
            where TFinallyHandler : class, ISequenceFinallyHandler<TExecutionContext>;
    }
}
