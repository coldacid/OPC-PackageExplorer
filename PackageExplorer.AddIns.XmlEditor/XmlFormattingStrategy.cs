using System;
using ICSharpCode.TextEditor.Document;
using System.Collections.Generic;
using System.Text;

namespace PackageExplorer.AddIns.XmlEditor
{
    class XmlFormattingStrategy
        : IFormattingStrategy
    {
        public int FormatLine(ICSharpCode.TextEditor.TextArea textArea, int line, 
            int caretOffset, char charTyped)
        {
            return 0;
        }

        public int IndentLine(ICSharpCode.TextEditor.TextArea textArea, int line)
        {
            // get indentation of prior line, 
            // 
            int indentation = line > 0 ? GetIndentation(textArea, line - 1) : 0;
            string lineText = TextUtilities.GetLineAsString(textArea.Document, line);
            if (indentation > 0)
            {
                lineText = new string('\t', indentation) + lineText;
            }
            LineSegment lineSegment = textArea.Document.GetLineSegment(line);
            textArea.Document.Replace(lineSegment.Offset, lineSegment.Length, lineText);
            return lineText.Length;
        }

        int GetIndentation(ICSharpCode.TextEditor.TextArea textArea, int line)
        {
            // assume line is well formatted
            int indentation = 0;
            string lineText = TextUtilities.GetLineAsString(textArea.Document, line);
            if (String.IsNullOrEmpty(lineText) == false)
            {
                for (int i = 0; i < lineText.Length; i++)
                {
                    if (Char.IsWhiteSpace(lineText[i]))
                    {
                        indentation++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return indentation;
        }

        public void IndentLines(ICSharpCode.TextEditor.TextArea textArea, int begin, int end)
        {
            int lineCount = end - begin + 1;

            for (int i = begin; i < end; i++)
            {
                int splitCount = SplitLine(textArea, i);
                if (splitCount > 1)
                {
                    lineCount += splitCount - 1;
                }
            }
            for (int i = begin; i < begin + lineCount; i++)
            {
                IndentLine(textArea, i);
            }
        }

        private int SplitLine(ICSharpCode.TextEditor.TextArea textArea, int line)
        {
            string text = TextUtilities.GetLineAsString(textArea.Document, line);
            StringBuilder splitStrings = new StringBuilder();
            int lines = 0;
            StringBuilder builder = new StringBuilder();
            int firstNonWhiteChar = -1;
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsWhiteSpace(text[i]) == false)
                {
                    firstNonWhiteChar = i;
                    break;
                }
            }
            if (firstNonWhiteChar != -1)
            {
                int currentIndex = firstNonWhiteChar;
                do
                {
                    if (text[currentIndex] == '<')
                    {
                        if (builder.Length != 0)
                        {
                            builder.Append(Environment.NewLine);
                            splitStrings.Append(builder.ToString());
                            lines++;
                            builder = new StringBuilder();
                        }
                        builder.Append(text[currentIndex]);
                    }
                    else if (text[currentIndex] == '>')
                    {
                        builder.Append(text[currentIndex]);
                        builder.Append(Environment.NewLine);
                        splitStrings.Append(builder.ToString());
                        lines++;
                        builder = new StringBuilder();
                    }
                    else
                    {
                        builder.Append(text[currentIndex]);
                    }
                    currentIndex++;
                } while (currentIndex < text.Length);
                if (lines > 1)
                {
                    LineSegment segment = textArea.Document.GetLineSegment(line);
                    textArea.Document.Replace(segment.Offset, segment.Length,
                        splitStrings.ToString());
                }
            }
            return lines;
        }
        
        public int SearchBracketBackward(IDocument document, int offset, char openBracket, char closingBracket)
        {
            return 0;
        }

        public int SearchBracketForward(IDocument document, int offset, char openBracket, char closingBracket)
        {
            return 0;
        }
    }
}
