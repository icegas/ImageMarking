using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ImageMarking
{
    public class DataKeeper
    {
        //public String Path { get; set; }
        protected List<string> imgFiles;
        public bool Empty { get; private set; }
        public string CurrentImgFile { get; private set; }
        protected string folder;
        public int ImgWidth { get; set; }
        public int ImgHeight { get; set; }
        protected List<string> trainData;
        protected List<string> testData;
        int split;

        protected List<ObjectData> objData;

        public DataKeeper(string path)
        {
            imgFiles = new List<string>();
            objData = new List<ObjectData>();
            testData = new List<string>();
            trainData = new List<string>();
            folder = Directory.GetParent(path).ToString(); 

            if (path != "")
            {
                foreach (string f in Directory.GetFiles(path))
                {
                    imgFiles.Add(f);
                }
            }
            IsEmpty();
            split = imgFiles.Count * 2 / 3;
        }

        public void SetData(ObjectData data)
        {
            objData.Add(data);
        }

        protected void IsEmpty()
        {
            if (!imgFiles.Any())
                Empty = true;
            else
                Empty = false;
        }

        public string Next()
        {
            CurrentImgFile = imgFiles[0];
            string imgName = CurrentImgFile.Substring(CurrentImgFile.LastIndexOf('\\') + 1);
            int index = imgName.IndexOf(".");
            imgName = imgName.Substring(0, index);

            if (trainData.Count > split)
                testData.Add(imgName);
            else
                trainData.Add(imgName);

            imgFiles.RemoveAt(0);
            IsEmpty();
            return CurrentImgFile;
        }

        public void CreateTxtData()
        {
            if(!Directory.Exists(folder + "\\ImageSets\\"))
                Directory.CreateDirectory(folder + "\\ImageSets\\");
            StreamWriter wrTrain = new StreamWriter(folder + "\\ImageSets\\train.txt");
            StreamWriter wrTest = new StreamWriter(folder + "\\ImageSets\\test.txt");

            foreach (string s in trainData)
                wrTrain.WriteLine(s);
            foreach (string s in testData)
                wrTest.WriteLine(s);

            wrTest.Close();
            wrTrain.Close();
        }

        protected string RemoveAllChar(char c, string str)
        {
            while (str.Contains(c))
            {
                str = str.Substring(folder.IndexOf('\\') + 1);
            }
            return str;
        }

        public void Parse()
        {
            //var result = str.Substring(str.LastIndexOf('-') + 1);
            string folderName = folder.Substring(folder.LastIndexOf('\\') + 1);
            string fileName = CurrentImgFile.Substring(CurrentImgFile.LastIndexOf('\\') + 1);
            int index = fileName.IndexOf(".");
            string annotations = folder + "\\Annotations\\";
            string xmlImgFile = annotations + fileName.Substring(0, index) + ".xml";
            if (!Directory.Exists(annotations))
                Directory.CreateDirectory(annotations);

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
                NewLineOnAttributes = true
            };

            using (XmlWriter writer = XmlWriter.Create(xmlImgFile, xmlWriterSettings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("annotation");

                writer.WriteElementString("folder", folderName);
                writer.WriteElementString("filename", fileName);

                writer.WriteStartElement("size");
                writer.WriteElementString("width", Convert.ToString(ImgWidth));
                writer.WriteElementString("height", Convert.ToString(ImgWidth));
                writer.WriteElementString("depth", "3");
                writer.WriteEndElement();

                foreach(ObjectData obj in objData)
                {
                    writer.WriteStartElement("object");
                    writer.WriteElementString("name", obj.name);

                    writer.WriteStartElement("bndbox");
                    writer.WriteElementString("xmin", Convert.ToString(obj.xMin));
                    writer.WriteElementString("ymin", Convert.ToString(obj.yMin));
                    writer.WriteElementString("xmax", Convert.ToString(obj.xMax));
                    writer.WriteElementString("ymax", Convert.ToString(obj.yMax));
                    writer.WriteEndElement();
       
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                

                objData = new List<ObjectData>();



            }

        }

    }
}
