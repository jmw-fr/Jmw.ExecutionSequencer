// Copyright Jean-Marc Weeger under MIT Licence. See https://opensource.org/licenses/mit-license.php.

namespace Jmw.ExecutionSequencer.UnitTests
{
    using System;
    using Xunit;

    /// <summary>
    /// <see cref="Sequence{TExecutionContext}" /> unit tests.
    /// </summary>
    [Trait("Sequence", "Sequence")]
    public class SequenceUnitTests
    {
        /// <summary>
        /// Checks that <see cref="Sequence{TExecutionContext}" /> creates empty lists.
        /// </summary>
        [Fact]
        public void SequenceMustCreateLists()
        {
            // Arrange
            var sut = new Sequence<Moqs.ExecutionContextMoq>();

            // Act

            // Assert
            Assert.NotNull(sut.SequenceUnitHandler);
            Assert.NotNull(sut.ExceptionHandlers);
            Assert.NotNull(sut.DefaultExceptionHandlers);
            Assert.NotNull(sut.FinishHandlers);
            Assert.Empty(sut.SequenceUnitHandler);
            Assert.Empty(sut.ExceptionHandlers);
            Assert.Empty(sut.DefaultExceptionHandlers);
            Assert.Empty(sut.FinishHandlers);
        }

        /// <summary>
        /// Checks that <see cref="Sequence{TExecutionContext}" />
        /// adds the sequence unit handler.
        /// </summary>
        [Fact]
        public void SequenceMustAddSequenceUnitHandler()
        {
            // Arrange
            var type = typeof(Moqs.SequenceUnitHandlerMoq);
            var sut = new Sequence<Moqs.ExecutionContextMoq>();
            var seq = sut as ISequence<Moqs.ExecutionContextMoq>;

            // Act
            var computed = seq.ContinueWith<Moqs.SequenceUnitHandlerMoq>();

            // Assert
            Assert.NotNull(computed);
            Assert.Equal(sut, computed);
            Assert.Single(sut.SequenceUnitHandler);
            Assert.Collection(sut.SequenceUnitHandler, t =>
            {
                Assert.Equal(type, t.SequenceUnitHandlerType);
                Assert.Null(t.ExecutionContextPropertyInfo);
            });
        }

        /// <summary>
        /// Checks that <see cref="Sequence{TExecutionContext}" />
        /// adds the sequence unit handler.
        /// </summary>
        [Fact]
        public void SequenceMustAddSequenceUnitHandlerWithProperty()
        {
            // Arrange
            var type = typeof(Moqs.SequenceUnitHandlerWithPropertyMoq);
            var propertyInfo = typeof(Moqs.ExecutionContextMoq).GetProperty(nameof(Moqs.ExecutionContextMoq.ExecutionContextProperty));
            var sut = new Sequence<Moqs.ExecutionContextMoq>();
            var seq = sut as ISequence<Moqs.ExecutionContextMoq>;

            // Act
            var computed = seq.ContinueWith<Moqs.SequenceUnitHandlerWithPropertyMoq, string>(c => c.ExecutionContextProperty);

            // Assert
            Assert.NotNull(computed);
            Assert.Equal(sut, computed);
            Assert.Single(sut.SequenceUnitHandler);
            Assert.Collection(sut.SequenceUnitHandler, t =>
            {
                Assert.Equal(type, t.SequenceUnitHandlerType);
                Assert.Equal(propertyInfo, t.ExecutionContextPropertyInfo);
            });
        }

        /// <summary>
        /// Checks that <see cref="Sequence{TExecutionContext}" />
        /// refuses an expression that does not return a property of TExecutionContext.
        /// </summary>
        [Fact]
        public void SequenceMustCheckSequenceUnitHandlerWithProperty()
        {
            // Arrange
            var type = typeof(Moqs.SequenceUnitHandlerWithPropertyMoq);
            var propertyInfo = typeof(Moqs.ExecutionContextMoq).GetProperty(nameof(Moqs.ExecutionContextMoq.ExecutionContextProperty));
            var sut = new Sequence<Moqs.ExecutionContextMoq>();
            var seq = sut as ISequence<Moqs.ExecutionContextMoq>;

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => seq.ContinueWith<Moqs.SequenceUnitHandlerWithPropertyMoq, string>(c => "ddd"));
        }

        /// <summary>
        /// Checks that <see cref="Sequence{TExecutionContext}" />
        /// adds an exception handler.
        /// </summary>
        [Fact]
        public void SequenceMustAddExceptionHandler()
        {
            // Arrange
            var type = typeof(Moqs.ExceptionHandlerMoq<ArgumentNullException>);
            var sut = new Sequence<Moqs.ExecutionContextMoq>();
            var seq = sut as ISequence<Moqs.ExecutionContextMoq>;

            // Act
            var computed = seq.HandleException<ArgumentNullException, Moqs.ExceptionHandlerMoq<ArgumentNullException>>();

            // Assert
            Assert.NotNull(computed);
            Assert.Equal(sut, computed);
            Assert.Single(sut.ExceptionHandlers);
            Assert.Collection(sut.ExceptionHandlers, t => Assert.Equal(type, t));
        }

        /// <summary>
        /// Checks that <see cref="Sequence{TExecutionContext}" />
        /// adds a finish handler.
        /// </summary>
        [Fact]
        public void SequenceMustAddFinishHandler()
        {
            // Arrange
            var type = typeof(Moqs.FinishHandlerMoq);
            var sut = new Sequence<Moqs.ExecutionContextMoq>();
            var seq = sut as ISequence<Moqs.ExecutionContextMoq>;

            // Act
            var computed = seq.FinishWith<Moqs.FinishHandlerMoq>();

            // Assert
            Assert.NotNull(computed);
            Assert.Equal(sut, computed);
            Assert.Single(sut.FinishHandlers);
            Assert.Collection(sut.FinishHandlers, t => Assert.Equal(type, t));
        }
    }
}
