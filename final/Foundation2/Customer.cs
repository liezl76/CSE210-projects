using System;
using System.Collections.Generic;

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        this._name = name;
        this._address = address;
    }

    public bool IsUsaCustomer()
    {
        return _address.IsUsaAddress();
    }

    public string Name { get { return _name; } }

    public string GetAddressString()
    {
        //Get a formatted string representation of the customer's address
        return _address.ToString();
    }
}