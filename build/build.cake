#addin "Cake.Xamarin"
#addin "Cake.FileHelpers"
#tool nunit.consolerunner

var target = Argument("target", "package");

Setup(x =>
{
    DeleteFiles("../*.nupkg");
    DeleteFiles("./output/*.*");

	if (!DirectoryExists("./output"))
		CreateDirectory("./output");
});

Task("build")
	.Does(() =>
{
	NuGetRestore("../SoToGo.PushwooshMvvmCross/SoToGo.PushwooshMvvmCross.sln");
	DotNetBuild("../SoToGo.PushwooshMvvmCross/SoToGo.PushwooshMvvmCross.sln", x => x
        .SetConfiguration("Release")
        .SetVerbosity(Verbosity.Minimal)
        .WithProperty("TreatWarningsAsErrors", "false")
    );
});

Task("package")
	.IsDependentOn("build")
	.Does(() =>
{
	NuGetPack(new FilePath("../SoToGo.Plugins.Pushwoosh.nuspec"), new NuGetPackSettings());
	MoveFiles("./*.nupkg", "./output");
});

Task("publish")
    .IsDependentOn("package")
    .Does(() =>
{
    NuGetPush("./output/*.nupkg", new NuGetPushSettings
    {
        Source = "http://www.nuget.org/api/v2/package",
        Verbosity = NuGetVerbosity.Detailed
    });
});

RunTarget(target);