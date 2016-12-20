using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.DTO.Client
{
    public class GeoCoordinate
    {
        private double latitude;
        private double longitude;
        private const double tolerance = 10.0 * .1;

        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                this.latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                this.longitude = value;
            }
        }

        public GeoCoordinate()
        {
        }

        public GeoCoordinate(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public GeoCoordinate(string latitude, string longitude)
        {
            try
            {
                this.latitude = double.Parse(latitude);
                this.longitude = double.Parse(longitude);
            }
            catch
            {
                this.latitude = 0;
                this.longitude = 0;
            }
        }

        public GeoCoordinate(double? latitude, double? longitude)
        {
            this.latitude = latitude.HasValue ? latitude.Value : 0;
            this.longitude = longitude.HasValue ? longitude.Value : 0;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", this.latitude, this.longitude);
        }

        public override bool Equals(object obj)
        {
            return obj is GeoCoordinate && Equals((GeoCoordinate)obj);
        }

        public bool Equals(GeoCoordinate other)
        {
            return this.latitude.Equals(other.Latitude) && this.longitude.Equals(other.Longitude);
        }

        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode();
        }

        public static bool operator ==(GeoCoordinate a, GeoCoordinate b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            var latResult = Math.Abs(a.Latitude - b.Latitude);
            var lonResult = Math.Abs(a.Longitude - b.Longitude);
            return (latResult < tolerance) && (lonResult < tolerance);
        }

        public static bool operator !=(GeoCoordinate a, GeoCoordinate b)
        {
            return !(a == b);
        }
    }
}
