using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSOFT.Config
{
    internal class FlattenConfigModel : ConfigModel
    {
        public int ID { get; set; }
        public int Parent { get; set; }

        public FlattenConfigModel(ConfigModel other)
        {
            this.Value = other.Value;
            this.Children = other.Children;
            this.Name = other.Name;
            this.Wrong = other.Wrong;
            this.Attributes = other.Attributes;
        }
        public FlattenConfigModel()
        {

        }
        public override byte[] ToByteArray()
        {
            if (Attributes == null)
            {
                Attributes = new AttributesCollection();
            }
            var ms = new MemoryStream();
            byte[] name = Encoding.UTF8.GetBytes(Name ?? string.Empty);
            byte[] data = ObjectToByteArray();
            byte[] atts = ArrayToByteArray(Attributes.ToArray());
            ms.Write(new byte[] { (byte)name.Length }, 0, 1);
            ms.Write(new byte[] { (byte)GetObjectType() }, 0, 1);
            if (data == null)
            {
                ms.Write(BitConverter.GetBytes(0), 0, 4);
            }
            else
            {
                ms.Write(BitConverter.GetBytes(data.Length), 0, 4);
            }
            ms.Write(BitConverter.GetBytes(Parent), 0, 4);
            if (atts == null)
            {
                ms.Write(BitConverter.GetBytes(0), 0, 4);
            }
            else
            {
                ms.Write(BitConverter.GetBytes(atts.Length), 0, 4);
            }
            ms.Write(name, 0, name.Length);
            if (data != null)
            {
                ms.Write(data, 0, data.Length);
            }
            if (atts != null)
            {
                ms.Write(atts, 0, atts.Length);
            }
            return ms.ToArray();
        }
        public static FlattenConfigModel FromByteArray(byte[] data, int id)
        {
            try
            {
                var v = new FlattenConfigModel();
                var ms = new MemoryStream(data);
                byte[] one = new byte[1];
                ms.Read(one, 0, 1);
                int namelen = one[0];
                ms.Read(one, 0, 1);
                ObjectType type = (ObjectType)one[0];
                byte[] databen = new byte[4];
                ms.Read(databen, 0, 4);
                int datalen = BitConverter.ToInt32(databen,0);
                ms.Read(databen, 0, 4);
                v.Parent = BitConverter.ToInt32(databen,0);
                ms.Read(databen, 0, 4);
                int attslen = BitConverter.ToInt32(databen,0);
                byte[] namebin = new byte[namelen];
                ms.Read(namebin, 0, namelen);
                v.Name = Encoding.UTF8.GetString(namebin);
                byte[] rawdata = new byte[datalen];
                ms.Read(rawdata, 0, datalen);
                v.Value = ByteArrayToObject(rawdata, type);
                byte[] attsdata = new byte[attslen];
                ms.Read(attsdata, 0, attslen);
                v.Attributes = ConfigValue.FromByteArraies(attsdata);
                v.ID = id;
                return v;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ConfigModel ToNormalize(List<FlattenConfigModel> flattens)
        {
            var config = flattens.Where(x => x.ID == 0).FirstOrDefault();
            if (config == null)
            {
                return null;
            }
            //ゼロ番目の項目(すべての親)をフラットリストから削除
            flattens.Remove(config);
            Normalizing(config,flattens);
            return config;
        }
        private static void Normalizing(FlattenConfigModel fcm,List<FlattenConfigModel> flattens)
        {
            var ps = flattens.ToArray().Where(x => x.Parent == fcm.ID);
            foreach (var p in ps)
            {
                if (fcm.Children == null)
                {
                    fcm.Children = new List<ConfigModel>();
                }
                fcm.Children.Add(p);
                if (flattens.Contains(p))
                {
                    flattens.Remove(p);
                }
                Normalizing(p,flattens);
            }
        }
        public static byte[] ArrayToByteArray(ConfigValue[] objs)
        {
            if (objs.Length == 0) { return null; }
            var ms = new MemoryStream();
            foreach (var obj in objs)
            {
                byte[] b = obj.ToByteArray();
                ms.Write(BitConverter.GetBytes(b.Length), 0, 4);
                ms.Write(b, 0, b.Length);
            }
            return ms.GetBuffer();
        }
    }
}
