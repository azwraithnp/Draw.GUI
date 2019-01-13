using Microsoft.VisualStudio.TestTools.UnitTesting;
using Draw.GUI;
using System;
using System.Collections.Generic;
using ICSharpCode.TextEditor.Document;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Draw.GUI.Tests
{
    /// <summary>
    /// creates a test class for coding form 
    /// </summary>
    [TestClass()]
    public class CodingFormTests
    {
        List<TextMarker> markers = new List<TextMarker>();
        
        /// <summary>
        /// creates a test method to check whether adding to the text marker array is working properly
        /// </summary>
        [TestMethod()]
        public void errorHighlightingTest()
        {
            markers.Clear();

            GeneratedLists.errorMessages.Add(new InvalidSyntaxErrorMessage(0, "num", "Untitled", 0, "num"));

            foreach (ErrorMessage error in GeneratedLists.errorMessages)
            {
                int offset = error.index;
                int length = error.word.Length;
                TextMarker marker = new TextMarker(offset, length, TextMarkerType.WaveLine, Color.Red);
                
                markers.Add(marker);
            }

            Assert.AreEqual(GeneratedLists.errorMessages.Count, markers.Count);
        }
    }
}