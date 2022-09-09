using System;
using BubbberDinner.Application.Common.interfaces;

namespace BubbberDinner.Infrastructure.Service;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}