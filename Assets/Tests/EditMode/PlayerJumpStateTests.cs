using NUnit.Framework;
using Platformer.Mechanics;
using UnityEngine;

public class PlayerJumpStateTests
{
    [Test]
    public void EditMode_PlayerJumpState_StartsGrounded()
    {
        var player = new GameObject("TestPlayer");
        player.SetActive(false);
        try
        {
            var controller = player.AddComponent<PlayerController>();
            Assert.That(controller.jumpState,
                Is.EqualTo(PlayerController.JumpState.Grounded));
        }
        finally
        {
            Object.DestroyImmediate(player);
        }
    }
}
