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

using PeNet.Structures;
using Xunit;

namespace PeNet.Test.Structures
{
    
    public class IMAGE_RESOURCE_DATA_ENTRY_Test
    {
        [Fact]
        public void ImageResourceDataEntryConstructorWorks_Test()
        {
            var resourceDataEntry = new IMAGE_RESOURCE_DATA_ENTRY(RawStructures.RawResourceDataEntry, 2);

            Assert.Equal((uint) 0x33221100, resourceDataEntry.OffsetToData);
            Assert.Equal((uint) 0x77665544, resourceDataEntry.Size1);
            Assert.Equal(0xbbaa9988, resourceDataEntry.CodePage);
            Assert.Equal(0xffeeddcc, resourceDataEntry.Reserved);
        }
    }
}