using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class ObjectSerialization<T>
    {
        public T ObjectToSerialize { get; private set; }
        public string FilePlacement { get; private set; }



        public ObjectSerialization(T objectToSerialize, string filePlacement)
        {
            ObjectToSerialize = objectToSerialize;
            FilePlacement = filePlacement;
        }

        public void Serialize()
        {
            using (Stream stream = File.Open(FilePlacement, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, ObjectToSerialize);
            }
        }

        public T DeSerialize()
        {
            using (Stream stream = File.Open(FilePlacement, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                var res = (T)bformatter.Deserialize(stream);

                return res;
            }

        }
    }
}
