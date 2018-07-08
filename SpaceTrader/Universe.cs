using System;
using System.Collections;
using System.Collections.Generic;

namespace SpaceTrader
{
    public class Universe
    {
        ICollection<Galaxy> Galaxies { get; set; } = new List<Galaxy>();
    }
    public class Galaxy
    {
        ICollection<SolarSystem> SolarSystems { get; set; } = new List<SolarSystem>();

    }
    public class SolarSystem
    {
        ICollection<Planet> Planets { get; set; } = new List<Planet>();
    }
    public class Planet
    {
        ICollection<City> Cities { get; set; } = new List<City>();
    }
    public class City
    {
        ICollection<Resource> Resources { get; set; } = new List<Resource>();
    }
    public class Resource
    {
    }

    public class User
    {
        public Membership Membership { get; set; }
    }

    public class Membership
    {
        public Member Member { get; set; }
    }

    public class Member
    {
        ICollection<Character> Characters { get; set; } = new List<Character>();
    }
    public class Character
    {
        ICollection<Company> Companies { get; set; } = new List<Company>();
        ICollection<Business> Businesses { get; set; } = new List<Business>();
    }
    public class Company
    {
        Business Business { get; set; }
    }

    public class Business
    {
        ICollection<Office> Offices { get; set; } = new List<Office>();
        ICollection<Facility> Facilities { get; set; } = new List<Facility>();
        ICollection<Service> Services { get; set; } = new List<Service>();
        ICollection<Deal> OpenDeals { get; set; } = new List<Deal>();
        ICollection<Deal> DealsMade { get; set; } = new List<Deal>();
    }

    public class Office
    {
    }
    public class Facility
    {
    }
    public class Service
    {
    }
    public class Deal
    {
    }

    public class UnionOfStates
    {
        ICollection<State> States { get; set; } = new List<State>();
    }
    public class State
    {
        ICollection<Regulation> Regulations { get; set; } = new List<Regulation>();
        ICollection<StateOffice> StateOffces { get; set; } = new List<StateOffice>();
        ICollection<StateAgency> StateAgencies { get; set; } = new List<StateAgency>();
    }
    public class SovreignState: State
    {
        ICollection<FederalState> FederalStates { get; set; } = new List<FederalState>();
    }
    public class FederalState : State
    {
    }

    public class Regulation
    {
    }
    public class StateOffice
    {
    }
    public class StateAgency
    {
        ICollection<StateAgent> StateAgents { get; set; } = new List<StateAgent>();
    }
    public class StateAgent
    {
    }
    public class Import
    {
    }
    public class Export
    {
    }

    public class ChemicalCompound
    {
        IDictionary<Element, int> Composition { get; set; } = new Dictionary<Element, int>();
    }
    
    public class Element
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rarity { get; set; }
    }
}
