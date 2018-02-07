using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace WPLLib
{
    public class Media
    {
        string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }
        string _FilePath;
        public string FilePath
        {
            get
            {
                return _FilePath;
            }

            set
            {
                _FilePath = value;
            }
        }
    }

    public class MediaArray : IEnumerable
    {
        public int Count
        {
            get
            {
                return mediaList.Count;
            }
        }

        List<Media> mediaList = new List<Media>();
        public Media this[int index]
        {
            set
            {
                mediaList.Add(value);
            }
            get
            {
                return mediaList[index];
            }
        }

        public bool Contains(Media media)
        {
            return mediaList.Contains(media);
        }

        public void Add(Media media)
        {
            mediaList.Add(media);
        }
        public void Add(string mediaPath)
        {
            Media media = new Media()
            {
                FilePath = mediaPath,
                Name = Path.GetFileNameWithoutExtension(mediaPath)
            };
            mediaList.Add(media);
        }

        public IEnumerator GetEnumerator()
        {
            return mediaList.GetEnumerator();
        }
    }

    public class Writer
    {
        private XmlDocument xDocument;
        private XmlProcessingInstruction xDeclaration;
        private XmlElement xRoot;

        private string _FilePath;
        public string FilePath
        {
            get
            {
                return _FilePath;
            }
        }
        
        private string _Generator = "WPLLib";
        public string Generator
        {
            get
            {
                return _Generator;
            }
            set
            {
                _Generator = value;
            }
        }

        private FileStream fs;

        private MediaArray mediaList = new MediaArray();
        
        public Writer(string filePath)
        {
            _FilePath = filePath;
            fs = new FileStream(_FilePath, FileMode.OpenOrCreate, FileAccess.Write);
            InitializeDocument();
        }
        public Writer(string filePath, string generator)
        {
            _FilePath = filePath;
            fs = new FileStream(_FilePath, FileMode.OpenOrCreate, FileAccess.Write);
            _Generator = generator;
            InitializeDocument();
        }
        public Writer(FileStream fileStream)
        {
            fs = fileStream;
            InitializeDocument();
        }
        public Writer(FileStream fileStream, string generator)
        {
            fs = fileStream;
            _Generator = generator;
            InitializeDocument();
        }

        private void InitializeDocument()
        {
            xDocument = new XmlDocument();
            xDeclaration = xDocument.CreateProcessingInstruction("wpl", "version=\"1.0\"");
            xRoot = xDocument.CreateElement("smil");
        }

        public void Add(string mediaPath)
        {
            Media media = new Media()
            {
                FilePath = mediaPath,
                Name = Path.GetFileNameWithoutExtension(mediaPath)
            };

            if (!mediaList.Contains(media))
            {
                mediaList.Add(media);
            }
        }

        public void Write()
        {
            XmlElement xmeta = default(XmlElement);

            // Head
            XmlElement header = xDocument.CreateElement("head");

            xmeta = xDocument.CreateElement("meta");
            xmeta.SetAttribute("name", "Generator");
            xmeta.SetAttribute("content", _Generator);
            header.AppendChild(xmeta);

            xmeta = xDocument.CreateElement("meta");
            xmeta.SetAttribute("name", "ItemCount");
            xmeta.SetAttribute("content", mediaList.Count.ToString());
            header.AppendChild(xmeta);

            // Body
            XmlElement bodier = xDocument.CreateElement("body");
            XmlElement seqer = xDocument.CreateElement("seq");
            XmlElement xmedia = default(XmlElement);

            foreach (Media media in mediaList)
            {
                xmedia = xDocument.CreateElement("media");
                xmedia.SetAttribute("src", media.FilePath);
                seqer.AppendChild(xmedia);
            }

            //seqの追加
            bodier.AppendChild(seqer);

            //ヘッダーとボディーの追加
            xRoot.AppendChild(header);
            xRoot.AppendChild(bodier);

            //宣言の追加
            xDocument.AppendChild(xDeclaration);
            //smilの追加
            xDocument.AppendChild(xRoot);

            xDocument.Save(fs);
        }
    }

    public class Reader
    {
        private string _FilePath;
        public string FilePath
        {
            get
            {
                return _FilePath;
            }
        }

        private string _Generator = "WPLLib";
        public string Generator
        {
            get
            {
                return _Generator;
            }
            set
            {
                _Generator = value;
            }
        }

        private FileStream fs;

        private MediaArray mediaList = new MediaArray();

        public Reader(string filePath)
        {
            _FilePath = filePath;
            fs = new FileStream(_FilePath, FileMode.OpenOrCreate, FileAccess.Read);
        }
        public Reader(FileStream fileStream)
        {
            fs = fileStream;
        }

        public void Read()
        {
            XmlDocument xDocument = new XmlDocument();
            XmlElement xRoot = default(XmlElement);
            XmlNodeList xDataList = default(XmlNodeList);
            XmlNodeList xMediaList = default(XmlNodeList);

            ArrayList media = new ArrayList();

            xDocument.Load(fs);

            xRoot = xDocument.DocumentElement;

            xDataList = xRoot.GetElementsByTagName("body");
            foreach (XmlElement xElement in xDataList)
            {
                xMediaList = xElement.GetElementsByTagName("media");
                foreach (XmlElement xMedia in xMediaList)
                {
                    mediaList.Add(xMedia.SelectSingleNode("@src").Value);
                }
            }
        }

        public MediaArray GetMediaArray()
        {
            return mediaList;
        }
    }
}
