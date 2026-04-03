using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace LanguageCore.SyntaxGenerator;

static class Program
{
    static string? _projectPath;
    public static string ProjectPath => _projectPath ??= GetProjectPath();
    static string GetProjectPath([CallerFilePath] string? callerFilePath = null) => Path.GetDirectoryName(callerFilePath ?? throw new Exception($"Failed to get the project path"))!;

    static void Main()
    {
        File.WriteAllText(Path.Combine(GetProjectPath(), "..", "syntax", "bblang.json"), JsonSerializer.Serialize(BBLang.Generate(), Converter.JsonOptions));
        File.WriteAllText(Path.Combine(GetProjectPath(), "..", "syntax", "msil.json"), JsonSerializer.Serialize(MSIL.Generate(), Converter.JsonOptions));
        File.WriteAllText(Path.Combine(GetProjectPath(), "..", "syntax", "bblang-il.json"), JsonSerializer.Serialize(BBLangIL.Generate(), Converter.JsonOptions));
        File.WriteAllText(Path.Combine(GetProjectPath(), "..", "syntax", "bblang-test-result.json"), JsonSerializer.Serialize(BBLangTestResult.Generate(), Converter.JsonOptions));
    }
}
