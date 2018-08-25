﻿using System.IO;
using System.Web;

namespace EpamWeb
{
    public class EpamFormatHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            response.Write("<html><body>" +
                           "<h1>Epam format handler. Such format is not supported </h1>" +
                           "<div  style=\"background-color:lightgreen\">");
            foreach (string i in request.Headers.Keys)
            {
                response.Write($"<div>{i}: {request.Headers[i]} </div>");
            }

            response.Write("</br>");
            try
            {
                response.Write(ReadFile(request.PhysicalApplicationPath + request.FilePath));
            }
            catch (FileNotFoundException)
            {
                response.Write($"FILE WITH NAME {request.PhysicalApplicationPath + request.FilePath} NOT FOUND");
            }
            response.Write("</div>");
            response.Write("</body></html>");
        }

        public string ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int) fileStream.Length; // get file length
                buffer = new byte[length]; // create buffer
                int count; // actual number of bytes read
                int sum = 0; // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count; // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }

            return System.Text.Encoding.UTF8.GetString(buffer);
        }

        public bool IsReusable => false;
    }
}