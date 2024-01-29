using System.Linq;
using UnityEditor;
using UnityEngine;

public static class BuildScript
{
    [MenuItem("Build/Build Windows")]
    public static void BuildWindows()
    {
        var buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = EditorBuildSettings.scenes.Select(scene => scene.path).ToArray(),
            locationPathName = $"Build/Windows/{Application.productName}.exe",
            target = BuildTarget.StandaloneWindows64,
            options = BuildOptions.None
        };
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
    
    [MenuItem("Build/Build WebGL")]
    public static void BuildWebGL()
    {
        var buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = EditorBuildSettings.scenes.Select(scene => scene.path).ToArray(),
            locationPathName = $"Build/WebGL",
            target = BuildTarget.WebGL,
            options = BuildOptions.None
        };
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}
