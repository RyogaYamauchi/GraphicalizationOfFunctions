namespace GraphicalizationOfFunctions.Cli;
using CommandLine;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Options
{
    [Value(0, MetaName = "path", Required = true, HelpText = "File path to analyze.")]
    public string? Path { get; set; }

    [Option('t', "target", HelpText = "Fully qualified method name to analyze.")]
    public string? Target { get; set; }
}
