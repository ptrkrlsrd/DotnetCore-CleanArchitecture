﻿using System;
using System.Runtime.Serialization;

namespace CleanArchitecture.Domain.Exceptions
{
    public class AdAccountInvalidException : Exception
    {
        public AdAccountInvalidException(string adAccount, Exception ex)
            : base($"AD Account \"{adAccount}\" is invalid.", ex)
        {
        }

        protected AdAccountInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
