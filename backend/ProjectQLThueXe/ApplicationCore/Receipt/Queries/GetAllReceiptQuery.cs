﻿using MediatR;
using ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Receipt.Queries
{
    public class GetAllReceiptQuery : IRequest<IEnumerable<Receipts>>{}
}
