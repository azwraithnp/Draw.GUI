using Draw.GUI;
using Draw.GUIMVP.Models;
using Draw.GUIMVP.Views;
using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUIMVP.Presenters
{
    class CodingPresenter
    {
        ICodeView codeView;
        UserInfo user;

        public CodingPresenter(ICodeView codeView)
        {
            this.codeView = codeView;
            user = new UserInfo();      //TODO user json implementation
            

        }

        public void setViewProperties()
        {
            if(user.Theme.Equals("light"))
            {
                IThematicListView lightList = new LightListView(codeView.ListView);
                lightList.setupHandlers();
                codeView.ListView = lightList.ListView;

                codeView.backColor = Colors.themeLightColor;

                IThematicMenuStrip lightStrip = new LightMenuStrip(codeView.MenuStrip);
                lightStrip.setupMenuStrip();
                codeView.MenuStrip = lightStrip.MenuStrip;

                codeView.HighlightMode = "draw.gui.light";
            }
            else
            {
                IThematicListView darkList = new DarkListView(codeView.ListView);
                darkList.setupHandlers();
                codeView.ListView = darkList.ListView;

                codeView.backColor = Colors.themeDarkColor;

                IThematicMenuStrip darkStrip = new DarkMenuStrip(codeView.MenuStrip);
                darkStrip.setupMenuStrip();
                codeView.MenuStrip = darkStrip.MenuStrip;

                codeView.HighlightMode = "draw.gui.dark";
            }
        }
        

        public void highlightHandlers()
        {
            //Creates a FileSyntaxModeProvider object to provide binary for the color syntaxing
            FileSyntaxModeProvider fsmp;

            //Provide directory path for fsmp object
            string dirc = Application.StartupPath;

            //Checks if the provided directory path exists
            if (Directory.Exists(dirc))
            {
                //Initialize the fsmp object with the provided directory path
                fsmp = new FileSyntaxModeProvider(dirc);

                /*Pass the fsmp object created as argument for the sytanxmodefileprovider 
                 * of highlightingmanager of the texteditor */
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
            }
        }
    }
}
