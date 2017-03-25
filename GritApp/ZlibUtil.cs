using System;
using System.IO;
using System.IO.Compression;

public static class ZlibUtil
{
    public static void Deflate(string sourceFile, string destinationFile)
    {
        var sourceInfo = new FileInfo(sourceFile);
        using (var sourceFileStream = sourceInfo.OpenRead())
        {
            using (var destinationFileStream = File.Create(destinationFile))
            {
                using (var deflateStream = new DeflateStream(destinationFileStream, CompressionMode.Compress))
                {
                    sourceFileStream.CopyTo(deflateStream);
                }
            }
        }
    }

    public static void Inflate(string sourceFile, string destinationFile)
    {
        var sourceInfo = new FileInfo(sourceFile);
        using (var sourceFileStream = sourceInfo.OpenRead())
        {
            using (var destinationFileStream = File.Create(destinationFile))
            {
                using (var deflateStream = new DeflateStream(sourceFileStream, CompressionMode.Decompress))
                {
                    deflateStream.CopyTo(destinationFileStream);
                }
            }
        }
    }
}