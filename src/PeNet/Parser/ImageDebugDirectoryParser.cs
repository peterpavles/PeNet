﻿using PeNet.Structures;

namespace PeNet.Parser
{
    internal class ImageDebugDirectoryParser : SafeParser<IMAGE_DEBUG_DIRECTORY[]>
    {
        private readonly uint _size;

        internal ImageDebugDirectoryParser(byte[] buff, uint offset, uint size)
            : base(buff, offset)
        {
            this._size = size;
        }

        protected override IMAGE_DEBUG_DIRECTORY[] ParseTarget()
        {
            var numEntries = _size / 28; // Debug entry is 28 bytes
            var entries = new IMAGE_DEBUG_DIRECTORY[numEntries];

            for(uint i = 0; i < numEntries; i++)
            {
                entries[i] = new IMAGE_DEBUG_DIRECTORY(Buff, Offset + (i * 28));
            }

            return entries;
        }
    }
}