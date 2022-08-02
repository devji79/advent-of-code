using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day_2
{
    public class PasswordDebugItem
    {
        public string originalData { get; set; }
        public string password { get; set; }
        public IList<PasswordPolicy> passwordPolicies { get; set; }

        public bool IsFrequencyValid()
        {
            foreach (var policy in passwordPolicies)
            {
                var passwordCharCount = password.ToCharArray().Count(pc => pc == policy.Letter);
                if (passwordCharCount < policy.Min || passwordCharCount > policy.Max)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsPositionValid()
        {
            var passwordChars = password.ToCharArray();
            foreach (var policy in passwordPolicies)
            {
                if (passwordChars[policy.Min - 1] == policy.Letter && passwordChars[policy.Max - 1] == policy.Letter)
                {
                    return false;
                }

                if (passwordChars[policy.Min - 1] != policy.Letter && passwordChars[policy.Max - 1] != policy.Letter)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
