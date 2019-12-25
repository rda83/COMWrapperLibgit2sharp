using LibGit2Sharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace COMWrapperLibgit2sharp
{



    [Guid("949BAA07-CE97-4E2B-B39A-FF543F882338")]
    [ComVisible(true)]
    public interface ICommits : IEnumerable
    {
        new IEnumerator GetEnumerator();
    }

    [Guid("8BA3D9D5-5C36-4B5E-A930-418D67E5A97A")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ProgId("GitRepository")]
    public class Commits : ICommits
    {

        internal IQueryableCommitLog _commitLog { get; set; }

        public IEnumerator GetEnumerator()
        {
            var list = _commitLog.Select(CommitWrapper.CreateCommitWrapperFromCommit);
            return list.GetEnumerator();
        }
    }


}
