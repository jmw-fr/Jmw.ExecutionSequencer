// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Represent an execution sequence.
    /// </summary>
    /// <typeparam name="TExecutionContext">Type of the execution context.</typeparam>
    public interface ISequence<TExecutionContext>
        where TExecutionContext : class, IExecutionContext
    {
        /// <summary>
        /// Gets the list of SequenceUnitHandlers in the sequence.
        /// </summary>
        IEnumerable<SequenceUnitHandlerDefinition> SequenceUnitHandlers { get; }

        /// <summary>
        /// Gets the list of exception Handlers in the sequence.
        /// </summary>
        IEnumerable<Type> ExceptionHandlers { get; }

        /// <summary>
        /// Gets the list of default Exception Handlers in the sequence.
        /// </summary>
        IEnumerable<Type> DefaultExceptionHandlers { get; }

        /// <summary>
        /// Gets the list of finish Handlers in the sequence.
        /// </summary>
        IEnumerable<Type> FinishHandlers { get; }

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
        /// <param name="executionContextDestinationMember">Expression to the TExecutionContext member.</param>
        /// <typeparam name="TSequenceUnitHandler">Type of the sequence unit object.</typeparam>
        /// <typeparam name="TMember">Type of the TExecutionContext member.</typeparam>
        /// <returns>Returns the current sequence.</returns>
        ISequence<TExecutionContext> ContinueWith<TSequenceUnitHandler, TMember>(
            Expression<Func<TExecutionContext, TMember>> executionContextDestinationMember)
            where TSequenceUnitHandler : class, ISequenceUnitHandler<TExecutionContext, TMember>;

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
