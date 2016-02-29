﻿/***********************************************************************
Copyright 2016 Stefan Hausotte

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

*************************************************************************/

using System.Text;

namespace PeNet.Structures
{
    /// <summary>
    ///     The export directory contains all exported function, symbols etc.
    ///     which can be used by other module.
    /// </summary>
    public class IMAGE_EXPORT_DIRECTORY
    {
        private readonly byte[] _buff;
        private readonly uint _offset;

        /// <summary>
        ///     Create a new IMAGE_EXPORT_DIRECTORY object.
        /// </summary>
        /// <param name="buff">PE file as a byte array.</param>
        /// <param name="offset">Raw offset of the export directory in the PE file.</param>
        public IMAGE_EXPORT_DIRECTORY(byte[] buff, uint offset)
        {
            _offset = offset;
            _buff = buff;
        }

        /// <summary>
        ///     The characterisitcs of the export directory.
        /// </summary>
        public uint Characteristics
        {
            get { return Utility.BytesToUInt32(_buff, _offset); }
            set { Utility.SetUInt32(value, _offset, _buff); }
        }

        /// <summary>
        ///     Time and date stamp.
        /// </summary>
        public uint TimeDateStamp
        {
            get { return Utility.BytesToUInt32(_buff, _offset + 0x4); }
            set { Utility.SetUInt32(value, _offset + 0x4, _buff); }
        }

        /// <summary>
        ///     Major Version.
        /// </summary>
        public ushort MajorVersion
        {
            get { return Utility.BytesToUInt16(_buff, _offset + 0x8); }
            set { Utility.SetUInt16(value, _offset + 0x8, _buff); }
        }

        /// <summary>
        ///     Minor Version.
        /// </summary>
        public ushort MinorVersion
        {
            get { return Utility.BytesToUInt16(_buff, _offset + 0xA); }
            set { Utility.SetUInt16(value, _offset + 0xA, _buff); }
        }

        /// <summary>
        ///     Name.
        /// </summary>
        public uint Name
        {
            get { return Utility.BytesToUInt32(_buff, _offset + 0xC); }
            set { Utility.SetUInt32(value, _offset + 0xC, _buff); }
        }

        /// <summary>
        ///     Base.
        /// </summary>
        public uint Base
        {
            get { return Utility.BytesToUInt32(_buff, _offset + 0x10); }
            set { Utility.SetUInt32(value, _offset + 0x10, _buff); }
        }

        /// <summary>
        ///     Number of exported functions.
        /// </summary>
        public uint NumberOfFunctions
        {
            get { return Utility.BytesToUInt32(_buff, _offset + 0x14); }
            set { Utility.SetUInt32(value, _offset + 0x14, _buff); }
        }

        /// <summary>
        ///     Number of exported names.
        /// </summary>
        public uint NumberOfNames
        {
            get { return Utility.BytesToUInt32(_buff, _offset + 0x18); }
            set { Utility.SetUInt32(value, _offset + 0x18, _buff); }
        }

        /// <summary>
        ///     RVA to the addresses of the functions.
        /// </summary>
        public uint AddressOfFunctions
        {
            get { return Utility.BytesToUInt32(_buff, _offset + 0x1C); }
            set { Utility.SetUInt32(value, _offset + 0x1C, _buff); }
        }

        /// <summary>
        ///     RVA to the addresses of the names.
        /// </summary>
        public uint AddressOfNames
        {
            get { return Utility.BytesToUInt32(_buff, _offset + 0x20); }
            set { Utility.SetUInt32(value, _offset + 0x20, _buff); }
        }

        /// <summary>
        ///     RVA to the name ordinals.
        /// </summary>
        public uint AddressOfNameOrdinals
        {
            get { return Utility.BytesToUInt32(_buff, _offset + 0x24); }
            set { Utility.SetUInt32(value, _offset + 0x24, _buff); }
        }

        /// <summary>
        ///     Creates a string representation of all object
        ///     properties.
        /// </summary>
        /// <returns>The export directory properties as a string.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder("IMAGE_EXPORT_DIRECTORY\n");
            sb.Append(Utility.PropertiesToString(this, "{0,-15}:\t{1,10:X}\n"));

            return sb.ToString();
        }
    }
}