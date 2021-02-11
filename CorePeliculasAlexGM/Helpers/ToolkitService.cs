using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace CorePeliculasAlexGM.Helpers
{
    public class ToolkitService
    {
        public static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null) return null;

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }


        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            BinaryFormatter binForm = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream())
            {
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                Object obj = (Object)binForm.Deserialize(memStream);
                return obj;
            }
        }

        public static String SerializeJsonObject(object objeto)
        {
            String respuesta =
                JsonConvert.SerializeObject(objeto);
            return respuesta;
        }

   
        public static T DeserializeJsonObject<T>(String json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
