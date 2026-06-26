using System.Collections.Generic;

namespace LanguageCore.SyntaxGenerator;

static class BBLangTestResult
{
    public static SyntaxFile Generate()
    {
        Dictionary<string, Pattern> repository = [];

        repository["escaped"] = new Pattern()
        {
            Match = "(\\.)",
            Captures = new()
            {
                { 1, SyntaxToken.ConstantCharacterEscape },
            }
        };

        repository["hash"] = new Pattern()
        {
            Patterns = [
                new()
                {
                    Match = @"(#exitcode)\s+(-?\d+)\n",
                    Captures = new()
                    {
                        { 1, SyntaxToken.Keyword },
                        { 2, SyntaxToken.ConstantNumeric },
                    },
                },
                new()
                {
                    Match = @"(#exposed)\s+(\w+)(.*)\n",
                    Captures = new()
                    {
                        { 1, SyntaxToken.Keyword },
                        { 2, SyntaxToken.StringUnquoted },
                        { 3,
                        new Match()
                        {
                            Patterns = [
                                new Pattern()
                                {
                                    Match = @"(=>)",
                                    Captures = new()
                                    {
                                        { 1, SyntaxToken.Punctuation },
                                    },
                                },
                                new Pattern()
                                {
                                    Match = @"(i8|i16|i32)(:)(-?\d+)",
                                    Captures = new()
                                    {
                                        { 1, SyntaxToken.EntityNameType },
                                        { 2, SyntaxToken.Punctuation },
                                        { 3, SyntaxToken.ConstantNumeric },
                                    },
                                },
                                new Pattern()
                                {
                                    Match = @"(f32)(:)(-?(\d+(\.\d+)?))",
                                    Captures = new()
                                    {
                                        { 1, SyntaxToken.EntityNameType },
                                        { 2, SyntaxToken.Punctuation },
                                        { 3, SyntaxToken.ConstantNumeric },
                                    },
                                },
                            ]
                        } },
                    },
                },
                new()
                {
                    Match = "(#.*)\n",
                    Captures = new()
                    {
                        { 1, SyntaxToken.Invalid },
                    },
                },
            ],
        };

        return new SyntaxFile()
        {
            Schema = "https://raw.githubusercontent.com/martinring/tmlanguage/master/tmlanguage.json",
            Name = "BBLang Test Result Language",
            FileTypes = ["bblang-test-result"],
            ScopeName = "source.result",
            Repository = repository,
            Patterns = [
                new() { Include = "#escaped" },
                new() { Include = "#hash" },
            ]
        };
    }
}
