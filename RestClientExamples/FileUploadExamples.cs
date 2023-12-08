using CEA.RestClient;
using CEA.RestClient.ApiModels;
using System;
using System.IO;

namespace RestClientExamples
{
    public class FileUploadExamples
    {
        // Example: Upload a CSV file with contacts
        // to make its content available for further operations.
        public static void UploadFile()
        {
            var client = new StagingRestClient();

            try
            {
                // if you already have the user's authorization token, you can use it, like this:
                // client.SetAccessToken("pass in the token here");

                // or prompt the user for their Text-Em-All username/password
                client.SetAccessTokenByPromptingForLogin();

                // enter the full path for the file
                // (no spaces in the path)
                Console.Write($"Please enter the file name to upload: ");
                var fileName = Console.ReadLine();

                var fileContent = File.ReadAllBytes(fileName);

                // upload file content
                var result = client.PostStream<FileUpload>("/v1/fileuploads", "csv", fileContent);

                Console.WriteLine($"Uploaded file ID: {result.FileID}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"There was an error: {exception}");
            }

            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
