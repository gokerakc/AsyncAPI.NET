using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LEGO.AsyncAPI.E2E.Tests.readers.samples.AsyncApi;

public class ShouldConsumeProduceBase<T>
{
    protected IInternalAsyncApiWriter<T> _asyncApiWriter;
    protected IInternalAsyncApiReader<T> _asyncApiAsyncApiReader;
    private readonly string _SampleFolderPath;

    protected ShouldConsumeProduceBase(Type child)
    {
        _SampleFolderPath = GetPath(child);
        _asyncApiAsyncApiReader = new InternalJsonAsyncApiReader<T>();
        _asyncApiWriter = new InternalJsonAsyncApiWriter<T>();
    }

    protected Stream? GetStream(string filename)
    {
        return GenerateStreamFromString(GetString(filename));
    }
    
    protected Stream? GetStreamWithMockedExtensions(string filename)
    {
        return GenerateStreamFromString(GetStringWithMockedExtensions(filename));
    }

    protected string GetString(string filename)
    {
        return ReadFile(_SampleFolderPath, filename);
    }

    protected string GetStringWithMockedExtensions(string filename)
    {
        var body = GetString(filename);
        var extensionsBody = ReadFile("LEGO/AsyncAPI/E2E/Tests/readers/samples/AsyncApi", "MockExtensions.json");
        return new StringBuilder(body.Substring(0, body.Length - 2)).AppendLine(",").AppendLine(extensionsBody).Append("}").ToString();
    }

    private string ReadFile(string sampleFolderPath, string filename)
    {
        var combine = Path.Combine(sampleFolderPath, filename).Replace("/", ".").Replace("\\",".");
        Stream? stream = GetType().Assembly.GetManifestResourceStream(combine);
        if (stream == null)
        {
            throw new FileNotFoundException("The stream is null because the file was not found");
        }

        return new StreamReader(stream).ReadToEnd();
    }

    private static string GetPath(Type child)
    {
        var split = Regex.Split(child.FullName, "(.*?)\\.Should.*?");
        return split[1];
    }
    
    protected static Stream GenerateStreamFromString(string s)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
}