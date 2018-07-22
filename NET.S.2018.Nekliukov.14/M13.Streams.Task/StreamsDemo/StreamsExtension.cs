using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        /// <summary>
        /// Bies the byte copy.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>The number of written bytes</returns>
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            long bytesRead;
            byte[] sourceBytes;

            using(FileStream sourceStream = File.OpenRead(sourcePath))
            {
                sourceBytes = new byte[sourceStream.Length];
                sourceStream.Read(sourceBytes, 0, sourceBytes.Length);
            }

            using(FileStream destStream = File.OpenWrite(destinationPath))
            {
                for (int i = 0; i < sourceBytes.Length; i++)
                {
                    destStream.WriteByte(sourceBytes[i]);
                }

                bytesRead = destStream.Length;
            }

            return (int)bytesRead;
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            string sourceData;
            using (StreamReader streamReader = new StreamReader(sourcePath))
            {
                sourceData = streamReader.ReadToEnd();
            }

            byte[] sourceBytes = Encoding.UTF8.GetBytes(sourceData);
            MemoryStream memStream = new MemoryStream();
            int srcBytesLen = sourceBytes.Length;
            memStream.Read(sourceBytes, 0, srcBytesLen);
            byte[] destinationBytes = new byte[srcBytesLen];
            memStream.Write(destinationBytes, 0, srcBytesLen);
            char[] charArray = Encoding.UTF8.GetChars(destinationBytes);

            using(StreamWriter streamWriter = new StreamWriter(destinationPath))
            {
                for(int i = 0; i < charArray.Length; i++)
                {
                    streamWriter.Write(charArray[i]);
                }
            }

            return charArray.Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            // TODO: Use InMemoryByByteCopy method's approach
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        /// <summary>
        /// Inputs the validation.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <exception cref="System.ArgumentNullException">Null path value was sent
        /// </exception>
        /// <exception cref="System.ArgumentException">File is not found
        /// </exception>
        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (sourcePath == null)
            {
                throw new ArgumentNullException($"Null path value was sent");
            }

            if (destinationPath == null)
            {
                throw new ArgumentNullException($"Null path value was sent");
            }

            //if (!File.Exists(sourcePath))
            //{
            //    throw new ArgumentException($"File {sourcePath} is not found");
            //}

            //if (!File.Exists(destinationPath))
            //{
            //    throw new ArgumentException($"File {destinationPath} is not found");
            //}
        }

        #endregion

        #endregion

    }
}
