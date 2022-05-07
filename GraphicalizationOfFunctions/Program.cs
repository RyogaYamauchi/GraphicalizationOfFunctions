using GraphicalizationOfFunctions.Cli;

using CommandLine;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
Parser.Default.ParseArguments<Options>(args).WithParsed(Process);

static void Process(Options options)
{
    Console.WriteLine("StartProcess!!");
    var program = GetProgramRoot(options.Path);
    var methods = GetMethods(program);
    foreach(var method in methods)
    {
        var syntax = (MethodDeclarationSyntax)method;
        Console.WriteLine(syntax.Identifier.Text);
    }

}

static CompilationUnitSyntax GetProgramRoot(string path)
{
    using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
    using var reader = new StreamReader(fs);
    var program = reader.ReadToEnd();
    var tree = CSharpSyntaxTree.ParseText(program);
    var root = tree.GetCompilationUnitRoot();

    return root;
}

static IEnumerable<BaseMethodDeclarationSyntax> GetMethods(SyntaxNode node)
{
    switch (node)
    {
        case CompilationUnitSyntax root:
            foreach (var method in root.Members.SelectMany(GetMethods))
            {
                yield return method;
            }

            break;
        case NamespaceDeclarationSyntax @namespace:
            foreach (var method in @namespace.Members.SelectMany(GetMethods))
            {
                yield return method;
            }

            break;
        case FileScopedNamespaceDeclarationSyntax fileScopeNamespace:
            foreach (var method in fileScopeNamespace.Members.SelectMany(GetMethods))
            {
                yield return method;
            }

            break;
        case TypeDeclarationSyntax type:
            foreach (var method in type.Members.SelectMany(GetMethods))
            {
                yield return method;
            }

            break;
        case BaseMethodDeclarationSyntax method:
            yield return method;
            break;
        default:
            break;
    }
}
