using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraphicalizationOfFunctions
{
    internal class NewWalker : CSharpSyntaxWalker
    {
        public override void Visit(SyntaxNode? node)
        {
            Console.WriteLine(node);
            Console.WriteLine("--------------------------------");
            base.Visit(node);
        }
    }
}
