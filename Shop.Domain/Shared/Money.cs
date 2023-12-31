﻿using Microsoft.VisualBasic.CompilerServices;
using Shop.Domain.Shared.Exceptions;

namespace Shop.Domain.Shared;

public class Money : BaseValueObject
{
    public int RialValue { get; }

    private Money()
    {
        
    }
    public Money(int rialValue)
    {
        if (rialValue < 0)
            throw new InvalidDomainDataException();

        RialValue = rialValue;
    }

    public static Money FromRial(int value)
    {
        return new Money(value);
    }
    public static Money FromTooman(int value)
    {
        return new Money(value * 10);
    }

    public static Money operator +(Money firstMony, Money mony2)
    {
        return new Money(firstMony.RialValue + mony2.RialValue);
    }

    public override string ToString()
    {
        return RialValue.ToString("#,0");
    }

    public static Money operator -(Money firstMony, Money mony2)
    {
        return new Money(firstMony.RialValue - mony2.RialValue);
    }
}