namespace Starry.NET.Objects
{
    public class IAsset
    {
        public virtual void Load(string Path) { }
        public virtual void Dispose() { }

        public required Entity Entity { get; set; }
    }
}
