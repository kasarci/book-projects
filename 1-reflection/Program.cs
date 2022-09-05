using System.Reflection;

Assembly? assembly = Assembly.GetEntryAssembly();

foreach (AssemblyName name in assembly.GetReferencedAssemblies())
{
  Assembly a = Assembly.Load(name);
  int methodCount = 0;

  foreach (TypeInfo t in a.DefinedTypes)
  {
    methodCount += t.GetMethods().Length;
  }

  Console.WriteLine(
    "{0:N0} types with {1:N0}, methods in {2} assembly.",
    arg0: a.DefinedTypes.Count(),
    arg1: methodCount,
    arg2: name.Name
  );
}