using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Runtime.InteropServices;

namespace COMWrapperLibgit2sharp
{
    [Guid("D77F8E06-13BE-4043-B646-AAAFB1FCD747")]
    [ComVisible(true)]
    public interface IGitRepository
    {
        void OpenRepository(string repositoryPath);
        
        void Pull(string mergeUserName, string mergeUserEmail, string userName = "", string password = "");

        Branches GetBranches();
        Branch GetBranch(string branchName);

        BranchWrapper Checkout(string branchName);

        TestCollections GetTestCollections();

        Commits GetCommits();
        Commits GetCommits(object IncludeReachableFrom, object ExcludeReachableFrom);
        Commits GetCommitsByPath(string path);

    }

    [Guid("A27376DA-E8CA-4EFF-896E-586C91A46257")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ProgId("GitRepository")]
    public class GitRepository : IGitRepository
    {
        private Repository repository { get; set; }

        public void OpenRepository(string repositoryPath)
        {
            repository                  = new Repository(repositoryPath);
        }

        public BranchWrapper Checkout(string branchName)
        {

            Branch branch = repository.Branches[branchName];

            if (branch == null)
            {
                Helper.WriteLog(branchName);
                return null;
            }

            Branch currentBranch = Commands.Checkout(repository, branch);
            return BranchWrapper.CreateBranchWrapperFromBranch(currentBranch); 
        }

        public void Pull(string mergeUserName, string mergeUserEmail, string userName = "", string password = "")
        {
            LibGit2Sharp.PullOptions options = new LibGit2Sharp.PullOptions();
            options.FetchOptions = new FetchOptions();
            options.FetchOptions.CredentialsProvider = new CredentialsHandler(
                (url, usernameFromUrl, types) =>
                    new UsernamePasswordCredentials()
                    {
                        Username = userName,
                        Password = password
                    });

            var signature = new LibGit2Sharp.Signature(
                new Identity(mergeUserName, mergeUserEmail), DateTimeOffset.Now);

            Commands.Pull(repository, signature, options);
        }

        public Branches GetBranches()
        {

            var branches = new Branches();
            branches._branchCollection = repository.Branches;

            return branches; 
        }

        public TestCollections GetTestCollections()
        {
            return new TestCollections();
        }

        public Commits GetCommits()
        {

            var commits = new Commits();
            commits._commitLog = repository.Commits;

            return commits;
        }

        public Commits GetCommits(object IncludeReachableFrom, object ExcludeReachableFrom)
        {
            var commits = new Commits();

            
            var filter = new CommitFilter();
            filter.IncludeReachableFrom = IncludeReachableFrom;
            filter.ExcludeReachableFrom = ExcludeReachableFrom;

            commits._commitLog = (IQueryableCommitLog) repository.Commits.QueryBy(filter);

            return commits;
        }

        public Branch GetBranch(string branchName)
        {

            return repository.Branches[branchName];
        }

        public Commits GetCommitsByPath(string path)
        {
            var commits = new Commits();

            commits._commitLog = (IQueryableCommitLog) repository.Commits.QueryBy(path);

            return commits;
        }
    }
}