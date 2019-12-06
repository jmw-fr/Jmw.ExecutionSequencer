// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System;
    using System.Reflection;
    using Dawn;

    /// <summary>
    /// Represents a sequence unit handler definition.
    /// It is used by <see cref="ISequencer"/> in the process of a sequence.
    /// </summary>
    public class SequenceUnitHandlerDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceUnitHandlerDefinition"/> class
        /// for an action sequence unit handler.
        /// </summary>
        /// <param name="sequenceUnitHandlerType">Type of the sequence unit handler.</param>
        internal SequenceUnitHandlerDefinition(Type sequenceUnitHandlerType)
        {
            SequenceUnitHandlerType = Guard
                .Argument(sequenceUnitHandlerType, nameof(sequenceUnitHandlerType))
                .NotNull();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceUnitHandlerDefinition"/> class
        /// for an action sequence unit handler.
        /// </summary>
        /// <param name="sequenceUnitHandlerType">Type of the sequence unit handler.</param>
        /// <param name="executionContextPropertyInfo">Property info of the <see cref="IExecutionContext" /> to set with the return value.</param>
        internal SequenceUnitHandlerDefinition(Type sequenceUnitHandlerType, PropertyInfo executionContextPropertyInfo)
        {
            SequenceUnitHandlerType = Guard
                .Argument(sequenceUnitHandlerType, nameof(sequenceUnitHandlerType)).NotNull()
                .Value;

            ExecutionContextPropertyInfo = Guard
                .Argument(executionContextPropertyInfo, nameof(executionContextPropertyInfo)).NotNull()
                .Value;
        }

        /// <summary>
        /// Gets the sequence unit handler's type.
        /// </summary>
        public Type SequenceUnitHandlerType { get; }

        /// <summary>
        /// Gets the PropertyInfo of the <see cref="IExecutionContext" /> to set with the return value.
        /// </summary>
        public PropertyInfo ExecutionContextPropertyInfo { get; }
    }
}
