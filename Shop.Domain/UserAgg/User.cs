﻿using Shop.Domain.Shared;
using Shop.Domain.UserAgg.Events;
using Shop.Domain.Users.ValueObjects;

namespace Shop.Domain.UserAgg;

public class User : AggregateRoot
{
    private User()
    {
        
    }
    public User(string name, string family, PhoneBook phoneBook, string email)
    {
        Name = name;
        Family = family;
        PhoneBook = phoneBook;
        Email = email;
    }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Family { get; private set; }
    public PhoneBook PhoneBook { get; private set; }
    public UserRole Role { get; set; }

    public static User Register(string email)
    {
        var user = new User("", "", null, email);
        user.AddDomainEvent(new UserRegistered(user.Id, email));
        return user;
    }
    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
}