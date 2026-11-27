using System.Linq;
using NUnit.Framework;
using Platformer.Mechanics;
using UnityEditor.SceneManagement;

public class PlayerTests
{
    [Test]
    public void EditMode_PlayerTag_IsCorrect()
    {
        var scene = EditorSceneManager.OpenPreviewScene(
            "Assets/Scenes/SampleScene.unity");
        try
        {
            var player = scene.GetRootGameObjects()
                .SingleOrDefault(root => root.name == "Player");

            Assert.That(player, Is.Not.Null);
            Assert.That(player.CompareTag("Player"), Is.True);
            Assert.That(player.GetComponent<PlayerController>(), Is.Not.Null);
            Assert.That(player.GetComponent<Health>(), Is.Not.Null);
        }
        finally
        {
            EditorSceneManager.ClosePreviewScene(scene);
        }
    }
}
