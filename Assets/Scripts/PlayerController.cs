using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float horizontalInput;
    float boundsFieldX;
    public float boundsOffset = 0.5f;

    private void Start()
    {
        //boundsFieldX = MapGeneration.BoundsField.x - boundsOffset;
    }


    void Update()
    {
        if(transform.position.x < - boundsFieldX)
        {
            transform.position = new Vector3(-boundsFieldX, transform.position.y, transform.position.z);
        }
        if(transform.position.x > boundsFieldX)
        {
            transform.position = new Vector3(boundsFieldX, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        
    }
}
