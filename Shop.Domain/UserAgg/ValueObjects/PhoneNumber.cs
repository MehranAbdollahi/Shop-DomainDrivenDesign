﻿using Shop.Domain.Shared;

namespace Shop.Domain.UserAgg.ValueObjects;

public class PhoneNumber : BaseValueObject
{

    public string Phone { get; }

    public PhoneNumber(string phone)
    {
        if (phone.Length < 11 || phone.Length > 11)
            throw new InvalidDataException();

        Phone = phone;
    }

    private PhoneNumber()
    {
        
    }
}