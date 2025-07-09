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
        /// <param name="recClass">Class.</param>
        /// <param name="mass">Mass.</param>
        /// <param name="year">Year.</param>
        private Meteorite(
            int externalId,
            string name,
            string recClass,
            double mass,
            int year)
        {
            this.ExternalId = externalId;
            this.Name = name;
            this.RecClass = recClass;
            this.Mass = mass;
            this.Year = year;
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
        /// Gets recClass.
        /// </summary>
        public string RecClass { get; private set; } = string.Empty;

        /// <summary>
        /// Gets mass.
        /// </summary>
        public double Mass { get; private set; }

        /// <summary>
        /// Gets year.
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// Create meteorite.
        /// </summary>
        /// <param name="externalId">External id.</param>
        /// <param name="name">Name.</param>
        /// <param name="recClass">Class.</param>
        /// <param name="mass">Mass.</param>
        /// <param name="year">Year.</param>
        /// <returns>Created meteorite.</returns>
        public static Meteorite Create(
            int externalId,
            string name,
            string recClass,
            double mass,
            int year)
        {
            return new Meteorite(
                externalId: externalId,
                name: name,
                recClass: recClass,
                mass: mass,
                year: year);
        }

        /// <summary>
        /// Change meteorite.
        /// </summary>
        /// <param name="name">New name.</param>
        /// <param name="recClass">New class.</param>
        /// <param name="mass">New mass.</param>
        /// <param name="year">New year.</param>
        public void Change(
            string name,
            string recClass,
            double mass,
            int year)
        {
            this.ChangeName(name);
            this.ChangeRecClass(recClass);
            this.ChangeMass(mass);
            this.ChangeYear(year);
        }

        private void ChangeName(string name)
        {
            if (this.Name == name)
            {
                return;
            }

            this.Name = name;
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

        private void ChangeYear(int year)
        {
            if (this.Year == year)
            {
                return;
            }

            this.Year = year;
        }
    }
}