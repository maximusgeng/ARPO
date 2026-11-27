using System.Collections;
using NUnit.Framework;
using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerHealthTests
{
    [UnityTest]
    public IEnumerator PlayMode_PlayerTakesDamage_HealthDecreases()
    {
        var player = new GameObject("TestPlayer");
        player.SetActive(false);
        try
        {
            var health = player.AddComponent<Health>();
            health.maxHP = 3;
            player.SetActive(true);
            yield return null;

            Assert.That(health.IsAlive, Is.True);
            for (int hit = 1; hit < health.maxHP; hit++)
            {
                health.Decrement();
                Assert.That(health.IsAlive, Is.True, $"Hit {hit}");
            }

            health.Decrement();
            Assert.That(health.IsAlive, Is.False);
        }
        finally
        {
            Simulation.Clear();
            Object.Destroy(player);
        }
    }
}
