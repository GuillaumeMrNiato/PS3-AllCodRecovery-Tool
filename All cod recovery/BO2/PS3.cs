using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PS3Lib;

class PS3BO2
{
    static PS3API PS3 = new PS3API(SelectAPI.ControlConsole);
    public class Func
    {
        public static void SetByte(uint offset, byte Value)
        {
            PS3.SetMemory(offset, new byte[] { Value });
            PS3.TMAPI.SetMemory(offset, new byte[] { Value });
            PS3.CCAPI.SetMemory(offset, new byte[] { Value });
        }
        public static void SetUInt32(uint offset, uint Value, bool Reverse = false)
        {
            if (!Reverse)
            {
                PS3.SetMemory(offset, BitConverter.GetBytes(Value).Reverse<byte>().ToArray<byte>());
                PS3.TMAPI.SetMemory(offset, BitConverter.GetBytes(Value).Reverse<byte>().ToArray<byte>());
                PS3.CCAPI.SetMemory(offset, BitConverter.GetBytes(Value).Reverse<byte>().ToArray<byte>());
            }
            else
            {
                PS3.SetMemory(offset, BitConverter.GetBytes(Value));
                PS3.TMAPI.SetMemory(offset, BitConverter.GetBytes(Value));
                PS3.CCAPI.SetMemory(offset, BitConverter.GetBytes(Value));
            }
        } 
    }
}

