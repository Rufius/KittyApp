using KittyApp.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KittyApp.Services
{
    public class KittyService : IKittyService
    {
        private HttpClient httpClient = new HttpClient();
        public async Task<byte[]> FlipKittyImage(string imageUrl)
        {
            if (imageUrl == null || string.IsNullOrWhiteSpace(imageUrl))
                throw new Exception("The url for cat images has not been specified");

            return await GetAndTransformImage(imageUrl, RotateFlipType.RotateNoneFlipY);
        }

        public async Task<byte[]> RotateKittyImageWithText(string imageUrl, string text)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                throw new Exception("The url for the cat image has not been specified");

            if (string.IsNullOrWhiteSpace(text))
                throw new Exception("The text for the image has not been specified");

            string url = string.Concat(imageUrl, "//", text.Trim());

            return await GetAndTransformImage(url, RotateFlipType.Rotate90FlipNone);
        }

        private async Task<byte[]> GetAndTransformImage(string imageUrl, RotateFlipType rotateFlipType)
        {
            var requestStream = await httpClient.GetStreamAsync(imageUrl);

            var img = new Bitmap(requestStream);
            img.RotateFlip(rotateFlipType);

            var responseStream = new MemoryStream();
            img.Save(responseStream, ImageFormat.Jpeg);

            return responseStream.ToArray();
        }
    }
}
