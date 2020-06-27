using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_XML.Helper;

namespace WPF_XML.ViewModel
{
    class XMLViewModel : BaseViewModel
    {
        private string xmlPathFile;
        public string XMLPathFile
        {
            get
            {
                return xmlPathFile;
            }
            set
            {
                this.xmlPathFile = value;
                this.OnPropertyChanged("XMLPathFile");
            }
        }

        private string xmlPath;
        public string XMLPath
        {
            get
            {
                return xmlPath;
            }
            set
            {
                this.xmlPath = value;
                this.OnPropertyChanged("XMLPath");
            }
        }

        private ICommand xmlProcessCommand;
        public ICommand XMLProcessCommand
        {
            get
            {
                if (xmlProcessCommand == null)
                {
                    xmlProcessCommand = new RelayCommand(ProcessXML);
                }
                return xmlProcessCommand;
            }
        }

        private string result;
        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                this.result = value;
                this.OnPropertyChanged("Result");
            }
        }

        public void ProcessXML(object param)
        {
            XPathProcessorResult result = XPathProcessor.Process(XMLPathFile, XMLPath);
            Result = result.Result;
        }
    }
}
