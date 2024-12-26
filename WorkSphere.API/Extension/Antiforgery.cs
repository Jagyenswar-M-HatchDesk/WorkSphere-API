using Microsoft.AspNetCore.Antiforgery;

public static class EndpointConventionBuilderExtensions
{
    public static T DisableAntiforgery<T>(this T builder) where T : IEndpointConventionBuilder
    {
        builder.Add(endpointBuilder =>
        {
            endpointBuilder.Metadata.Add(new IgnoreAntiforgeryMetadata());
        });
        return builder;
    }
}

public class IgnoreAntiforgeryMetadata : IAntiforgeryMetadata
{
    public bool RequiresValidation => false;
}
