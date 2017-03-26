using System;
using System.Security.Cryptography;

public static class Sha1Util
{
    public static byte[] ComputeHash(byte[] data)
    {
        var provider = new SHA1CryptoServiceProvider();
        return provider.ComputeHash(data);
    }
}