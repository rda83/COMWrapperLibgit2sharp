using LibGit2Sharp;
using System;
using System.Runtime.InteropServices;

namespace COMWrapperLibgit2sharp
{
    [Guid("D77F8E06-13BE-4043-B646-AAAFB1FCD747")]
    [ComVisible(true)]
    public interface IGitRepository
    {
        Repository GetRepository(string repositoryPath);
        Branch Checkout(Repository repository, string branchName);
    }

    [Guid("A27376DA-E8CA-4EFF-896E-586C91A46257")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ProgId("GitRepository")]
    public class GitRepository : IGitRepository
    {

        public void Initialization()
        {
        }

        public Repository GetRepository(string repositoryPath)
        {
            return new Repository(repositoryPath);
        }

        public Branch Checkout(Repository repository, string branchName)
        {

            Branch branch = repository.Branches[branchName];

            if (branch == null)
            {
                return null;
            }

            Branch currentBranch = Commands.Checkout(repository, branch);
            return currentBranch;
        }
    }
}