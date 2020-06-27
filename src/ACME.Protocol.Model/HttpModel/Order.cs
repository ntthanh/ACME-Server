﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TGIT.ACME.Protocol.HttpModel
{
    public class Order
    {
        public Order(Model.Order model,
            IEnumerable<string> authorizationUrls, string finalizeUrl, string certificateUrl)
        {
            if (model is null)
                throw new System.ArgumentNullException(nameof(model));

            if (authorizationUrls is null)
                throw new System.ArgumentNullException(nameof(authorizationUrls));

            if (string.IsNullOrEmpty(finalizeUrl))
                throw new System.ArgumentNullException(nameof(finalizeUrl));

            if (string.IsNullOrEmpty(certificateUrl))
                throw new System.ArgumentNullException(nameof(certificateUrl));

            Status = model.Status.ToString().ToLowerInvariant();
            
            Expires = model.Expires?.ToString("o", CultureInfo.InvariantCulture);
            NotBefore = model.NotBefore?.ToString("o", CultureInfo.InvariantCulture);
            NotAfter = model.NotAfter?.ToString("o", CultureInfo.InvariantCulture);

            Identifiers = model.Identifiers.Select(x => new Identifier(x)).ToList();

            Authorizations = new List<string>(authorizationUrls);
            Finalize = finalizeUrl;
            Certificate = certificateUrl;

            if(model.Error != null)
                Error = new AcmeError(model.Error);
        }

        public string Status { get; }

        public List<Identifier> Identifiers { get; }

        public string? Expires { get; }
        public string? NotBefore { get; }
        public string? NotAfter { get; }

        public AcmeError? Error { get; }

        public IEnumerable<string> Authorizations { get; }
        public string Finalize { get; }
        public string? Certificate { get; }
    }
}