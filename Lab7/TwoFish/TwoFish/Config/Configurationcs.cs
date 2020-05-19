using System;
using System.Collections.Generic;

using HOP.Config.API;

namespace HOP.Config
{
    class Configuration : IConfiguration
    {
        // todo: Don't use a file - make it built in to the application
        public string GetTokenFilePath()
        {
            return @"e:\HOP\DropBox.Token";
        }

        public string GetKeyFilePath()
        {
            return @"e:\HOP\EncryptionTest\TwoFish.Key";
        }
    }
}