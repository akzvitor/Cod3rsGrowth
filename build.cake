#addin nuget:?package=Cake.Docker&version=1.3.0

var target = Argument("target", "DockerInformation");
var tag = Argument("tag", "latest");
var username = "teste";
var repositorio = "obras";
var configuration = Argument("configuration", "Release");
var solutionFolder = "./";
string containerPort = "5070";

Task("Build")
    .Does(() => 
{
        DotNetBuild(solutionFolder, new DotNetBuildSettings
        {
            Configuration = configuration
        });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetTest(solutionFolder, new DotNetTestSettings
    {
        NoBuild = true,
        NoRestore = true,
        Configuration = configuration
    });
});

Task("DockerBuild")
    .Does(() =>
{
    var settings = new DockerImageBuildSettings { Tag = new string[] {$"{username}/{repositorio}:{tag}"}, File = "Cod3rsGrowth.Web/Dockerfile" };
    DockerBuild(settings, "./");
});

Task("DockerInformation")
    .IsDependentOn("DockerBuild")
    .Does(() =>
{
    Information("Run the image by running:");
    Information($"\tdocker run -d -p {containerPort}:80 -e \"STRING_CONEXAO\"=\"YourConnectionStringHere\" {username}/{repositorio}:{tag}");
});

RunTarget(target);