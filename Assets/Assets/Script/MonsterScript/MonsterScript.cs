using UnityEngine;

public class MonsterScript : MonoBehaviour
{

    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            StartCoroutine(GameManager.Instance.Dead());
            Debug.Log("Trigger enter true");
        
    }
}
