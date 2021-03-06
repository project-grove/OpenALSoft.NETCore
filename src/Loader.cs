using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NativeLibraryLoader;
using static System.Runtime.InteropServices.RuntimeInformation;

namespace OpenAL.Internal
{
    internal static class Loader
    {
        static NativeLibrary _openAl;

        internal static NativeLibrary OpenAL {
            get {
                if (_openAl == null) {
                    _openAl = LoadOpenAL();
                }
                return _openAl;
            }
        }

        static NativeLibrary LoadOpenAL()
        {
            string[] names = null;
            if (IsOSPlatform(OSPlatform.Windows)) {
                names = new [] {
                    "openal32.dll",
                    "soft_oal.dll"
                };
            } else if (IsOSPlatform(OSPlatform.OSX)) {
                names = new [] { "libopenal.dylib", "openal.dylib" };
            } else {
                names = new [] { 
                    "libopenal.so",
                    "libopenal.so.1"
                };
            }
            return new NativeLibrary(names);
        }
    }
}
