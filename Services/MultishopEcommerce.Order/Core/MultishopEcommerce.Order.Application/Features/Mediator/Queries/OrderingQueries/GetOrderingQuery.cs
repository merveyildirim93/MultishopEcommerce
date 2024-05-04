﻿using MediatR;
using MultishopEcommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery: IRequest<List<GetOrderingQueryResult>>
    {
    }
}
