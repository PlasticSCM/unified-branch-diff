using System;
using System.Diagnostics;
using Codice.CmdRunner;
using System.IO;

namespace unifiedbranchdiff
{
    class Program
    {
        static string PATCH_COMMAND = "cm patch {0} --output={1}";
        static string USE_TOOL = " --tool={0}";

        static void Main(string[] args)
        {
            string wkspath = args[0];
            string branchSpec = args[1];
            string editor = args[2];

            string outputfile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".patch");

            if (File.Exists(outputfile))
                File.Delete(outputfile);

            string cmPathCommand = string.Format(PATCH_COMMAND, branchSpec, outputfile);

            if (args.Length == 4)
                cmPathCommand += string.Format(USE_TOOL, args[3]);

            CmdRunner.ExecuteCommand(cmPathCommand, wkspath);
            ExecuteEditor(editor, outputfile);
        }

        static void ExecuteEditor(string editor, string file)
        {
            Process process = new Process();
            process.StartInfo.FileName = editor;
            process.StartInfo.Arguments = file;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }
    }
}
