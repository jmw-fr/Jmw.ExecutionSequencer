// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Represents a sequence of execution.
    /// </summary>
    /// <typeparam name="TExecutionContext">Type of the execution context object.</typeparam>
    public sealed class Sequence<TExecutionContext> :
        ISequence<IExecutionContext>
        where TExecutionContext : class, IExecutionContext
    {
        private readonly IList<Type> sequenceActionUnitHandlersNoReturn;
        private readonly IList<Tuple<Type, PropertyInfo>> sequenceFunctionsUnitHandlers;
        private readonly IList<Type> exceptionHandlers;
        private readonly IList<Type> finallyHandlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sequence{TExecutionContext}"/> class.
        /// </summary>
        internal Sequence()
        {
            exceptionHandlers = new List<Type>();
            sequenceActionUnitHandlersNoReturn = new List<Type>();
            sequenceFunctionsUnitHandlers = new List<Tuple<Type, PropertyInfo>>();
            finallyHandlers = new List<Type>();
        }

        /// <inheritdoc/>
        ISequence<IExecutionContext> ISequence<IExecutionContext>.HandleException<TException, TExceptionHandler>()
        {
            exceptionHandlers.Add(typeof(TExceptionHandler));
            return this;
        }

        /// <inheritdoc/>
        ISequence<IExecutionContext> ISequence<IExecutionContext>.FinishWith<TFinallyHandler>()
        {
            finallyHandlers.Add(typeof(TFinallyHandler));
            return this;
        }

        /// <inheritdoc/>
        ISequence<IExecutionContext> ISequence<IExecutionContext>.ContinueWith<TSequenceUnitHandler>()
        {
            sequenceActionUnitHandlersNoReturn.Add(typeof(TSequenceUnitHandler));
            return this;
        }

        /// <inheritdoc/>
        ISequenceReturnAction<IExecutionContext, TResponse> ISequence<IExecutionContext>.ContinueWith<TSequenceUnitHandler, TResponse>()
        {
            // TODO. Add Handler handler.
            throw new NotImplementedException();
        }
    }
}
