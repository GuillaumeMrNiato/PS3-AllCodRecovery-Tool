using System.Collections.Generic;
public static class FunctionsBO2
{
    public static byte[] Multiply(this byte[] A, byte[] B)
    {
        List<byte> ans = new List<byte>();

        byte ov, res;
        int idx = 0;
        for (int i = 0; i < A.Length; i++)
        {
            ov = 0;
            for (int j = 0; j < B.Length; j++)
            {
                short result = (short)(A[i] * B[j] + ov);
                ov = (byte)(result >> 8);
                res = (byte)result;
                idx = i + j;
                if (idx < (ans.Count))
                    ans = _add_(ans, res, idx);
                else ans.Add(res);
            }
            if (ov > 0)
                if (idx + 1 < (ans.Count))
                    ans = _add_(ans, ov, idx + 1);
                else ans.Add(ov);
        }

        return ans.ToArray();
    }
    private static List<byte> _add_(List<byte> A, byte b, int idx = 0, byte rem = 0)
    {
        short sample = 0;
        if (idx < A.Count)
        {
            sample = (short)((short)A[idx] + (short)b);
            A[idx] = (byte)(sample % 256);
            rem = (byte)((sample - A[idx]) % 255);
            if (rem > 0)
                return _add_(A, (byte)rem, idx + 1);
        }
        else A.Add(b);

        return A;
    }
}