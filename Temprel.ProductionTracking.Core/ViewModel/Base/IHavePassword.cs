using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
    public interface IHavePassword
    {
        /// <summary>
        /// The Secure Password
        /// </summary>
        SecureString SecurePassword { get; }
    }
}
