// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Represents fluent configuration for <see cref="ISequencerConfiguration{TExecutionContext}"/>.
    /// </summary>
    /// <typeparam name="TExecutionContext">Type of the execution context object.</typeparam>
    public sealed class Sequence<TExecutionContext> :
        ISequence<TExecutionContext>
        where TExecutionContext : class, IExecutionContext
    {
        private readonly IList<SequenceUnitHandlerDefinition> sequenceUnitHandlers;
        private readonly IList<Type> exceptionHandlers;
        private readonly IList<Type> defaultExceptionHandlers;
        private readonly IList<Type> finishHandlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sequence{TExecutionContext}"/> class.
        /// </summary>
        internal Sequence()
        {
            sequenceUnitHandlers = new List<SequenceUnitHandlerDefinition>();
            exceptionHandlers = new List<Type>();
            defaultExceptionHandlers = new List<Type>();
            finishHandlers = new List<Type>();
        }

        /// <summary>
        /// Gets the list of SequenceUnitHandlers in the sequence.
        /// </summary>
        public IEnumerable<SequenceUnitHandlerDefinition> SequenceUnitHandler => sequenceUnitHandlers;

        /// <summary>
        /// Gets the list of exception Handlers in the sequence.
        /// </summary>
        public IEnumerable<Type> ExceptionHandlers => exceptionHandlers;

        /// <summary>
        /// Gets the list of default Exception Handlers in the sequence.
        /// </summary>
        public IEnumerable<Type> DefaultExceptionHandlers => defaultExceptionHandlers;

        /// <summary>
        /// Gets the list of finish Handlers in the sequence.
        /// </summary>
        public IEnumerable<Type> FinishHandlers => finishHandlers;

        /// <inheritdoc/>
        public ISequence<TExecutionContext> ContinueWith<TSequenceUnitHandler>()
            where TSequenceUnitHandler : class, ISequenceUnitHandler<TExecutionContext>
        {
            sequenceUnitHandlers.Add(new SequenceUnitHandlerDefinition(typeof(TSequenceUnitHandler)));

            return this;
        }

        /// <inheritdoc/>
        public ISequenceReturnAction<TExecutionContext, TResponse> ContinueWith<TSequenceUnitHandler, TResponse>()
            where TSequenceUnitHandler : class, ISequenceUnitHandler<TExecutionContext, TResponse>
        {
            return new SequenceReturnAction<TExecutionContext, TResponse>(this);
        }

        /// <inheritdoc/>
        public ISequence<TExecutionContext> HandleException<TException, TExceptionHandler>()
            where TException : Exception
            where TExceptionHandler : class, ISequenceExceptionHandler<TException, TExecutionContext>
        {
            exceptionHandlers.Add(typeof(TExceptionHandler));
            return this;
        }

        /// <inheritdoc/>
        public ISequence<TExecutionContext> FinishWith<TFinishHandler>()
            where TFinishHandler : class, ISequenceFinishHandler<TExecutionContext>
        {
            finishHandlers.Add(typeof(TFinishHandler));
            return this;
        }
    }
}
