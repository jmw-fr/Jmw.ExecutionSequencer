// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer
{
    /// <summary>
    /// Interface specification of an finally function in the sequence.
    /// </summary>
    /// <typeparam name="TExecutionContext">Type of the execution context object.</typeparam>
    public interface ISequenceFinallyHandler<TExecutionContext>
        where TExecutionContext : class, IExecutionContext
    {
    }
}
