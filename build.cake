#addin nuget:?package=Cake.Docker&version=1.3.0

var target = Argument("target", "DockerInformation");
var configuration = Argument("configuration", "Release");
var solutionFolder = "./";
string [] dockerTags = new string[] { "api_local:v2", "justtestingcake" };
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
    var settings = new DockerImageBuildSettings { Tag = dockerTags, File = "Cod3rsGrowth.Web/Dockerfile" };
    DockerBuild(settings, "./");
});

Task("DockerInformation")
    .IsDependentOn("DockerBuild")
    .Does(() =>
{
    Information("Run the image by running:");
    foreach (var dockerTag in dockerTags)
    {
        Information($"\tdocker run -d -p {containerPort}:80 -e \"STRING_CONEXAO\"=\"YourConnectionStringHere\" {dockerTag}");
    }
});

RunTarget(target);