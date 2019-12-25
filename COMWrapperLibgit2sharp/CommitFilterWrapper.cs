using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMWrapperLibgit2sharp
{
    public class CommitFilterWrapper
    {

        CommitFilter _commitFilter;

        public CommitFilterWrapper()
        {
            _commitFilter = new CommitFilter();

        }

        public CommitFilterWrapper(object IncludeReachableFrom, object ExcludeReachableFrom)
        {
            _commitFilter = new CommitFilter();
            _commitFilter.IncludeReachableFrom = IncludeReachableFrom;
            _commitFilter.ExcludeReachableFrom = ExcludeReachableFrom;

        }
    }
}
