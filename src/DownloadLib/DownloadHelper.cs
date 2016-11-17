using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DownloadLib
{
    public class DownloadHelper
    {
        private string[] _uris;
        private string _destination;

        private HttpClient _client;

        public DownloadHelper(string[] uris, string destination)
        {
            _uris = uris;
            _client = new HttpClient();
            DownloadAllWebContent();
        }

        //public async Task<StreamContent> ReadContentsWithProgress(string url)
        //{
        //    // Your original code.
        //    HttpClientHandler aHandler = new HttpClientHandler();
        //    aHandler.ClientCertificateOptions = ClientCertificateOption.Automatic;
        //    HttpClient aClient = new HttpClient(aHandler);
        //    aClient.DefaultRequestHeaders.ExpectContinue = false;
        //    HttpResponseMessage response = await aClient.GetAsync(
        //        url,
        //        HttpCompletionOption.ResponseHeadersRead); // Important! ResponseHeadersRead.

        //    // To save downloaded image to local storage
        //    var imageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(
        //        filename,
        //        CreationCollisionOption.ReplaceExisting);
        //    var fs = await imageFile.OpenAsync(FileAccessMode.ReadWrite);

        //    // New code.
        //    Stream stream = await response.Content.ReadAsStreamAsync();
        //    IInputStream inputStream = stream.AsInputStream();
        //    ulong totalBytesRead = 0;
        //    while (true)
        //    {
        //        // Read from the web.
        //        IBuffer buffer = new Windows.Storage.Streams.Buffer(1024);
        //        buffer = await inputStream.ReadAsync(
        //            buffer,
        //            buffer.Capacity,
        //            InputStreamOptions.None);

        //        if (buffer.Length == 0)
        //        {
        //            // There is nothing else to read.
        //            break;
        //        }

        //        // Report progress.
        //        totalBytesRead += buffer.Length;
        //        System.Diagnostics.Debug.WriteLine("Bytes read: {0}", totalBytesRead);

        //        // Write to file.
        //        await fs.WriteAsync(buffer);
        //    }
        //    inputStream.Dispose();
        //    fs.Dispose();
        //}
        

        public async Task<SavedPageInfo> DownloadWebContent(string uri)
        {
            //var content = await _client.GetStringAsync(uri);
            //return await Task.Run(() => new SavedPageInfo()
            //{
            //});

            var response = await _client.GetAsync(uri);

            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();
            byte[] bytesArray = await response.Content.ReadAsByteArrayAsync();
            FileManager.SaveContent(bytesArray, FileManager.GetCurrentFolderPath() + "//" + FileManager.EncodeUriToFileSystemName(uri));
            //string content = System.Text.Encoding.Unicode.GetString(bytesArray);
            return await Task.Run(() => new SavedPageInfo()
            {
                Uri = uri,
                //Content = content,
                BytesLength = bytesArray.LongCount(),
                DestinationToSave = "null",

            });

        }

        public async void DownloadAllWebContent()
        {
            foreach (var uri in _uris)
            {
                SavedPageInfo pageInfo = await DownloadWebContent(uri);
            };
        }
    }

    public struct SavedPageInfo
    {
        public string Uri;
        public string DestinationToSave;
        public long BytesLength;
        public string Content;
        public DateTime DownloadStarted;
        public DateTime DownloadFinished;
    }
}
