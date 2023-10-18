﻿using Shop.Domain.Shared;

namespace Shop.Domain.Users.ValueObjects;

public class PhoneBook : BaseValueObject
{
    public PhoneNumber TelePhone { get; }
    public PhoneNumber Fax { get; }

    public PhoneBook(PhoneNumber telePhone, PhoneNumber fax)
    {
        TelePhone = telePhone;
        Fax = fax;
    }
}