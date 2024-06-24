﻿using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.PlayerAPI.Queries
{
    public record GetPlayersByCountryIdQuery(int CountryId) : IRequest<IEnumerable<Player>>
    {
    }
}
