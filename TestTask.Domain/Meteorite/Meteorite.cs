// <copyright file="Meteorite.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Domain.Meteorite
{
    /// <summary>
    /// Meteorite.
    /// </summary>
    public class Meteorite : RootEntity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Meteorite"/> class.
        /// </summary>
        private Meteorite()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Meteorite"/> class.
        /// </summary>
        /// <param name="externalId">External id.</param>
        /// <param name="name">Name.</param>
        /// <param name="nameType">Name type.</param>
        /// <param name="recClass">Class.</param>
        /// <param name="mass">Mass.</param>
        /// <param name="fall">Fall.</param>
        /// <param name="year">Year.</param>
        /// <param name="latitude">Latitude.</param>
        /// <param name="longitude">Longitude.</param>
        private Meteorite(
            int externalId,
            string name,
            NameType nameType,
            string recClass,
            double mass,
            bool fall,
            int year,
            double latitude,
            double longitude)
        {
            this.ExternalId = externalId;
            this.Name = name;
            this.NameType = nameType;
            this.RecClass = recClass;
            this.Mass = mass;
            this.Fall = fall;
            this.Year = year;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Gets external id.
        /// </summary>
        public int ExternalId { get; }

        /// <summary>
        /// Gets name.
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// Gets name type.
        /// </summary>
        public NameType NameType { get; private set; }

        /// <summary>
        /// Gets recClass.
        /// </summary>
        public string RecClass { get; private set; } = string.Empty;

        /// <summary>
        /// Gets mass.
        /// </summary>
        public double Mass { get; private set; }

        /// <summary>
        /// Gets a value indicating whether fall.
        /// </summary>
        public bool Fall { get; private set; }

        /// <summary>
        /// Gets year.
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// Gets latitude.
        /// </summary>
        public double Latitude { get; private set; }

        /// <summary>
        /// Gets longitude.
        /// </summary>
        public double Longitude { get; private set; }

        /// <summary>
        /// Create meteorite.
        /// </summary>
        /// <param name="externalId">External id.</param>
        /// <param name="name">Name.</param>
        /// <param name="nameType">Name type.</param>
        /// <param name="recClass">Class.</param>
        /// <param name="mass">Mass.</param>
        /// <param name="fall">Fall.</param>
        /// <param name="year">Year.</param>
        /// <param name="latitude">Latitude.</param>
        /// <param name="longitude">Longitude.</param>
        /// <returns>Created meteorite.</returns>
        public static Meteorite Create(
            int externalId,
            string name,
            NameType nameType,
            string recClass,
            double mass,
            bool fall,
            int year,
            double latitude,
            double longitude)
        {
            return new Meteorite(
                externalId: externalId,
                name: name,
                nameType: nameType,
                recClass: recClass,
                mass: mass,
                fall: fall,
                year: year,
                latitude: latitude,
                longitude: longitude);
        }

        /// <summary>
        /// Change meteorite.
        /// </summary>
        /// <param name="name">New name.</param>
        /// <param name="nameType">New name type.</param>
        /// <param name="recClass">New class.</param>
        /// <param name="mass">New mass.</param>
        /// <param name="fall">New fall.</param>
        /// <param name="year">New year.</param>
        /// <param name="latitude">New latitude.</param>
        /// <param name="longitude">New longitude.</param>
        public void Change(
            string name,
            NameType nameType,
            string recClass,
            double mass,
            bool fall,
            int year,
            double latitude,
            double longitude)
        {
            this.ChangeName(name);
            this.ChangeNameType(nameType);
            this.ChangeRecClass(recClass);
            this.ChangeMass(mass);
            this.ChangeFall(fall);
            this.ChangeYear(year);
            this.ChangeLatitude(latitude);
            this.ChangeLongitude(latitude);
        }

        private void ChangeName(string name)
        {
            if (this.Name == name)
            {
                return;
            }

            this.Name = name;
        }

        private void ChangeNameType(NameType nameType)
        {
            if (this.NameType == nameType)
            {
                return;
            }

            this.NameType = nameType;
        }

        private void ChangeRecClass(string recClass)
        {
            if (this.RecClass == recClass)
            {
                return;
            }

            this.RecClass = recClass;
        }

        private void ChangeMass(double mass)
        {
            if (double.Equals(this.Mass, mass))
            {
                return;
            }

            this.Mass = mass;
        }

        private void ChangeFall(bool fall)
        {
            if (this.Fall == fall)
            {
                return;
            }

            this.Fall = fall;
        }

        private void ChangeYear(int year)
        {
            if (this.Year == year)
            {
                return;
            }

            this.Year = year;
        }

        private void ChangeLatitude(double latitude)
        {
            if (double.Equals(this.Latitude, latitude))
            {
                return;
            }

            this.Latitude = latitude;
        }

        private void ChangeLongitude(double longitude)
        {
            if (double.Equals(this.Longitude, longitude))
            {
                return;
            }

            this.Longitude = longitude;
        }
    }
}