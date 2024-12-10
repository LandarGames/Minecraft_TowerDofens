using UnityEngine;

public class Version_woln : MonoBehaviour
{
    private bool up = true;

    private void Update()
    {
        var scale = transform.localScale;
        if (up == true)
        {
            scale.x += 0.5f * Time.deltaTime;
            scale.y += 0.5f * Time.deltaTime;
            transform.localScale = scale;
        }    
        else if (up == false)
        {
            scale.x -= 0.5f * Time.deltaTime;
            scale.y -= 0.5f * Time.deltaTime;
            transform.localScale = scale;
        }
        if (transform.localScale.x >= 1.1f && transform.localScale.y >= 1.1f)
        {
            up = false;
        }
        else if (transform.localScale.x <= 0.9f && transform.localScale.y <= 0.9f)
        {
            up = true;
        }

    }
}
