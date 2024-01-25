
namespace Nanoleaf.EffectConfig.Products.Interfaces
{
    public interface IEffectPropertyConfig
    {
        string JsonProperty { get; }
        object Value { get; set; }
    }
}
