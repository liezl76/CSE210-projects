using System;
using System.Collections.Generic;

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsUsaAddress()
    {
        // Check if the address is in the USA
        return _country == "USA";
    }

    public override string ToString()
    {
        // Get a formatted string representation of the address
        return $"{_streetAddress}, {_city}, {_state}, {_country}";
    }
}