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

    [Guid("52DD07AA-3F08-4976-A1A3-5E0D091D4FE4")]
    [ComVisible(true)]
    public interface IBranches: IEnumerable
    {
        new IEnumerator GetEnumerator();
    }

    [Guid("E2B64E31-85AD-4948-B4AD-AB72A8596AC9")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ProgId("GitRepository")]
    public class Branches : IBranches
    {

        internal BranchCollection _branchCollection { get; set; }

        public IEnumerator GetEnumerator()
        {
            var list = _branchCollection.Select(BranchWrapper.CreateBranchWrapperFromBranch);
            return list.GetEnumerator();
        }
    }
}
