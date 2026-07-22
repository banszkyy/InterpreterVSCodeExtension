using System;

namespace LanguageCore.SyntaxGenerator;

readonly struct Name : IEquatable<Name>
{
    public string Identifier { get; }

    public Name(string identifier) => Identifier = identifier;
    public Name(Name parent, string identifier) => Identifier = $"{parent.Identifier}.{identifier}";

    public Name this[string v] => new(this, v);

    public override string ToString() => Identifier;
    public override bool Equals(object? obj) => obj is Name name && Identifier == name.Identifier;
    public bool Equals(Name other) => Identifier == other.Identifier;
    public override int GetHashCode() => Identifier.GetHashCode();

    public static bool operator ==(Name a, Name b) => a.Equals(b);
    public static bool operator !=(Name a, Name b) => !a.Equals(b);

    public static implicit operator string(Name v) => v.Identifier;

    public static readonly Name Comment = new("comment");
    public static readonly Name CommentBlock = Comment["block"];
    public static readonly Name CommentBlockDocumentation = CommentBlock["documentation"];
    public static readonly Name CommentLine = Comment["line"];
    public static readonly Name CommentLineDoubleDash = CommentLine["double-dash"];
    public static readonly Name CommentLineDoubleSlash = CommentLine["double-slash"];
    public static readonly Name CommentLineNumberSign = CommentLine["number-sign"];
    public static readonly Name CommentLinePercentage = CommentLine["percentage"];
    public static readonly Name Constant = new("constant");
    public static readonly Name ConstantCharacter = Constant["character"];
    public static readonly Name ConstantCharacterEscape = ConstantCharacter["escape"];
    public static readonly Name ConstantLanguage = Constant["language"];
    public static readonly Name ConstantNumeric = Constant["numeric"];
    public static readonly Name ConstantOther = Constant["other"];
    public static readonly Name ConstantRegexp = Constant["regexp"];
    public static readonly Name ConstantRgbValue = Constant["rgb-value"];
    public static readonly Name Emphasis = new("emphasis");
    public static readonly Name Entity = new("entity");
    public static readonly Name EntityName = Entity["name"];
    public static readonly Name EntityNameClass = EntityName["class"];
    public static readonly Name EntityNameFunction = EntityName["function"];
    public static readonly Name EntityNameMethod = EntityName["method"];
    public static readonly Name EntityNameSection = EntityName["section"];
    public static readonly Name EntityNameSelector = EntityName["selector"];
    public static readonly Name EntityNameTag = EntityName["tag"];
    public static readonly Name EntityNameType = EntityName["type"];
    public static readonly Name EntityNameVariable = EntityName["variable"];
    public static readonly Name EntityOther = Entity["other"];
    public static readonly Name EntityOtherAttributeName = EntityOther["attribute-name"];
    public static readonly Name EntityOtherInheritedClass = EntityOther["inherited-class"];
    public static readonly Name Header = new("header");
    public static readonly Name Invalid = new("invalid");
    public static readonly Name InvalidDeprecated = Invalid["deprecated"];
    public static readonly Name InvalidIllegal = Invalid["illegal"];
    public static readonly Name Keyword = new("keyword");
    public static readonly Name KeywordControl = Keyword["control"];
    public static readonly Name KeywordControlLess = KeywordControl["less"];
    public static readonly Name KeywordOperator = Keyword["operator"];
    public static readonly Name KeywordOperatorNew = KeywordOperator["new"];
    public static readonly Name KeywordOther = Keyword["other"];
    public static readonly Name KeywordOtherUnit = KeywordOther["unit"];
    public static readonly Name Markup = new("markup");
    public static readonly Name MarkupBold = Markup["bold"];
    public static readonly Name MarkupChanged = Markup["changed"];
    public static readonly Name MarkupDeleted = Markup["deleted"];
    public static readonly Name MarkupHeading = Markup["heading"];
    public static readonly Name MarkupInlineRaw = Markup["inline.raw"];
    public static readonly Name MarkupInserted = Markup["inserted"];
    public static readonly Name MarkupItalic = Markup["italic"];
    public static readonly Name MarkupList = Markup["list"];
    public static readonly Name MarkupListNumbered = MarkupList["numbered"];
    public static readonly Name MarkupListNnnumbered = MarkupList["unnumbered"];
    public static readonly Name MarkupOther = Markup["other"];
    public static readonly Name MarkupPunctuationListBeginning = Markup["punctuation"]["list"]["beginning"];
    public static readonly Name MarkupPunctuationQuoteBeginning = Markup["punctuation"]["quote"]["beginning"];
    public static readonly Name MarkupQuote = Markup["quote"];
    public static readonly Name MarkupRaw = Markup["raw"];
    public static readonly Name MarkupUnderline = Markup["underline"];
    public static readonly Name MarkupUnderlineLink = MarkupUnderline["link"];
    public static readonly Name Meta = new("meta");
    public static readonly Name MetaCast = Meta["cast"];
    public static readonly Name MetaParameterTypeVariable = Meta["parameter"]["type"]["variable"];
    public static readonly Name MetaPreprocessor = Meta["preprocessor"];
    public static readonly Name MetaPreprocessorNumeric = MetaPreprocessor["numeric"];
    public static readonly Name MetaPreprocessorString = MetaPreprocessor["string"];
    public static readonly Name MetaReturnType = Meta["return-type"];
    public static readonly Name MetaSelector = Meta["selector"];
    public static readonly Name MetaTag = Meta["tag"];
    public static readonly Name MetaTypeAnnotation = Meta["type"]["annotation"];
    public static readonly Name MetaTypeName = Meta["type"]["name"];
    public static readonly Name Storage = new("storage");
    public static readonly Name StorageModifier = Storage["modifier"];
    public static readonly Name StorageType = Storage["type"];
    public static readonly Name String = new("string");
    public static readonly Name StringInterpolated = String["interpolated"];
    public static readonly Name StringOther = String["other"];
    public static readonly Name StringQuoted = String["quoted"];
    public static readonly Name StringQuotedDouble = StringQuoted["double"];
    public static readonly Name StringQuotedOther = StringQuoted["other"];
    public static readonly Name StringQuotedSingle = StringQuoted["single"];
    public static readonly Name StringQuotedTriple = StringQuoted["triple"];
    public static readonly Name StringRegexp = String["regexp"];
    public static readonly Name StringUnquoted = String["unquoted"];
    public static readonly Name Strong = new("strong");
    public static readonly Name Support = new("support");
    public static readonly Name SupportClass = Support["class"];
    public static readonly Name SupportConstant = Support["constant"];
    public static readonly Name SupportFunction = Support["function"];
    public static readonly Name SupportOther = Support["other"];
    public static readonly Name SupportType = Support["type"];
    public static readonly Name SupportVariable = Support["variable"];
    public static readonly Name Variable = new("variable");
    public static readonly Name VariableLanguage = Variable["language"];
    public static readonly Name VariableName = Variable["name"];
    public static readonly Name VariableOther = Variable["other"];
    public static readonly Name VariableParameter = Variable["parameter"];
    public static readonly Name Punctuation = new("punctuation");
}
