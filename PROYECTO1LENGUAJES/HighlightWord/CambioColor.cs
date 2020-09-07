using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;

namespace PROYECTO1LENGUAJES.HighlightWord
{
    class CambioColor
    {
        private TextPointer textPointer;
        public CambioColor()
        {
           
        }
        public void HighlightWordInRichTextBox(TextRange textRange, System.Windows.Controls.RichTextBox richBox)
        {
            SolidColorBrush col2 = new SolidColorBrush();
            col2.Color = Color.FromArgb(255, 255, 255, 255);
            SolidColorBrush col = new SolidColorBrush();
            col.Color = Color.FromArgb(255, 0, 0, 255);

            int var = textRange.Text.Length;
            Console.WriteLine(var);
            textPointer = richBox.CaretPosition.GetPositionAtOffset(-10);
            Console.WriteLine(textPointer);

            TextRange tr = FindWordFromPosition(textPointer, "entero");

            if (!object.Equals(tr, null))
            {
                //set the pointer to the end of "word"
                textPointer = tr.End;

                //apply highlight color
                tr.ApplyPropertyValue(TextElement.ForegroundProperty, col);
            }

            TextRange tr2 = FindWordFromPosition(textPointer, " ");
            if (!object.Equals(tr2, null))
            {
                //set the pointer to the end of "word"
                textPointer = tr2.End;

                //apply highlight color
                tr2.ApplyPropertyValue(TextElement.ForegroundProperty, col2);
            }
        }
        private TextRange FindWordFromPosition(TextPointer position, string word)
        {
            while (position != null)
            {
                if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    string textRun = position.GetTextInRun(LogicalDirection.Forward);

                    // Find the starting index of any substring that matches "word".
                    int indexInRun = textRun.IndexOf(word);
                    if (indexInRun >= 0)
                    {
                        TextPointer start = position.GetPositionAtOffset(indexInRun);
                        TextPointer end = start.GetPositionAtOffset(word.Length);
                        return new TextRange(start, end);
                    }
                }
                position = position.GetNextContextPosition(LogicalDirection.Forward);
            }

            // position will be null if "word" is not found.
            return null;
        }
    }
}
