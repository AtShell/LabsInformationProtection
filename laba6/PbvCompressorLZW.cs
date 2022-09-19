using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsInformationProtection.laba6
{
    public class PbvCompressorLZW : ICompressorAlgorithm
    {
        private const int MAX_BITS = 14;
        private const int HASH_BIT = MAX_BITS - 8; 
        private const int MAX_VALUE = (1 << MAX_BITS) - 1; 
        private const int MAX_CODE = MAX_VALUE - 1;
        private const int TABLE_SIZE = 18041; 

        private int[] _iaCodeTable = new int[TABLE_SIZE];
        private int[] _iaPrefixTable = new int[TABLE_SIZE];
        private int[] _iaCharTable = new int[TABLE_SIZE];

        private ulong _iBitBuffer; 
        private int _iBitCounter; 

        private void Initialize()
        {
            _iBitBuffer = 0;
            _iBitCounter = 0;
        }

        public bool Compress(string pInputFileName, string pOutputFileName)
        {
            Stream reader = null;
            Stream writer = null;

            try
            {
                Initialize();
                reader = new FileStream(pInputFileName, FileMode.Open);
                writer = new FileStream(pOutputFileName, FileMode.Create);
                int iNextCode = 256;
                int iChar = 0, iString = 0, iIndex = 0;

                for (int i = 0; i < TABLE_SIZE; i++)
                    _iaCodeTable[i] = -1;

                iString = reader.ReadByte();

                while ((iChar = reader.ReadByte()) != -1)
                {
                    iIndex = FindMatch(iString, iChar);

                    if (_iaCodeTable[iIndex] != -1)
                        iString = _iaCodeTable[iIndex];
                    else 
                    {
                        if (iNextCode <= MAX_CODE) 
                        {
                            _iaCodeTable[iIndex] = iNextCode++;
                            _iaPrefixTable[iIndex] = iString;
                            _iaCharTable[iIndex] = (byte)iChar;
                        }

                        WriteCode(writer, iString);
                        iString = iChar;
                    }
                }

                WriteCode(writer, iString);
                WriteCode(writer, MAX_VALUE);
                WriteCode(writer, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                if (writer != null)
                    writer.Close();
                File.Delete(pOutputFileName);
                return false;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (writer != null)
                    writer.Close();
            }

            return true;
        }

        private int FindMatch(int pPrefix, int pChar)
        {
            int index = 0, offset = 0;

            index = (pChar << HASH_BIT) ^ pPrefix;

            offset = (index == 0) ? 1 : TABLE_SIZE - index;

            while (true)
            {
                if (_iaCodeTable[index] == -1)
                    return index;

                if (_iaPrefixTable[index] == pPrefix && _iaCharTable[index] == pChar)
                    return index;

                index -= offset;
                if (index < 0)
                    index += TABLE_SIZE;
            }
        }

        private void WriteCode(Stream pWriter, int pCode)
        {
            _iBitBuffer |= (ulong)pCode << (32 - MAX_BITS - _iBitCounter);
            _iBitCounter += MAX_BITS;

            while (_iBitCounter >= 8)
            {
                int temp = (byte)((_iBitBuffer >> 24) & 255);
                pWriter.WriteByte((byte)((_iBitBuffer >> 24) & 255));
                _iBitBuffer <<= 8;
                _iBitCounter -= 8;
            }
        }

        public bool Decompress(string pInputFileName, string pOutputFileName)
        {
            Stream reader = null;
            Stream writer = null;

            try
            {
                Initialize();
                reader = new FileStream(pInputFileName, FileMode.Open);
                writer = new FileStream(pOutputFileName, FileMode.Create);
                int iNextCode = 256;
                int iNewCode, iOldCode;
                byte bChar;
                int iCurrentCode, iCounter;
                byte[] baDecodeStack = new byte[TABLE_SIZE];

                iOldCode = ReadCode(reader);
                bChar = (byte)iOldCode;
                writer.WriteByte((byte)iOldCode);

                iNewCode = ReadCode(reader);

                while (iNewCode != MAX_VALUE) 
                {
                    if (iNewCode >= iNextCode)
                    { 
                        baDecodeStack[0] = bChar;
                        iCounter = 1;
                        iCurrentCode = iOldCode;
                    }
                    else
                    {
                        iCounter = 0;
                        iCurrentCode = iNewCode;
                    }

                    while (iCurrentCode > 255) 
                    {

                        baDecodeStack[iCounter] = (byte)_iaCharTable[iCurrentCode];
                        ++iCounter;
                        if (iCounter >= MAX_CODE)
                            throw new Exception("oh crap");
                        iCurrentCode = _iaPrefixTable[iCurrentCode];
                    }

                    baDecodeStack[iCounter] = (byte)iCurrentCode;
                    bChar = baDecodeStack[iCounter];

                    while (iCounter >= 0) 
                    {
                        writer.WriteByte(baDecodeStack[iCounter]);
                        --iCounter;
                    }

                    if (iNextCode <= MAX_CODE)
                    {
                        _iaPrefixTable[iNextCode] = iOldCode;
                        _iaCharTable[iNextCode] = bChar;
                        ++iNextCode;
                    }

                    iOldCode = iNewCode;

                    iNewCode = ReadCode(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                if (writer != null)
                    writer.Close();
                File.Delete(pOutputFileName);
                return false;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (writer != null)
                    writer.Close();
            }

            return true;
        }

        private int ReadCode(Stream pReader)
        {
            uint iReturnVal;

            while (_iBitCounter <= 24)
            {
                _iBitBuffer |= (ulong)pReader.ReadByte() << (24 - _iBitCounter);
                _iBitCounter += 8;
            }

            iReturnVal = (uint)_iBitBuffer >> (32 - MAX_BITS);
            _iBitBuffer <<= MAX_BITS;
            _iBitCounter -= MAX_BITS;

            int temp = (int)iReturnVal;
            return temp;
        }
    }
}
