using System;
using System.Linq;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static IEnumerable<Result> Scala()
        {
            List<Result> results = new List<Result>();
            if (EnableScala)
            {
                var sbt = Environment.ExpandEnvironmentVariables("%SBT%");
                if (sbt == "") {
                    var main = String.Join(" ",(new System.IO.DirectoryInfo("../src/main/scala")).EnumerateFiles().Select(x=> x.FullName));
                    var java = String.Join(" ",(new System.IO.DirectoryInfo("../src/main/java")).EnumerateFiles().Select(x=> x.FullName));
                    var targetClasses = new System.IO.DirectoryInfo("../target/classes").FullName;
                    results.AddRange(Exec("..", "%SCALAC%", String.Format("-nowarn -d {0} {1} {2}", targetClasses, main, java)));
                    results.AddRange(Exec("..", "%JAVAC%", String.Format("-nowarn -cp {0} -d {0} {1}", targetClasses, java)));
                    results.AddRange(Exec("../bin", "%SCALAEXE%", String.Format("-cp {0} Main", targetClasses)));
                } else {
                    var tail = Exec("..", "%SBT%", String.Format("run"))
                                   .Skip(3).ToList();
                    results.AddRange(
                        tail.Take(tail.Count - 1)
                    );
                }
            }
            return results;
        }
        static IEnumerable<Result> JavaScript()
        {
            List<Result> results = new List<Result>();
            if (EnableJavaScript)
            {
                results.AddRange(Exec("..", "%JSEXE%", "src\\main\\js\\main.js"));
            }
            return results;
        }

        static AutoResetEvent needsBuild = new AutoResetEvent(true);
        static bool EnableScala = true;
        static bool EnableJavaScript = false;
        
        static void Main(string[] args)
        {
            sw.Start();
            Task.Factory.StartNew(Compiler);
            WatchForChanges("../src/main/scala", "*");
            WatchForChanges("../src/main/js", "*");
            while (true) {
                var keyInfo = Console.ReadKey(true);
                string combo = GetKeyCombo(keyInfo);
                
                switch (combo) {
                    case "F1": 
                        EnableScala = !EnableScala;
                        break;
                    case "F2":
                        EnableJavaScript = !EnableJavaScript;
                        break;
                    case "Shift-F1":
                        EnableScala = true;
                        EnableJavaScript = false;
                        break;
                    case "Shift-F2":
                        EnableScala = false;
                        EnableJavaScript = true;
                        break;
                    case "F5":
                        break;
                    default:
                        continue;
                        
                }
                PrintMenu();
                needsBuild.Set();
            }
        }
        static string GetKeyCombo(ConsoleKeyInfo info) 
        {
            List<string> mods = new List<string>();
            if (info.Modifiers.HasFlag(ConsoleModifiers.Control)) mods.Add("Ctrl");
            if (info.Modifiers.HasFlag(ConsoleModifiers.Alt)) mods.Add("Alt");
            if (info.Modifiers.HasFlag(ConsoleModifiers.Shift)) mods.Add("Shift");
            mods.Add(info.Key.ToString());
            return String.Join("-", mods);
        }
        static void Compiler() {
            try {
                while (true) {
                    needsBuild.WaitOne();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Executing Test...");
                    Console.ResetColor();
                    ClearBuild();
                    var results = CollectMany(new Func<IEnumerable<Result>>[] {
                        Scala,
                        JavaScript
                    });
        
                    PrintResults(results.Result);
                }
            } catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fatal Error: " + ex);
                Console.ResetColor();
                needsBuild.Set();
                Thread.Sleep(1000);
                Compiler();
            }
        }
        
        static void PrintMenuItem(string key, string name, bool? state) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(key);
            Console.ResetColor();
            Console.Write("-");
            Console.Write(name);
            if (state.HasValue) {
                Console.Write(" [");
                switch (state.Value) {
                    case false:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Off");
                        break;
                    case true:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("On");
                        break;
                }
                Console.ResetColor();
                Console.Write("]");
            }
            Console.Write("; ");
        }
        
        static void PrintMenu() {
            var x = Console.CursorLeft;
            var y = Math.Max(2, Console.CursorTop);
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            PrintMenuItem("F1", "Scala", EnableScala);
            PrintMenuItem("F2", "JavaScript", EnableJavaScript);
            PrintMenuItem("F5", "►", null);
            Console.WriteLine("".PadRight(Console.BufferWidth));
            Console.CursorLeft = x;
            Console.CursorTop = y;

        }
        static void PrintResults(IEnumerable<Result> results)
        {
            Console.Clear();
            PrintMenu();
            foreach (var result in results)
            {
                switch (result.Type)
                {
                    case ResultType.Pass:
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("PASS");
                        Console.ResetColor();
                        Console.Write("] ");
                        Console.WriteLine(result.Text);
                        break;
                    case ResultType.Fail:
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("FAIL");
                        Console.ResetColor();
                        Console.Write("] ");
                        Console.WriteLine(result.Text);
                        break;
                    case ResultType.StdErr:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(result.Text);
                        Console.ResetColor();
                        break;
                    case ResultType.StdOut:
                        Console.WriteLine(result.Text);
                        break;
                }
            }
        }
        private static async Task<IEnumerable<T>> CollectMany<T>(Func<IEnumerable<T>>[] funcs)
        {
            var tasks = new Task<IEnumerable<T>>[funcs.Length];
            for (var i = 0; i < funcs.Length; i++)
            {
                ((Action<int>) (x => {
                    tasks[i] = Task.Run<IEnumerable<T>>((() => funcs[x]()));
                }))(i);
            }
            var allResults = await Task.WhenAll(tasks);
            List<T> ret = new List<T>();
            foreach (var results in allResults)
            {
                ret.AddRange(results);
            }
            return ret;
        }
        static void WatchForChanges(string path, string pattern)
        {
            var watcher = new FileSystemWatcher(path, pattern);
            watcher.Changed += watcher_Changed;
            watcher.Renamed += watcher_Changed;
            watcher.Created += watcher_Changed;
            watcher.Deleted += watcher_Changed;
            watcher.EnableRaisingEvents = true;
        }

        static void ClearBuild()
        {
            string[] directories = { "../bin", "../target/classes" };

	        foreach (string value in directories) {
                if (!Directory.Exists(value)) Directory.CreateDirectory(value);
                foreach (var file in Directory.GetFiles(value)) File.Delete(file);
	        }
        }

        static bool IsWindows() {
            switch (Environment.OSVersion.Platform) {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    return true;
            }
            return false;
        }

        static IEnumerable<Result> Exec(string dir, string cmd, string args)
        {
            if (!IsWindows ())
            {
                dir = dir.Replace ('\\', '/');
                cmd = cmd.Replace ('\\', '/');
                args = args.Replace ('\\', '/');
            }
            List<Result> results = new List<Result>();
            var filename = Environment.ExpandEnvironmentVariables(cmd);
            if (File.Exists(filename))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    WorkingDirectory = dir,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    FileName = filename,
                    Arguments = args
                };
                Process proc = Process.Start(psi);
                bool done = false;
                proc.OutputDataReceived += (o, e) =>
                {
                    if (e.Data != null)
                    {
                        if (e.Data == "Done!") {
                            done = true;
                            if (!proc.HasExited) {
                                try {
                                    proc.Kill();
                                } catch {}
                            }
                            return;
                        }
                        string[] words = e.Data.Split(new char[] { ':' }, 2);
                        if (words.Length == 2 && words[0] == "PASS")
                        {
                            results.Add(new Result
                            {
                                Type = ResultType.Pass,
                                Text = words[1]
                            });
                        }
                        else if (words.Length == 2 && words[0] == "FAIL")
                        {
                            results.Add(new Result
                            {
                                Type = ResultType.Fail,
                                Text = words[1]
                            });
                        }
                        else
                        {
                            results.Add(new Result
                            {
                                Type = ResultType.StdOut,
                                Text = e.Data
                            });
                        }
                    }
                };
                proc.ErrorDataReceived += (o, e) =>
                {
                    if (e.Data != null)
                    {
                        results.Add(new Result
                        {
                            Type = ResultType.StdErr,
                            Text = e.Data
                        });
                    }
                };

                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();

                proc.WaitForExit(20000);

                if (!proc.HasExited)
                {
                    proc.Kill();
                    results.Add(new Result
                    {
                        Type = ResultType.Fail,
                        Text = String.Format("{0} failed to execute within 20000ms.", filename)
                    });
                } else if (!done) {
                    Thread.Sleep(1000);
                }
            }
            return results;
        }

        private static System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (sw.ElapsedMilliseconds < 100) return;
            needsBuild.Set();
            sw.Restart();
        }
    }

    public enum ResultType {
        StdOut,
        StdErr,
        Pass,
        Fail
    }

    class Result {
        public ResultType Type;
        public string Text;
    }
}
