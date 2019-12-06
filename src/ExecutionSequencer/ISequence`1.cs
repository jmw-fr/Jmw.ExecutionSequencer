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
        ISequence<TExecutionContext> ContinueWith<TSequenceUnitHandler>()
            where TSequenceUnitHandler : class, ISequenceUnitHandler<TExecutionContext>;

        /// <summary>
        /// Sets the next <see cref="ISequenceUnitHandler{TExecutionContext}"/> in the sequence.
        /// </summary>
        /// <typeparam name="TSequenceUnitHandler">Type of the sequence unit object.</typeparam>
        /// <typeparam name="TResponse">Type of the sequence unit result.</typeparam>
        /// <returns>Returns the sequence action to configure.</returns>
        ISequenceReturnAction<TExecutionContext, TResponse> ContinueWith<TSequenceUnitHandler, TResponse>()
            where TSequenceUnitHandler : class, ISequenceUnitHandler<TExecutionContext, TResponse>;

        /// <summary>
        /// Sets an exception handler for a specific exception.
        /// It is an equivalent of catch instruction.
        /// </summary>
        /// <typeparam name="TException">Type of exception to handle.</typeparam>
        /// <typeparam name="TExceptionHandler">Type of the handler object.</typeparam>
        /// <returns>Returns the current sequence.</returns>
        ISequence<TExecutionContext> HandleException<TException, TExceptionHandler>()
            where TException : Exception
            where TExceptionHandler : class, ISequenceExceptionHandler<TException, TExecutionContext>;

        /// <summary>
        /// Finish handler for the execution sequence.
        /// These handlers are executed after normal unit sequences and exceptions handlers.
        /// It is an equivalent of finally instruction.
        /// </summary>
        /// <typeparam name="TFinishHandler">Type of the finish handler.</typeparam>
        /// <returns>Returns the current sequence.</returns>
        ISequence<TExecutionContext> FinishWith<TFinishHandler>()
            where TFinishHandler : class, ISequenceFinishHandler<TExecutionContext>;
    }
}
