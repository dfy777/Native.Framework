using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Native.Csharp.Repair;

namespace Native.Csharp.Repair
{
    public static class ModuleInitializer
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool AddDllDirectory(string lpPathName);

        public static void Initialize()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Type typeLoader = executingAssembly.GetType("Costura.AssemblyLoader");
            if (typeLoader == null)
            {
                return;
            }

            Dictionary<string, string> assemblyNames = GetInstanceField<Dictionary<string, string>>(typeLoader, null, "assemblyNames");
            Dictionary<string, string> symbolNames = GetInstanceField<Dictionary<string, string>>(typeLoader, null, "symbolNames");
            Uri uriOuter = new Uri(executingAssembly.Location == null ? executingAssembly.CodeBase : executingAssembly.Location);
            string path = Path.GetDirectoryName(uriOuter.LocalPath);
            string appPath = Path.Combine(path, executingAssembly.GetName().Name);
            if (!Directory.Exists(path))
            {
                return;
            }
            Directory.CreateDirectory(appPath);

#pragma warning disable CS0618 // 类型或成员已过时
            AppDomain.CurrentDomain.AppendPrivatePath(appPath);
#pragma warning restore CS0618 // 类型或成员已过时

            AddDllDirectory(appPath);

            foreach (var assemblyName in assemblyNames)
            {
                byte[] rawAssembly;
                using (Stream stream = LoadStream(assemblyName.Value, executingAssembly))
                {
                    if (stream != null)
                    {
                        rawAssembly = ReadStream(stream);
                        File.WriteAllBytes(Path.Combine(appPath, assemblyName.Key + ".dll"), rawAssembly);
                    }
                }
            };

            foreach (var pdbName in symbolNames)
            {
                byte[] rawAssembly;
                using (Stream stream = LoadStream(pdbName.Value, executingAssembly))
                {
                    if (stream != null)
                    {
                        rawAssembly = ReadStream(stream);
                        File.WriteAllBytes(Path.Combine(appPath, pdbName.Key + ".pdb"), rawAssembly);
                    }
                }
            };

            string bin = Path.Combine(Environment.CurrentDirectory, "bin");
            string sqliteInterop = Path.Combine(bin, "SQLite.Interop.dll");

            //释放SQLite.Interop.dll至酷Q Bin 目录
            if (File.Exists(sqliteInterop) == false)
            {
                using (var fileStream = File.Create(sqliteInterop))
                {
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{executingAssembly.FullName}.SQLite.Interop.dll"))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            }
        }

        private static T GetInstanceField<T>(Type type, object instance, string fieldName)
        {
            FieldInfo field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            return (T)field.GetValue(instance);
        }

        private static byte[] ReadStream(Stream stream)
        {
            byte[] array = new byte[stream.Length];
            stream.Read(array, 0, array.Length);
            return array;
        }

        private static Stream LoadStream(string fullName, Assembly executingAssembly)
        {
            if (fullName.EndsWith(".compressed"))
            {
                using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullName))
                {
                    using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        CopyTo(deflateStream, memoryStream);
                        memoryStream.Position = 0L;
                        return memoryStream;
                    }
                }
            }
            return executingAssembly.GetManifestResourceStream(fullName);
        }

        private static void CopyTo(Stream source, Stream destination)
        {
            byte[] array = new byte[81920];
            int count;
            while ((count = source.Read(array, 0, array.Length)) != 0)
            {
                destination.Write(array, 0, count);
            }
        }
    }
}