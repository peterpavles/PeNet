﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PeNet.Structures;

namespace PeNet.Utilities
{
    /// <summary>
    /// Extensions method to work make the work with buffers 
    /// and addresses easier.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        ///     Convert to bytes to an 16 bit unsigned integer.
        /// </summary>
        /// <param name="b1">High byte.</param>
        /// <param name="b2">Low byte.</param>
        /// <returns>UInt16 of the input bytes.</returns>
        private static ushort BytesToUInt16(byte b1, byte b2)
        {
            return BitConverter.ToUInt16(new[] {b1, b2}, 0);
        }

        /// <summary>
        ///     Convert a two bytes in a byte array to an 16 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Position of the high byte. Low byte is i+1.</param>
        /// <returns>UInt16 of the bytes in the buffer at position i and i+1.</returns>
        public static ushort BytesToUInt16(this byte[] buff, ulong offset)
        {
            return BytesToUInt16(buff[offset], buff[offset + 1]);
        }

        /// <summary>
        ///     Convert up to 2 bytes out of a buffer to an 16 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <param name="numOfBytes">Number of bytes to read.</param>
        /// <returns>UInt16 of numOfBytes bytes.</returns>
        public static uint BytesToUInt16(this byte[] buff, uint offset, uint numOfBytes)
        {
            var bytes = new byte[2];
            for (var i = 0; i < numOfBytes; i++)
                bytes[i] = buff[offset + i];

            return BitConverter.ToUInt16(bytes, 0);
        }

        /// <summary>
        ///     Convert 4 bytes to an 32 bit unsigned integer.
        /// </summary>
        /// <param name="b1">Highest byte.</param>
        /// <param name="b2">Second highest byte.</param>
        /// <param name="b3">Second lowest byte.</param>
        /// <param name="b4">Lowest byte.</param>
        /// <returns>UInt32 representation of the input bytes.</returns>
        private static uint BytesToUInt32(byte b1, byte b2, byte b3, byte b4)
        {
            return BitConverter.ToUInt32(new[] {b1, b2, b3, b4}, 0);
        }

        /// <summary>
        ///     Convert 4 consecutive bytes out of a buffer to an 32 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <returns>UInt32 of 4 bytes.</returns>
        public static uint BytesToUInt32(this byte[] buff, uint offset)
        {
            return BytesToUInt32(buff[offset], buff[offset + 1], buff[offset + 2], buff[offset + 3]);
        }

        /// <summary>
        ///     Convert 4 bytes to an 32 bit signed integer.
        /// </summary>
        /// <param name="b1">Highest byte.</param>
        /// <param name="b2">Second highest byte.</param>
        /// <param name="b3">Second lowest byte.</param>
        /// <param name="b4">Lowest byte.</param>
        /// <returns>UInt32 representation of the input bytes.</returns>
        private static int BytesToInt32(byte b1, byte b2, byte b3, byte b4)
        {
            return BitConverter.ToInt32(new[] {b1, b2, b3, b4}, 0);
        }

        /// <summary>
        ///     Convert 4 consecutive bytes out of a buffer to an 32 bit signed integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <returns>UInt32 of 4 bytes.</returns>
        public static int BytesToInt32(this byte[] buff, uint offset)
        {
            return BytesToInt32(buff[offset], buff[offset + 1], buff[offset + 2], buff[offset + 3]);
        }

        /// <summary>
        ///     Converts 8 bytes to an 64 bit unsigned integer.
        /// </summary>
        /// <param name="b1">Highest byte.</param>
        /// <param name="b2">Second byte.</param>
        /// <param name="b3">Third byte.</param>
        /// <param name="b4">Fourth byte.</param>
        /// <param name="b5">Fifth byte.</param>
        /// <param name="b6">Sixth byte.</param>
        /// <param name="b7">Seventh byte.</param>
        /// <param name="b8">Lowest byte.</param>
        /// <returns>UInt64 of the input bytes.</returns>
        private static ulong BytesToUInt64(byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7, byte b8)
        {
            return BitConverter.ToUInt64(new[] {b1, b2, b3, b4, b5, b6, b7, b8}, 0);
        }

        /// <summary>
        ///     Convert 8 consecutive byte in a buffer to an
        ///     64 bit unsigned integer.
        /// </summary>
        /// <param name="buff">Byte buffer.</param>
        /// <param name="offset">Offset of the highest byte.</param>
        /// <returns>UInt64 of the byte sequence at offset i.</returns>
        public static ulong BytesToUInt64(this byte[] buff, ulong offset)
        {
            return BytesToUInt64(buff[offset], buff[offset + 1], buff[offset + 2], 
                buff[offset + 3], buff[offset + 4], buff[offset + 5], buff[offset + 6],
                buff[offset + 7]);
        }

        /// <summary>
        ///     Convert an UIn16 to an byte array.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Two byte array of the input value.</returns>
        private static byte[] UInt16ToBytes(ushort value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        ///     Set an UInt16 value at an offset in an byte array.
        /// </summary>
        /// <param name="buff">Buffer in which the value is set.</param>
        /// <param name="offset">Offset where the value is set.</param>
        /// <param name="value">The value to set.</param>
        public static void SetUInt16(this byte[] buff, ulong offset, ushort value)
        {
            var x = UInt16ToBytes(value);
            buff[offset] = x[0];
            buff[offset + 1] = x[1];
        }

        /// <summary>
        ///     Convert an UInt32 value into an byte array.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>4 byte array of the value.</returns>
        private static byte[] UInt32ToBytes(uint value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        ///     Convert an UIn64 value into an byte array.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>8 byte array of the value.</returns>
        private static byte[] UInt64ToBytes(ulong value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        ///     Sets an UInt32 value at an offset in a buffer.
        /// </summary>
        /// <param name="buff">Buffer to set the value in.</param>
        /// <param name="offset">Offset in the array for the value.</param>
        /// <param name="value">Value to set.</param>
        public static void SetUInt32(this byte[] buff, uint offset, uint value)
        {
            var x = UInt32ToBytes(value);
            buff[offset] = x[0];
            buff[offset + 1] = x[1];
            buff[offset + 2] = x[2];
            buff[offset + 3] = x[3];
        }

        /// <summary>
        ///     Sets an UInt64 value at an offset in a buffer.
        /// </summary>
        /// <param name="buff">Buffer to set the value in.</param>
        /// <param name="offset">Offset in the array for the value.</param>
        /// <param name="value">Value to set.</param>
        public static void SetUInt64(this byte[] buff, ulong offset, ulong value)
        {
            var x = UInt64ToBytes(value);
            buff[offset] = x[0];
            buff[offset + 1] = x[1];
            buff[offset + 2] = x[2];
            buff[offset + 3] = x[3];
            buff[offset + 4] = x[4];
            buff[offset + 5] = x[5];
            buff[offset + 6] = x[6];
            buff[offset + 7] = x[7];
        }

        /// <summary>
        ///     Map an virtual address to the raw file address.
        /// </summary>
        /// <param name="virtualAddress">Virtual Address</param>
        /// <param name="sh">Section Headers</param>
        /// <returns>Raw file address.</returns>
        public static ulong VAtoFileMapping(this ulong virtualAddress, ICollection<IMAGE_SECTION_HEADER> sh)
        {
            var rva= virtualAddress - sh.FirstOrDefault().ImageBaseAddress;
            return RVAtoFileMapping(rva, sh);
        }

        /// <summary>
        ///     Map an relative virtual address to the raw file address.
        /// </summary>
        /// <param name="relativeVirtualAddress">Relative Virtual Address</param>
        /// <param name="sh">Section Headers</param>
        /// <returns>Raw file address.</returns>
        public static ulong RVAtoFileMapping(this ulong relativeVirtualAddress, ICollection<IMAGE_SECTION_HEADER> sh)
        {
            IMAGE_SECTION_HEADER GetSectionForRva(ulong rva)
            {
                var sectionsByRva = sh.OrderBy(s => s.VirtualAddress).ToList();
                var notLastSection = sectionsByRva.FirstOrDefault(s =>
                    rva >= s.VirtualAddress && rva < s.VirtualAddress + s.VirtualSize);

                if (notLastSection != null)
                    return notLastSection;

                var lastSection = sectionsByRva.LastOrDefault(s => 
                        rva >= s.VirtualAddress && rva <= s.VirtualAddress + s.VirtualSize);

                return lastSection;
            }

            var section = GetSectionForRva(relativeVirtualAddress);

            if (section is null)
            {
                throw new Exception("Cannot find corresponding section.");
            }

            return relativeVirtualAddress - section.VirtualAddress + section.PointerToRawData;
        }

        /// <summary>
        ///     Map an relative virtual address to the raw file address.
        /// </summary>
        /// <param name="relativeVirtualAddress">Relative Virtual Address</param>
        /// <param name="sh">Section Headers</param>
        /// <returns>Raw file address.</returns>
        public static uint RVAtoFileMapping(this uint relativeVirtualAddress, ICollection<IMAGE_SECTION_HEADER> sh)
        {
            return (uint) RVAtoFileMapping((ulong) relativeVirtualAddress, sh);
        }

        /// <summary>
        ///     Map an relative virtual address to the raw file address.
        /// </summary>
        /// <param name="RelativeVirtualAddress">Relative Virtual Address</param>
        /// <param name="sh">Section Headers</param>
        /// <returns>Raw address of null if error occurred.</returns>
        public static uint? SafeRVAtoFileMapping(this uint RelativeVirtualAddress, ICollection<IMAGE_SECTION_HEADER> sh)
        {
            try
            {
                return RelativeVirtualAddress.RVAtoFileMapping(sh);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     Convert a sequence of bytes into a hexadecimal string.
        /// </summary>
        /// <param name="bytes">Byte sequence.</param>
        /// <returns>Hex-String</returns>
        public static string ToHexString(this ICollection<byte> bytes)
        {
            if (bytes == null) return null;

            var hex = new StringBuilder(bytes.Count*2);
            foreach (var b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return $"0x{hex}";
        }

        /// <summary>
        ///     Convert a sequence of ushorts into a hexadecimal string.
        /// </summary>
        /// <param name="values">Value sequence.</param>
        /// <returns>Hex-String</returns>
        public static string ToHexString(this ICollection<ushort> values)
        {
            if (values == null) return null;

            var hex = new StringBuilder(values.Count*2);
            foreach (var b in values)
                hex.AppendFormat("{0:X4}", b);
            return $"0x{hex}";
        }


        /// <summary>
        ///     Convert byte into a hexadecimal string.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Hex-String</returns>
        public static string ToHexString(this byte value)
        {
            return $"0x{value:X2}";
        }

        /// <summary>
        ///     Convert ushort into a hexadecimal string.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Hex-String</returns>
        public static string ToHexString(this ushort value)
        {
            return $"0x{value:X4}";
        }

        /// <summary>
        ///     Convert uint into a hexadecimal string.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Hex-String</returns>
        public static string ToHexString(this uint value)
        {
            return $"0x{value:X8}";
        }

        /// <summary>
        ///     Convert ulong into a hexadecimal string.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Hex-String</returns>
        public static string ToHexString(this ulong value)
        {
            return $"0x{value:X16}";
        }

        /// <summary>
        ///     Convert a sub array of an byte array to an hex string where
        ///     every byte is separated by an whitespace.
        /// </summary>
        /// <param name="input">Byte array.</param>
        /// <param name="from">Index in the byte array where the hex string starts.</param>
        /// <param name="length">Length of the hex string in the byte array.</param>
        /// <returns></returns>
        public static List<string> ToHexString(this byte[] input, ulong from, ulong length)
        {
            if (input == null) return null;

            var hexList = new List<string>();
            for (var i = @from; i < @from + length; i++)
            {
                hexList.Add(input[i].ToString("X2"));
            }
            return hexList;
        }

        /// <summary>
        ///     Converts a hex string of the form 0x435A4DE3 to a long value.
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns>The hex string value as a long.</returns>
        public static long ToIntFromHexString(this string hexString)
        {
            return (long) new Int64Converter().ConvertFromString(hexString);
        }

        internal static ushort GetOrdinal(this byte[] buff, uint ordinal)
        {
            return BitConverter.ToUInt16(new[] {buff[ordinal], buff[ordinal + 1]}, 0);
        }

        /// <summary>
        ///     Get a name (C string) at a specific position in a buffer.
        /// </summary>
        /// <param name="buff">Containing buffer.</param>
        /// <param name="stringOffset">Offset of the string.</param>
        /// <returns>The parsed C string.</returns>
        public static string GetCString(this byte[] buff, ulong stringOffset)
        {
            var length = GetCStringLength(buff, stringOffset);
            var tmp = new char[length];
            for (ulong i = 0; i < length; i++)
            {
                tmp[i] = (char) buff[stringOffset + i];
            }

            return new string(tmp);
        }

        /// <summary>
        ///     For a given offset in an byte array, find the next
        ///     null value which terminates a C string.
        /// </summary>
        /// <param name="buff">Buffer which contains the string.</param>
        /// <param name="stringOffset">Offset of the string.</param>
        /// <returns>Length of the string in bytes.</returns>
        public static ulong GetCStringLength(this byte[] buff, ulong stringOffset)
        {
            var offset = stringOffset;
            ulong length = 0;
            while (buff[offset] != 0x00)
            {
                length++;
                offset++;
            }
            return length;
        }

        /// <summary>
        ///     Get a unicode string at a specific position in a buffer.
        /// </summary>
        /// <param name="buff">Containing buffer.</param>
        /// <param name="stringOffset">Offset of the string.</param>
        /// <returns>The parsed unicode string.</returns>
        public static string GetUnicodeString(this byte[] buff, ulong stringOffset)
        {
            var size = 0;
            for (var i = 0; i < (buff.Length - (int) stringOffset) - 1; i++)
            {
                if (buff[(int) stringOffset + i] == 0 && buff[(int) stringOffset + (i + 1)] == 0)
                {
                    size = i + 1;
                    break;
                }
            }

            var bytes = new byte[size];

            Array.Copy(buff, (int)stringOffset, bytes, 0, size);
            return Encoding.Unicode.GetString(bytes);
        }


        /// <summary>
        /// Get the length of a unicode string in bytes.
        /// </summary>
        /// <param name="s">A unicode string.</param>
        /// <returns>Length in bytes.</returns>
        public static int LengthInByte(this string s) => s.Length * 2 + 2;

        /// <summary>
        /// Computes the number of bits needed by an MetaData Table index 
        /// based on the number of fields which the enum of the index has.
        /// </summary>
        /// <param name="indexEnum">MetaData tables index.</param>
        /// <returns>Size if index in bits.</returns>
        public static uint MetaDataTableIndexSize(this Type indexEnum)
        {
            var numOfTags = Enum.GetNames(indexEnum).Length;
            return (uint) Math.Ceiling(Math.Log(numOfTags, 2));
        }

        /// <summary>
        /// Compute the padding to align a
        /// data structure.
        /// </summary>
        /// <param name="offset">Offset to start the alignment of
        /// the next member.</param>
        /// <param name="alignment">Bitness of the alignment, e.g. "32".</param>
        /// <returns>Number of bytes needed to align the next structure.</returns>
        public static uint PaddingBytes(this long offset, int alignment) => (uint) offset % (uint) (alignment / 8);

        /// <summary>
        /// Compute the padding to align a
        /// data structure.
        /// </summary>
        /// <param name="offset">Offset to start the alignment of
        /// the next member.</param>
        /// <param name="alignment">Bitness of the alignment, e.g. "32".</param>
        /// <returns>Number of bytes needed to align the next structure.</returns>
        public static uint PaddingBytes(this uint offset, int alignment) => (uint)offset % (uint)(alignment / 8);
    }
}