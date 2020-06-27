using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace WPF_XML.Helper
{
    public static class XPathProcessor
    {
        public static XPathProcessorResult Process(string xmlFile, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            XPathNavigator nav = doc.CreateNavigator();

            XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);

            XPathExpression expr = XPathExpression.Compile(xpath, nsMgr);

            object result;
            if (expr.ReturnType == XPathResultType.NodeSet)
                result = doc.SelectNodes(xpath, nsMgr);
            else
                result = nav.Evaluate(expr);

            XPathProcessorResult processorResult = new XPathProcessorResult(result, expr.ReturnType);

            return processorResult;
        }
    }
}
