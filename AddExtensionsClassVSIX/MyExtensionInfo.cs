using Microsoft.VisualStudio.Shell;
using System.Windows.Controls;

namespace AddNewItem_Template.Shared
{
    public class MyExtensionInfo
    {
        public static string itemName = "Extensions class";

        public static string checkboxText = "Create with extension method";

        public static string GenerateFileText(string sourceFolder, string solutionDir, string newFileName, ref CheckBox checkBox)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            string namespacePath = sourceFolder.Replace(solutionDir, "").Replace("\\", ".").Replace(" ", "_").TrimStart('.').TrimEnd('.');

            string className = newFileName.Replace(".cs", "").Replace(" ", "_");

            string objClassName = className.TrimEnd("Extensions", true).TrimEnd("Extension", true);
            string objName = objClassName.FirstCharToLowerCase();
            string extensionMethod = (!checkBox.IsChecked()) ? "\n\t\t\n" :
                $"\n\t\tpublic static void Extension(this {objClassName} {objName})\n" +
                "\t\t{\n" +
                "\t\t\t\n" +
                "\t\t}\n";

            string txt =
                "using System;\n" +
                "using System.IO;\n" +
                "using System.Linq;\n" +
                "using System.Collections.Generic;\n" +
                "\n" +
                $"namespace {namespacePath}\n" +
                "{\n" +
                $"\tpublic static class {className}" +
                "\n\t{" +
                $"{extensionMethod}" +
                "\t}\n" +
                "}";

            return txt;
        }
    }
}
