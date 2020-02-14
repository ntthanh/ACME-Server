﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ACME.Protocol.Model
{
    public class AcmeRequestContext
    {
        public AcmeRequestContext(IServiceProvider services)
        {
            Services = services;
        }

        public IServiceProvider Services { get; }
        
        public AcmeNonce Nonce { get; internal set; }
    }
}
