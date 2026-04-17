using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Drawing.Printing;

namespace WindowsFormsApplication1.XmlTest
{
    public partial class XmlTestForm1 : Form
    {
        public string FilePath 
        { 
            get 
            {
                string path = Application.StartupPath + @"\XmlTest\XmlFile1.xml";
                return path;
            }         
        }
        public string ImagePath = Application.StartupPath + @"/sample.jpg";
        private const string drawCommand = "DrawCommand";
        private const string drawCommandList = "DrawCommandList";
        private const string dataField = "DataField";

        public XmlTestForm1()
        {
            InitializeComponent();
            AddEvents();
        }

        private void XmlTestForm1_Load(object sender, EventArgs e)
        {
            //LoadXmlDocument();
            Test();
        }

        private void AddEvents()
        {
            this.Load += new EventHandler(XmlTestForm1_Load);
        }

        private void Test()
        {
            XDocument newDoc = new XDocument(new XDeclaration("1.0","utf-8",null), "");
            string xml = newDoc.ToString();
            string declaration = new XDeclaration("1.0", "utf-8", null).ToString();

            var printers = PrinterSettings.InstalledPrinters;

            foreach (var printer in printers)
            {
                Console.WriteLine(printer);
            }
            
            //string xmlData = File.ReadAllText(FilePath);

            //XmlDocument doc = new XmlDocument();
            //doc.Load(new StringReader(xmlData));

            //XElement xdoc = XElement.Load(new StreamReader(xmlData));
        }


        private void LoadXmlDocument()
        {
            //using xpath
            /*
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(FilePath);
            XmlNode node = xdoc.SelectSingleNode("CmBarcode/DrawCommandList");
            */

            //XDocument xdoc = XDocument.Load(FilePath);
            XElement xdoc = XElement.Load(FilePath);
            var elements = xdoc.Elements();
            XElement commandElement = xdoc.Elements().FirstOrDefault(x => x.Name.LocalName == drawCommandList);

            if (commandElement == null) return;

            if (commandElement.HasElements)
            {
                var children = commandElement.Descendants(drawCommand)
                    .Where(x=> x.Attributes()
                                       .Any(y=> string.Equals(y.Name.LocalName, dataField, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(y.Value)));

                foreach (XElement child in children)
                {
                    if (child.Attribute(dataField).Value == "CORPORATION")
                        child.Attribute("Text").Value = "테스트1234";
                }
            }
        }

        private void ChangeValue()
        {
        }

        //var element = xdoc.Elements("MyXmlElement").Single();
        //element.Value = "foo";
        //xdoc.Save("file.xml");

        private void ConvertXmlToBytes()
        {
            string xmlData = File.ReadAllText(FilePath);

            //byte[] imageBytes = Encoding.UTF8.GetBytes(xmlData);
            byte[] imageBytes = Encoding.Default.GetBytes(xmlData);
        }

        private void SetImage(byte[] bytesArr)
        {
            /*
             MemoryStream ms = new MemoryStream(byteArrayIn,0,byteArrayIn.Length);
        ms.Write(byteArrayIn, 0, byteArrayIn.Length);
        returnImage = Image.FromStream(ms,true);
             */

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            Bitmap b = (Bitmap)tc.ConvertFrom(bytesArr);
            pictureBox1.Image = b;
        }

        public static byte[] ConvertToBytes(XmlDocument doc)
        {
            Encoding encoding = Encoding.UTF8;
            byte[] docAsBytes = encoding.GetBytes(doc.OuterXml);
            return docAsBytes;
        } 

        private IList<DrawingElement> ReadXmlDocument()
        {
            XElement xdoc = XElement.Load(FilePath);
            var elements =xdoc.Elements();

            IList<DrawingElement> drawingElements = new List<DrawingElement>();
            foreach (XElement element in elements)
            {
                drawingElements.Add(GetParentElement(element));               
            }

            return drawingElements;
        }

        private DrawingElement GetDrawingElement(XElement element)
        {
            DrawingElement d = new DrawingElement()
               {
                   Name = element.Name.ToString(),
                   Value = element.Value
               };

            if (element.HasElements)
            {
                var commandList = new List<DrawingCommand>();

                foreach (XElement command in element.Descendants(drawCommand))
                {
                    DrawingCommand cmd = new DrawingCommand();
                    IEnumerable<XAttribute> attributes = command.Attributes();

                    foreach (XAttribute attribute in command.Attributes())
                    {
                        cmd.SetProperty(attribute.Name.LocalName, attribute.Value);
                    }

                    commandList.Add(cmd);
                }
            }
            return d;
        }



        #region image <-> byte[]

        private byte[] ImageToBytes()
        {
            Image img = Image.FromFile(ImagePath);
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                // 메모리스트림에 이미지를 저장한다.
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                // 메모리스트림에 있는 콘텐츠를 바이트로 쓴다.
                arr = ms.ToArray();
            }
            return arr;
        }

        private Image BytesToImage(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image recImg = Image.FromStream(ms);
                return recImg;
            }
        }


        #endregion 

        #region iterative

        /// <summary>
        /// 부모 element 작업
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private DrawingElement GetParentElement(XElement element)
        {
            DrawingElement d = new DrawingElement()
            {
                Name = element.Name.ToString(),
                Value = element.Value
            };

            if (element.HasElements)
            {
                var commands = element.Descendants("DrawCommand");
                var commandList = new List<DrawingCommand>();

                foreach (var command in commands)
                {
                    DrawingCommand cmd = new DrawingCommand();
                    var attributes = command.Attributes();

                    foreach (XAttribute attribute in command.Attributes())
                    {
                        cmd.SetProperty(attribute.Name.LocalName, attribute.Value);   
                    }
                    commandList.Add(cmd);
                }
                //Dictionary<string, XElement> dict = element.Descendants("DrawCommand")
                //        .GroupBy(x => (string)x.Attributes()
                //                                       .Where(y => y.Name.LocalName == "type")
                //                                       .FirstOrDefault(), z => z)
                //        .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                /*
             
XDocument doc = XDocument.Load(FILENAME);

Dictionary<string, XElement> dict = doc.Descendants("ElementData").GroupBy(x => (string)x.Attributes().Where(y => y.Name.LocalName == "type").FirstOrDefault(), z => z)
    .ToDictionary(x => x.Key, y => y.FirstOrDefault());

XElement SecondElement = dict["SecondElement"];

SecondElement.Element("Description").SetValue("abcd");             
 */

               // GetSubElements(d.InnerList, element.Elements());
            }

            return d;
        }

        /// <summary>
        /// 하위 element 검색
        /// </summary>
        /// <param name="drawingElements"></param>
        /// <param name="elements"></param>
        /// <returns></returns>
        private void GetSubElements(List<DrawingElement> drawingElements, IEnumerable<XElement> elements)
        {
            foreach (XElement element in elements)
            {
                DrawingElement d = new DrawingElement()
                {
                    Name = element.Name.ToString(),
                    Value = element.Value
                };
                drawingElements.Add(d);

                if (element.HasElements)
                {
                  //  GetSubElements(d.InnerList, element.Elements());
                }
            }
        }

        #endregion

    }
}
