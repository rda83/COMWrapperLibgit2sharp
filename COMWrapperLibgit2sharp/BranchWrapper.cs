using LibGit2Sharp;
using System;
using System.Runtime.InteropServices;

/*
result.CanonicalName
result.Commits

result.FriendlyName
result.IsCurrentRepositoryHead
result.IsRemote
result.IsTracking
result.Reference
result.Tip
result.ToString
result.TrackedBranch
result.TrackingDetails
result.UpstreamBranchCanonicalName
*/

namespace COMWrapperLibgit2sharp
{

    [Guid("156F7009-B894-4ECC-9BBB-B9C94FDCFD86")]
    [ComVisible(true)]
    public interface IBrancheWrapper
    {
        string CanonicalName();
    }

    [Guid("BA08D202-36F2-4BD4-BD9A-027E9608BD80")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ProgId("GitRepository")]
    public class BranchWrapper: IBrancheWrapper
    {

        internal Branch _branch { set; get; }

        internal static BranchWrapper CreateBranchWrapperFromBranch(Branch branch)
        {      
            var result = new BranchWrapper();
            result._branch = branch;
            return result;
        }

        public string CanonicalName()
        {
            return _branch.CanonicalName;
        }
    }
}
