using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.Interfaces.Annotations;
using Audit.Interfaces.Annotations.SecurityConcern;
using Audit.Interfaces.Annotations.SecurityCritical;

namespace Cryptography.Core
{
    [ImmatureConstructionSecurityConcern]
    [SecurityCriticalThatThisIsNotUsed]
    public static class RiskyCryptoFactory
    {
    }
}
