using System.Collections.Generic;
using Lidarr.Http.ClientSchema;
using Lidarr.Http.REST;
using NzbDrone.Core.AutoTagging.Specifications;

namespace Lidarr.Api.V3.AutoTagging
{
    public class AutoTaggingSpecificationSchema : RestResource
    {
        public string Name { get; set; }
        public string Implementation { get; set; }
        public string ImplementationName { get; set; }
        public bool Negate { get; set; }
        public bool Required { get; set; }
        public List<Field> Fields { get; set; }
    }

    public static class AutoTaggingSpecificationSchemaMapper
    {
        public static AutoTaggingSpecificationSchema ToSchema(this IAutoTaggingSpecification model)
        {
            return new AutoTaggingSpecificationSchema
            {
                Name = model.Name,
                Implementation = model.GetType().Name,
                ImplementationName = model.ImplementationName,
                Negate = model.Negate,
                Required = model.Required,
                Fields = SchemaBuilder.ToSchema(model)
            };
        }
    }
}
