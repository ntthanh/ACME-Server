﻿namespace TGIT.ACME.Protocol.Model.Exceptions
{
    public class MalformedRequestException : AcmeException
    {
        public MalformedRequestException(string message)
            : base(message)
        { }

        public override string ErrorType => "malformed";
    }

    public class NotFoundException : MalformedRequestException
    {
        public NotFoundException()
            :base("The resource requested by the request could not be found.")
        { }
    }

    public class NotAllowedException : MalformedRequestException
    {
        public NotAllowedException()
            : base("The resoruce requested by the request may not be accessed by the requestor.")
        { }
    }

    public class ConflictRequestException : MalformedRequestException
    {
        private ConflictRequestException(string resourceType, string attemptedStatus)
            : base($"The {resourceType} could not be set to the status of '{attemptedStatus}'")
        { }

        private ConflictRequestException(string resourceType, string expectedStatus, string actualStatus)
            : base($"The {resourceType} used in this request did not have the expected status '{expectedStatus}' but had '{actualStatus}'.")
        { }

        public ConflictRequestException(AccountStatus attemptedStatus)
            : this("account", $"{attemptedStatus}")
        { }

        public ConflictRequestException(OrderStatus attemptedStatus)
            : this("order", $"{attemptedStatus}")
        { }

        public ConflictRequestException(AuthorizationStatus attemptedStatus)
            : this("authorization", $"{attemptedStatus}")
        { }

        public ConflictRequestException(ChallengeStatus attemptedStatus)
            : this("challenge", $"{attemptedStatus}")
        { }
        
        public ConflictRequestException(AccountStatus expectedStatus, AccountStatus actualStatus)
            : this("account", $"{expectedStatus}", $"{actualStatus}")
        { }

        public ConflictRequestException(OrderStatus expectedStatus, OrderStatus actualStatus)
            : this("order", $"{expectedStatus}", $"{actualStatus}")
        { }

        public ConflictRequestException(AuthorizationStatus expectedStatus, AuthorizationStatus actualStatus)
            : this("authorization", $"{expectedStatus}", $"{actualStatus}")
        { }

        public ConflictRequestException(ChallengeStatus expectedStatus, ChallengeStatus actualStatus)
            : this("challenge", $"{expectedStatus}", $"{actualStatus}")
        { }
    }
}