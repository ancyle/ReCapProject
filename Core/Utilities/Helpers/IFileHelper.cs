using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        Task<IResult> Upload(IFormFile file,string path);
        void Delete(string filePath);
        IResult Update(IFormFile file,  string original, string root);
    }
}