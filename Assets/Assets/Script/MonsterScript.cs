using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MonsterScript : MonoBehaviour
{
    public float duration = 0;
    public float treshold;
    public float moveSpeed;
    private bool isInsideTrigger = false;
    private CinemachineVirtualCamera cinemachineCamera;
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

        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        if (isInsideTrigger)
        {
            duration += Time.deltaTime;
            print(duration);

            if (duration > treshold)
            {
                StartCoroutine(GameManager.Instance.Dead());
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
