using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MaratonaBotsBOT.BO
{
    public class Imagem
    {
        public static byte[] GetImageAsByteArray(byte[] imageFilePath)
        {
            //FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            Stream stream = new MemoryStream(imageFilePath);
            BinaryReader binaryReader = new BinaryReader(stream);
            return binaryReader.ReadBytes((int)stream.Length);
        }
    }
}