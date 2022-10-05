namespace PhilipsHueAPI.Effects.Interfaces
{
    public interface LightEffect
    {
        public void Perform(List<string> lightIds, object value);
    }
}
