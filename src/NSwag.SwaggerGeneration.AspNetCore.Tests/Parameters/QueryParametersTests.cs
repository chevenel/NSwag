﻿using System.Linq;
using System.Threading.Tasks;
using NSwag.SwaggerGeneration.AspNetCore.Tests.Web.Controllers.Parameters;
using Xunit;

namespace NSwag.SwaggerGeneration.AspNetCore.Tests.Parameters
{
    public class QueryParametersTests : AspNetCoreTestsBase
    {
        [Fact]
        public async Task When_complex_query_parameters_are_nullable_and_set_to_null_they_are_optional_in_spec()
        {
            // Arrange
            var settings = new AspNetCoreToSwaggerGeneratorSettings();

            // Act
            var document = await GenerateDocumentAsync(settings, typeof(ComplexQueryParametersController));

            // Assert
            var operation = document.Operations.First().Operation;

            Assert.True(operation.ActualParameters.First().IsRequired);
            Assert.True(operation.ActualParameters.Last().IsRequired);
        }

        [Fact]
        public async Task When_simple_query_parameters_are_nullable_and_set_to_null_they_are_optional_in_spec()
        {
            // Arrange
            var settings = new AspNetCoreToSwaggerGeneratorSettings();

            // Act
            var document = await GenerateDocumentAsync(settings, typeof(SimpleQueryParametersController));

            // Assert
            var operation = document.Operations.First().Operation;

            Assert.True(operation.ActualParameters.First().IsRequired);
            Assert.False(operation.ActualParameters.Last().IsRequired);
        }
    }
}