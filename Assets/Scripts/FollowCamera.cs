using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;

    private Vector3 tempCameraPosition;

    [SerializeField] private float minimumX ,maximumX;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
            return;
        
        tempCameraPosition = transform.position;
        tempCameraPosition.x = player.position.x;

        if (tempCameraPosition.x < minimumX)
        {
            tempCameraPosition.x = minimumX;
        }
        else if (tempCameraPosition.x > maximumX)
        {
            tempCameraPosition.x = maximumX;
        }
        transform.position = tempCameraPosition;
    }
}
