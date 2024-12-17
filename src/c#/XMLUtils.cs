using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;


namespace SpacePeace;

public class XMLUtils
{
    public static async Task ValidateXmlFileAsync(string schemaNamespace , string xsdFilePath , string xmlFilePath ) {
        var settings = new XmlReaderSettings();
        settings.Schemas.Add(schemaNamespace , xsdFilePath);
        settings.ValidationType= ValidationType.Schema;
        Console.WriteLine(" Nombre de schemas utilisés dans la validation:" + settings.Schemas.Count);
        settings.ValidationEventHandler += ValidationCallBack;
        var readItems = XmlReader.Create(xmlFilePath, settings ) ;
        while (readItems.Read()){ }
    } 

    private static void ValidationCallBack( object ? sender ,ValidationEventArgs e){
        if (e.Severity.Equals(XmlSeverityType.Warning))
        {
            Console.Write(" WARNING : ");
            Console.WriteLine(e.Message);
        }
        else if (e.Severity.Equals(XmlSeverityType.Error))
        { 
            Console.Write(" ERROR : ");
            Console.WriteLine(e.Message);
        }
    }   
    public static void XslTransform( string xmlFilePath , string xsltFilePath , string htmlFilePath)
    {
        if(!File.Exists(xmlFilePath))
            throw new FileNotFoundException("Fichier XML introuvable", xmlFilePath);
        if(!File.Exists(xsltFilePath))
            throw new FileNotFoundException("Fichier xslt introuvable", xsltFilePath);
        XsltSettings settings = new XsltSettings(true, true);
        XmlResolver resolver = new XmlUrlResolver();
        XPathDocument xpathDoc = new XPathDocument(xmlFilePath);
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(xsltFilePath, settings, resolver);
        XmlTextWriter htmlWriter = new XmlTextWriter(htmlFilePath, null);
        
        xslt.Transform(xpathDoc,null,htmlWriter);
        
    }


}