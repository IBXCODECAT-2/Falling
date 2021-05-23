using System.Collections;
using System.Collections.Generic;

public class IBXON : FileSystem
{
    public struct Dictionaries
    {
        public static Dictionary<string, bool> ibxonBool = new Dictionary<string, bool>();
        public static Dictionary<string, byte> ibxonByte = new Dictionary<string, byte>();
        public static Dictionary<string, short> ibxonShort = new Dictionary<string, short>();
        public static Dictionary<string, int> ibxonInt = new Dictionary<string, int>();
        public static Dictionary<string, long> ibxonLong = new Dictionary<string, long>();
        public static Dictionary<string, char> ibxonChar = new Dictionary<string, char>();
        public static Dictionary<string, string> ibxonString = new Dictionary<string, string>();
    }

    public static bool KeyExists(string key)
    {
        foreach (KeyValuePair<string, bool> pair in Dictionaries.ibxonBool) { if (pair.Key == key) { return true; } }
        foreach (KeyValuePair<string, byte> pair in Dictionaries.ibxonByte) { if(pair.Key == key) { return true; } }
        foreach (KeyValuePair<string, short> pair in Dictionaries.ibxonShort) { if (pair.Key == key) { return true; } }
        foreach (KeyValuePair<string, int> pair in Dictionaries.ibxonInt) { if (pair.Key == key) { return true; } }
        foreach (KeyValuePair<string, long> pair in Dictionaries.ibxonLong) { if (pair.Key == key) { return true; } }
        foreach (KeyValuePair<string, char> pair in Dictionaries.ibxonChar) { if (pair.Key == key) { return true; } }
        foreach (KeyValuePair<string, string> pair in Dictionaries.ibxonString) { if (pair.Key == key) { return true; } }

        return false;
    }

    public override void WriteRaw(string data, string relPath)
    {

        base.WriteRaw(data, relPath);
    }
}
