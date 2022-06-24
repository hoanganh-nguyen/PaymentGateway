﻿using PaymentGateway.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Interfaces.Validator
{
    public interface ICreditCardValidator
    {
        bool IsValid(CreditCard card);
    }
}