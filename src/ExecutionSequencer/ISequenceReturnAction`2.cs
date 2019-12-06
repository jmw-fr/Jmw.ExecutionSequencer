// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Represents the action to execute with the result of a sequence.
    /// </summary>
    /// <typeparam name="TExecutionContext">Type of the execution context.</typeparam>
    /// <typeparam name="TResponse">Type of the sequance unit return value.</typeparam>
    public interface ISequenceReturnAction<TExecutionContext, TResponse>
        where TExecutionContext : class, IExecutionContext
    {
        /// <summary>
        /// Sets a property of the actual context using the reponse from the Sequence Unit Handler.
        /// </summary>
        /// <param name="destinationMember">Member of the Execution Context to set.</param>
        /// <typeparam name="TMember">Type of the <typeparamref name="TExecutionContext"/> member to set.</typeparam>
        /// <returns>Returns the current sequence.</returns>
        ISequence<TExecutionContext> SetExecutionContext<TMember>(Expression<Func<TExecutionContext, TMember>> destinationMember);

        /// <summary>
        /// Sets the Sequence Unit Handler return value as result from the sequence.
        /// </summary>
        /// <returns>Returns the current sequence.</returns>
        ISequence<TExecutionContext> SetSequenceReturn();

        /// <summary>
        /// Ignores the return value of the Sequence Unit Handler.
        /// </summary>
        /// <returns>Returns the current sequence.</returns>
        ISequence<TExecutionContext> IgnoreSequenceReturn();
    }
}
