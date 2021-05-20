using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class WebFile : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath)) File.Delete(filePath);
        }

        public IResult Update(IFormFile file, string original, string root)
        {
            if (File.Exists(original)) File.Delete(original);
            var result = Upload(file, root);
            return result.IsCompletedSuccessfully ? new SuccessResult(result.Result.Message) : null;
        }

        public async Task<IResult> Upload(IFormFile file, string root)
        {
            if (!Directory.Exists(root)) Directory.CreateDirectory(root);
            try
            {
                var path = file.FileName;
                if (file.FileName.Length < 0) throw new NoNullAllowedException();

                var extension = Path.GetExtension(file.FileName);
                var guid = Guid.NewGuid().ToString();
                var newPath = Path.Combine(root, (guid + extension));

                await using var fstream = File.Create(path);

                await file.CopyToAsync(fstream);
                fstream.Flush(true);
                fstream.Close();

                System.IO.File.Copy(fstream.Name, newPath);
                File.Delete(fstream.Name);
                return new SuccessResult(newPath);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}