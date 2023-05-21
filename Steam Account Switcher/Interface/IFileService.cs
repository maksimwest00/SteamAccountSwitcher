using System.Collections.Generic;

namespace Steam_Account_Switcher
{
    public interface IFileService
    {
        T Read<T>(string filename);
        void Save<T>(string filename, T accounts);
    }
}
