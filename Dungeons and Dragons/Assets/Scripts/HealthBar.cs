using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bar;


    private void Start()
    {
        bar = transform.Find("Bar");
    }

    // Update is called once per frame
    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1.21f);
    }
}
