using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.Interfaces.Annotations;

namespace Cryptography.Core
{
    [SecurityConcern(description = "Nothing in this factory is suitable for production use.")]
    [SecurityCritical(description = "It is critical that you *don't* use this.")]
    public static class RiskyCryptoFactory
    {
    }
}
