using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestHealthSystem
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestHealthSystemNegativeDamage()
    {
        var healthSystem = new GameObject().AddComponent<Health>();

        Assert.Throws<ArgumentOutOfRangeException>(() => healthSystem.Damage(
                    -10
            )
        );
    }

    [Test]
    public void TestHealthSystemNegativeHeal()
    {
        var healthSystem = new GameObject().AddComponent<Health>();

        Assert.Throws<ArgumentOutOfRangeException>(() => healthSystem.Heal(
                    -10
            )
        );
    }

    [Test]
    public void TestEnemyHealthSystemNegativeDamage()
    {
        var healthSystem = new GameObject().AddComponent<EnemyHealth>();

        Assert.Throws<ArgumentOutOfRangeException>(() => healthSystem.Damage(
            -10
            )
        );
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestHealthSystemWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestPlayerAttack()
    {
        yield return null;
    }


    [UnityTest] public IEnumerator TestEnemyAttack()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerMovement()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator EnemyMovement()
    {
        yield return null;
    }

    [Test]
    public void TestHealthVisual()
    {
        var healthSystem = new GameObject().AddComponent<Health>();

        Assert.Throws<ArgumentOutOfRangeException>(() => healthSystem.Damage(
                    -10
            )
        );
    }
}
