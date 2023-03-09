using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Core
{
    [Audit.Interfaces.Annotations.SecurityConcern(description = "Nothing in this factory is suitable for production use.")]
    public static class RiskyCryptoFactory
    {
    }
}
