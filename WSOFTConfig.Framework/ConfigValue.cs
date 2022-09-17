﻿using System;
using System.IO;
using System.Text;

namespace WSOFT.Config
{
    public class ConfigValue
    {
        /// <summary>
        /// これが表す値です
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// この値に関連付けられた名前です
        /// </summary>
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }
        private string m_name = string.Empty;
        public ObjectType Type => GetObjectType();

        public virtual byte[] ToByteArray()
        {
            var ms = new MemoryStream();
            byte[] name = Encoding.UTF8.GetBytes(Name);
            byte[] data = ObjectToByteArray();
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
            ms.Write(name, 0, name.Length);
            if (data != null)
            {
                ms.Write(data, 0, data.Length);
            }
            return ms.ToArray();
        }
        public static ConfigValue FromByteArray(byte[] data)
        {
            try
            {
                ConfigValue v = new ConfigValue();
                var ms = new MemoryStream(data);
                byte[] one = new byte[1];
                ms.Read(one, 0, 1);
                int namelen = one[0];
                ms.Read(one, 0, 1);
                ObjectType type = (ObjectType)one[0];
                byte[] databen = new byte[4];
                ms.Read(databen, 0, 4);
                int datalen = BitConverter.ToInt32(databen, 0);
                byte[] namebin = new byte[namelen];
                ms.Read(namebin, 0, namelen);
                v.Name = Encoding.UTF8.GetString(namebin);
                byte[] rawdata = new byte[datalen];
                ms.Read(rawdata, 0, datalen);
                v.Value = ByteArrayToObject(rawdata, type);
                return v;
            }
            catch
            {
                return null;
            }
        }
        protected static AttributesCollection FromByteArraies(byte[] data)
        {
            var l=new AttributesCollection();
            var ms=new MemoryStream(data);
            while (true)
            {
                byte[] b=new byte[4];
                if(4 > ms.Read(b, 0, 4))
                {
                    break;
                }
                else
                {
                    int len = BitConverter.ToInt32(b, 0);
                    byte[] datax = new byte[len];
                    ms.Read(datax, 0, len);
                    var c=FromByteArray(datax);
                    if (c != null)
                    {
                        l.Add(c);
                    }
                }
            }
            return l;
        }
        protected static object ByteArrayToObject(byte[] data, ObjectType type)
        {
            if (data == null)
            {
                return null;
            }

            switch (type)
            {
                case ObjectType.Boolean:
                    {
                        if (data.Length > 0)
                        {
                            return data[0] == 0x00 ? false : true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case ObjectType.Byte:
                    {
                        if (data.Length > 0)
                        {
                            return data[0];
                        }
                        else
                        {
                            return (byte)0x00;
                        }
                    }
                case ObjectType.Char: return BitConverter.ToChar(data,0);
                case ObjectType.Double: return BitConverter.ToDouble(data, 0);
                case ObjectType.Single: return BitConverter.ToSingle(data, 0);
                case ObjectType.Int32: return BitConverter.ToInt32(data, 0);
                case ObjectType.UInt32: return BitConverter.ToUInt32(data, 0);
                case ObjectType.Int64: return BitConverter.ToInt64(data, 0);
                case ObjectType.UInt64: return BitConverter.ToUInt64(data, 0);
                case ObjectType.Int16: return BitConverter.ToInt16(data, 0);
                case ObjectType.UInt16: return BitConverter.ToUInt16(data, 0);
                case ObjectType.Data: return data;
                case ObjectType.DateTime: return DateTime.FromBinary(BitConverter.ToInt64(data,0));
                case ObjectType.String: return Encoding.UTF8.GetString(data);
            }
            return null;
        }
        protected byte[] ObjectToByteArray()
        {
            switch (Type)
            {
                case ObjectType.Boolean: return ((bool)Value) ? new byte[] { 0x01 } : new byte[] { 0x00 };
                case ObjectType.Byte: return new byte[] { (byte)Value };
                case ObjectType.Char: return new byte[] { Convert.ToByte((char)Value) };
                case ObjectType.Double: return BitConverter.GetBytes((double)Value);
                case ObjectType.Single: return BitConverter.GetBytes((float)Value);
                case ObjectType.Int32: return BitConverter.GetBytes((int)Value);
                case ObjectType.UInt32: return BitConverter.GetBytes((uint)Value);
                case ObjectType.Int64: return BitConverter.GetBytes((long)Value);
                case ObjectType.UInt64: return BitConverter.GetBytes((ulong)Value);
                case ObjectType.Int16: return BitConverter.GetBytes((short)Value);
                case ObjectType.UInt16: return BitConverter.GetBytes((ushort)Value);
                case ObjectType.Data: return (byte[])Value;
                case ObjectType.DateTime: return BitConverter.GetBytes(((DateTime)Value).ToBinary());
                case ObjectType.String: return Encoding.UTF8.GetBytes((string)Value);
            }
            return null;
        }
        public ObjectType GetObjectType()
        {
            if (Value == null)
            {
                return ObjectType.None;
            }

            if (Value is bool)
            {
                return ObjectType.Boolean;
            }

            if (Value is byte)
            {
                return ObjectType.Byte;
            }

            if (Value is char)
            {
                return ObjectType.Char;
            }

            if (Value is double)
            {
                return ObjectType.Double;
            }

            if (Value is float)
            {
                return ObjectType.Single;
            }

            if (Value is int)
            {
                return ObjectType.Int32;
            }

            if (Value is uint)
            {
                return ObjectType.UInt32;
            }

            if (Value is long)
            {
                return ObjectType.Int64;
            }

            if (Value is ulong)
            {
                return ObjectType.UInt64;
            }

            if (Value is short)
            {
                return ObjectType.Int16;
            }

            if (Value is ushort)
            {
                return ObjectType.UInt16;
            }

            if (Value is byte[])
            {
                return ObjectType.Data;
            }

            if (Value is DateTime)
            {
                return ObjectType.DateTime;
            }

            if (Value is string)
            {
                return ObjectType.String;
            }
            else
            {
                return ObjectType.None;
            }
        }
        public enum ObjectType
        {
            None = 0x01,
            Boolean = 0x02,
            Byte = 0x03,
            String = 0x04,
            Char = 0x05,
            Double = 0x06,
            Single = 0x07,
            Int32 = 0x08,
            UInt32 = 0x09,
            Int64 = 0x0a,
            UInt64 = 0x0b,
            Int16 = 0x0c,
            UInt16 = 0x0d,
            Data = 0x0e,
            DateTime = 0x0f
        }
    }
}