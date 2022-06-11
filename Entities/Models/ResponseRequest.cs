using System.Collections.ObjectModel;
using System.Net;
using Extensions;

namespace Entities.Models;

public class ResponseRequest<T> where T : class
{
    public bool Response { get; set; }

    public string Message { get; set; }

    public HttpStatusCode Code { get; set; }

    public int RecordsCount => Content?.Count() ?? 0;

    public ICollection<T>? Content { get; set; }

    public ResponseRequest(bool response, string message, HttpStatusCode code, ICollection<T> content)
    {
        Response = response;
        Message = message;
        Code = code;
        Content = content;
    }

    public ResponseRequest(bool response, string message, HttpStatusCode code)
    {
        Response = response;
        Message = message;
        Code = code;
    }

    public ResponseRequest(ICollection<T> content)
    {
        Content = content;
        if (content.IsEmpty())
        {
            Code = HttpStatusCode.NotFound;
            Response = false;
            Message = "Not found.";
        }
        else
        {
            Code = HttpStatusCode.OK;
            Response = true;
            Message = Response.ToString();
        }
    }

    public ResponseRequest(T content)
    {
        Content = new Collection<T>();
        Content.Add(content);
        Code = HttpStatusCode.OK;
        Response = true;
        Message = Response.ToString();
    }
}