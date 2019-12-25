using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace COMWrapperLibgit2sharp
{



    [Guid("5F511AA9-7177-49C6-94DE-961C069ABAC4")]
    [ComVisible(true)]
    public interface ICommitWrapper
    {
        string MessageShort();
    }

    [Guid("31143738-16FC-4F6D-BDFC-9C5051904111")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ProgId("GitRepository")]
    public class CommitWrapper : ICommitWrapper
    {

        internal Commit _commit { set; get; }

        internal static CommitWrapper CreateCommitWrapperFromCommit(Commit commit)
        {
            var result = new CommitWrapper();
            result._commit = commit;
            return result;
        }

        public string MessageShort()
        {
            return _commit.MessageShort;

        }
    }

   
}
