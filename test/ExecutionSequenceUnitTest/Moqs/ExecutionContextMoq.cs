// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer.UnitTests.Moqs
{
    /// <summary>
    /// Moq of <see cref="IExecutionContext"/> for unit testing.
    /// </summary>
    public class ExecutionContextMoq : IExecutionContext
    {
        /// <summary>
        /// Gets or sets some Execution Context property.
        /// </summary>
        public string ExecutionContextProperty { get; set; }
    }
}
