using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MonsterScript : MonoBehaviour
{
    public float duration = 0;
    public float treshold;
    public float moveSpeed;
    private bool isInsideTrigger = false;
    public Transform playerPosition;
    private float distanceTreshold = 16f;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, playerPosition.position);
        print(distance);    

        if (distance <= distanceTreshold)
        {
            CameraScripts.Instance.ShakeCamera(1);
        }
        else
        {
            CameraScripts.Instance.ShakeCamera(0);
        }
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        if (isInsideTrigger)
        {
            duration += Time.deltaTime;
            print(duration);

            if (duration > treshold)
            {
                GameManager.Instance.InstantDeath();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInsideTrigger = true;
        Debug.Log("Trigger enter true");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInsideTrigger = false;

        duration = 0;
    }
}
