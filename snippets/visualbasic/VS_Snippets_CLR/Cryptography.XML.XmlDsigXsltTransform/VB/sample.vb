﻿'<SNIPPET1> 
'
' This example signs an XML file using an
' envelope signature. It then verifies the 
' signed XML.
'
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Xml
Imports System.Text
Imports System.Xml



Module SignVerifyEnvelope


    Sub Main(ByVal args() As String)
        ' Generate a signing key.
        Dim Key As RSA = RSA.Create()

        Dim xsl As String = "<xs:transform xmlns:xs='http://www.w3.org/1999/XSL/Transform' version='1.0'> <xs:template match='/'> <xs:apply-templates/> </xs:template> <xs:template match='ElementToTransform'> <transformedElement/> </xs:template> </xs:transform>"

        Try
            ' Create an XML file to sign.
            CreateSomeXml("Example.xml")
            Console.WriteLine("New XML file created.")

            ' Sign the XML that was just created and save it in a 
            ' new file.
            SignXmlFile("Example.xml", "SignedExample.xml", Key, xsl)
            Console.WriteLine("XML file signed.")

            ' Verify the signature of the signed XML.
            Console.WriteLine("Verifying signature...")
            Dim result As Boolean = VerifyXmlFile("SignedExample.xml")

            ' Display the results of the signature verification to \
            ' the console.
            If result Then
                Console.WriteLine("The XML signature is valid.")
            Else
                Console.WriteLine("The XML signature is not valid.")
            End If
        Catch e As CryptographicException
            Console.WriteLine(e.Message)
        Finally
            Key.Clear()
        End Try

    End Sub


    ' Sign an XML file and save the signature in a new file.
    Sub SignXmlFile(ByVal FileName As String, ByVal SignedFileName As String, ByVal Key As RSA, ByVal XSLString As String)
        ' Create a new XML document.
        Dim doc As New XmlDocument()

        ' Format the document to ignore white spaces.
        doc.PreserveWhitespace = False

        ' Load the passed XML file using it's name.
        doc.Load(New XmlTextReader(FileName))

        ' Create a SignedXml object.
        Dim signedXml As New SignedXml(doc)

        ' Add the key to the SignedXml document. 
        signedXml.SigningKey = Key

        ' Create a reference to be signed.
        Dim reference As New Reference()
        reference.Uri = ""

        ' Add an enveloped transformation to the reference.
        Dim env As New XmlDsigEnvelopedSignatureTransform()
        reference.AddTransform(env)

        ' Create an XmlDsigXPathTransform object using 
        ' the helper method 'CreateXPathTransform' defined
        ' later in this sample.
        Dim XsltTransform As XmlDsigXsltTransform = CreateXsltTransform(XSLString)

        ' Add the transform to the reference.
        reference.AddTransform(XsltTransform)

        ' Add the reference to the SignedXml object.
        signedXml.AddReference(reference)

        ' Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
        Dim keyInfo As New KeyInfo()
        keyInfo.AddClause(New RSAKeyValue(CType(Key, RSA)))
        signedXml.KeyInfo = keyInfo

        ' Compute the signature.
        signedXml.ComputeSignature()

        ' Get the XML representation of the signature and save
        ' it to an XmlElement object.
        Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()

        ' Append the element to the XML document.
        doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, True))

        ' Save the signed XML document to a file specified
        ' using the passed string.
        Dim xmltw As New XmlTextWriter(SignedFileName, New UTF8Encoding(False))
        doc.WriteTo(xmltw)
        xmltw.Close()

    End Sub

    ' Verify the signature of an XML file and return the result.
    Function VerifyXmlFile(ByVal Name As String) As [Boolean]
        ' Create a new XML document.
        Dim xmlDocument As New XmlDocument()

        ' Format using white spaces.
        xmlDocument.PreserveWhitespace = True

        ' Load the passed XML file into the document. 
        xmlDocument.Load(Name)

        ' Create a new SignedXml object and pass it
        ' the XML document class.
        Dim signedXml As New SignedXml(xmlDocument)

        ' Find the "Signature" node and create a new
        ' XmlNodeList object.
        Dim nodeList As XmlNodeList = xmlDocument.GetElementsByTagName("Signature")

        ' Load the signature node.
        signedXml.LoadXml(CType(nodeList(0), XmlElement))

        ' Check the signature and return the result.
        Return signedXml.CheckSignature()

    End Function


    ' Create the XML that represents the transform.
    Function CreateXsltTransform(ByVal xsl As String) As XmlDsigXsltTransform
        Dim doc As New XmlDocument()
        doc.LoadXml(xsl)

        Dim xform As New XmlDsigXsltTransform()
        xform.LoadInnerXml(doc.ChildNodes)

        Return xform

    End Function


    ' Create example data to sign.
    Sub CreateSomeXml(ByVal FileName As String)
        ' Create a new XmlDocument object.
        Dim document As New XmlDocument()

        ' Create a new XmlNode object.
        Dim node As XmlNode = document.CreateNode(XmlNodeType.Element, "", "MyXML", "Don't_Sign")

        ' Append the node to the document.
        document.AppendChild(node)

        ' Create a new XmlNode object.
        Dim subnode As XmlNode = document.CreateNode(XmlNodeType.Element, "", "ElementToTransform", "Sign")

        ' Add some text to the node.
        subnode.InnerText = "Here is some data to sign."

        ' Append the node to the document.
        document.DocumentElement.AppendChild(subnode)

        ' Save the XML document to the file name specified.
        Dim xmltw As New XmlTextWriter(FileName, New UTF8Encoding(False))
        document.WriteTo(xmltw)
        xmltw.Close()

    End Sub
End Module
'</SNIPPET1> 