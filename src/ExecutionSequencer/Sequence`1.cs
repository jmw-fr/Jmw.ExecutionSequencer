// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq.Expressions;
    using Dawn;
    using Jmw.ExecutionSequencer.Properties;

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

        /// <inheritdoc/>
        public IEnumerable<SequenceUnitHandlerDefinition> SequenceUnitHandlers => sequenceUnitHandlers;

        /// <inheritdoc/>
        public IEnumerable<Type> ExceptionHandlers => exceptionHandlers;

        /// <inheritdoc/>
        public IEnumerable<Type> DefaultExceptionHandlers => defaultExceptionHandlers;

        /// <inheritdoc/>
        public IEnumerable<Type> FinishHandlers => finishHandlers;

        /// <inheritdoc/>
        public ISequence<TExecutionContext> ContinueWith<TSequenceUnitHandler>()
            where TSequenceUnitHandler : class, ISequenceUnitHandler<TExecutionContext>
        {
            sequenceUnitHandlers.Add(new SequenceUnitHandlerDefinition(typeof(TSequenceUnitHandler)));

            return this;
        }

        /// <inheritdoc/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Using Dawn.Guard")]
        public ISequence<TExecutionContext> ContinueWith<TSequenceUnitHandler, TMember>(
            Expression<Func<TExecutionContext, TMember>> executionContextDestinationMember)
            where TSequenceUnitHandler : class, ISequenceUnitHandler<TExecutionContext, TMember>
        {
            Guard.Argument(executionContextDestinationMember, nameof(executionContextDestinationMember))
                .NotNull();

            LambdaExpression lambda = executionContextDestinationMember;

            if (lambda.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.ExecutionContextDestinationMember_NotAProperty,
                        typeof(TExecutionContext)));
            }

            MemberExpression member = (MemberExpression)lambda.Body;

            sequenceUnitHandlers.Add(
                new SequenceUnitHandlerDefinition(
                    typeof(TSequenceUnitHandler),
                    typeof(TExecutionContext).GetProperty(member.Member.Name)));

            return this;
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
