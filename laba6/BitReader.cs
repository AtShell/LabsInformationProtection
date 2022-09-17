using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsInformationProtection.laba6
{
    internal class BitReader : IDisposable
    {
        BufferedStream s = null;
        MemoryStream ms = null;

        bool disposed = false;
        byte? b = null;
        int pos = 0;

        public BitOrder bitOrder = BitOrder.LeftToRight;
        public bool EndOfStream;

        public BitReader(BufferedStream _s)
        {
            s = _s;
        }

        public BitReader(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;

            s = new BufferedStream(ms);
        }


        public bool? ReadBit()
        {
            bool? result = null;

            try
            {
                if (b == null || (pos % 8 == 0))
                {
                    int i = s.ReadByte();

                    if (i == -1)
                    {
                        throw new EndOfStreamException();
                    }
                    else
                    {
                        b = Convert.ToByte(i);
                    }

                    pos = 0;
                }

                if (bitOrder == BitOrder.LeftToRight)
                {
                    result = Convert.ToBoolean(b & (1 << (7 - pos)));
                }
                else if (bitOrder == BitOrder.RightToLeft)
                {
                    result = Convert.ToBoolean((b >> pos) % 2);
                }

                pos++;

                return result;
            }
            catch (EndOfStreamException)
            {
                EndOfStream = true;

                return null;
            }
        }

        public bool?[] ReadBits(int n)
        {
            bool?[] bits = new bool?[n];

            for (int i = 0; i < n; i++)
            {
                bool? bit = ReadBit();
                bits[i] = bit;
            }

            return bits;
        }

        public bool[] ReadAll()
        {
            List<bool> bits = new List<bool>();
            bool? bit = null;
            while ((bit = ReadBit()) != null)
            {
                bits.Add(bit.Value);
            }

            return bits.ToArray();
        }

        public long Position
        {
            get
            {
                return ((s.Position - 1) * 8) + (pos - 1);
            }
        }

        public long Length
        {
            get
            {
                return s.Length * 8;
            }
        }
        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // Dispose managed resources
                if (disposing)
                {
                    if (this.s != null)
                    {
                        s.Close();
                    }

                    if (this.ms != null)
                    {
                        ms.Close();
                    }
                }

                // Dispose unmanaged resources
                disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion

        public enum BitOrder
        {
            LeftToRight = 0,
            RightToLeft = 1
        }
    }

}
