using System;
using FluentAssertions;
using MethodBoundaryAspect.Fody.UnitTests.TestAssembly.NetFramework;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests.NetFramework
{
    public class ProtectedInternalMethodAttributeAspectTests : MethodBoundaryAspectNetFrameworkTestBase
    {
        private static readonly Type TestClassType = typeof(ProtectedInternalMethodAttributeAspectMethods);

        [Fact]
        public void IfMethodIsCalled_ThenTheOnMethodBoundaryAspectShouldBeCalled()
        {
            // Arrange
            const string testMethodName = "PublicMethod";
            WeaveAssemblyClassAndLoad(TestClassType);

            // Act
            var result = AssemblyLoader.InvokeMethod(TestClassType.TypeInfo(), testMethodName);

            // Assert
            result.Should().Be("ProtectedInternalMethod");
        }
    }
}