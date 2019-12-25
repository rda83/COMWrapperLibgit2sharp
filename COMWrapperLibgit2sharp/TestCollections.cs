using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace COMWrapperLibgit2sharp
{

    [Guid("13D400C8-C9AC-4286-B681-680BD4CD9E4C")]
    [ComVisible(true)]
    public interface IElement
    {
        string GetName();
    }

    [Guid("604F68E2-4F00-48F3-9B92-10F63FB49CD5")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ProgId("GitRepository")]
    public class Element: IElement
    {
        public string Name { get; set; }

        public string GetName()
        {
            return Name;
        }
    }


    [Guid("9268B238-E5B8-4D00-8557-A50A30EC0D19")]
    [ComVisible(true)]
    public interface ITestCollections: IEnumerable

    {
        string GetS();
        new IEnumerator GetEnumerator();
    }

    [Guid("630C3537-ECA6-4BE8-8367-23DF169160A5")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ProgId("GitRepository")]
    public class TestCollections: ITestCollections
    {

        private List<Element> _branches = new List<Element>();

        public string s { get; set; }

      


        public TestCollections() {

            s = "123";

            _branches.Add(new Element { Name = "123"});
            _branches.Add(new Element { Name = "124"});
            _branches.Add(new Element { Name = "125"});
            _branches.Add(new Element { Name = "126"});
            _branches.Add(new Element { Name = "127"});

        }

        public string GetS()
        {
            return s;
        }

        public IEnumerator GetEnumerator()
        {
            return _branches.GetEnumerator();
        } 
    }
}
