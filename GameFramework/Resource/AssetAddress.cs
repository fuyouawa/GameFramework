using System;

namespace GameFramework.Resource
{
    public readonly struct AssetAddress : IEquatable<AssetAddress>
    {
        public static readonly AssetAddress Empty = new AssetAddress("", "");

        public readonly string PackageName;
        public readonly string Location;

        public AssetAddress(string packageName, string location)
        {
            PackageName = packageName;
            Location = location;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(PackageName) && !string.IsNullOrEmpty(Location);
        }

        public override string ToString()
        {
            return $"{PackageName}/{Location}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PackageName, Location);
        }

        public override bool Equals(object obj)
        {
            return obj is AssetAddress other && Equals(other);
        }

        public bool Equals(AssetAddress other)
        {
            return PackageName == other.PackageName && Location == other.Location;
        }

        public static bool operator ==(AssetAddress left, AssetAddress right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AssetAddress left, AssetAddress right)
        {
            return !left.Equals(right);
        }
    }
}
