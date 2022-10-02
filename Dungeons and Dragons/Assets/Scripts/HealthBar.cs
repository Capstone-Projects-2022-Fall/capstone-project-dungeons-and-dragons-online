using UnityEngine;

/// <summary>
/// AttackArea handler
/// </summary>
public class HealthBar : MonoBehaviour
{
    /// <summary>
    /// Bar generator
    /// </summary>
    private Transform bar;

    /// <summary>
    /// Connect to the bar
    /// </summary>
    private void Start()
    {
        bar = transform.Find("Bar");
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1.21f);
    }
}
