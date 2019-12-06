// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer.UnitTests
{
    using System;
    using Xunit;

    /// <summary>
    /// Unit tests for <see cref="SequenceConfiguration{TExecutionContext}"/>.
    /// </summary>
    [Trait("Sequence", "SequenceConfiguration")]
    public class SequenceConfigurationUnitTests
    {
        /// <summary>
        /// Checks that <see cref="SequenceConfiguration{TExecutionContext}.BeginWith{TSequenceUnit}"/>
        /// initiates correctly a sequence.
        /// </summary>
        [Fact]
        public void BeginWithMustCreateSequence()
        {
            // Arrange
            var sut = new SequenceConfiguration<Moqs.ExecutionContextMoq>();

            // Act
            var computed = sut.BeginWith<Moqs.SequenceUnitHandlerMoq>();

            // Assert
            Assert.NotNull(computed);
            Assert.Equal(computed, sut.Sequence);
            Assert.Single(computed.SequenceUnitHandlers);
        }

        /// <summary>
        /// Checks that <see cref="SequenceConfiguration{TExecutionContext}.BeginWith{TSequenceUnit}"/>
        /// retuses to create a second sequence.
        /// </summary>
        [Fact]
        public void BeginWithMustRefuseSecondSequence()
        {
            // Arrange
            var sut = new SequenceConfiguration<Moqs.ExecutionContextMoq>();

            // Act
            var computed = sut.BeginWith<Moqs.SequenceUnitHandlerMoq>();

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.BeginWith<Moqs.SequenceUnitHandlerMoq>());
        }
    }
}
