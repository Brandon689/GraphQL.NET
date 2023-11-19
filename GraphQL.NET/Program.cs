using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;

public class Program
{
    public static async Task Main(string[] args)
    {
        var schema = Schema.For(@"
      type Query {
        hello: String
      }
    ");

        var json = await schema.ExecuteAsync(_ =>
        {
            _.Query = "{ hello }";
            _.Root = new { Hello = "Hello World!" };
        });

        Console.WriteLine(json);
    }
}