using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;

    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("BackGround"))
        {
            BoxCollider2D bgCollider = collision.GetComponent<BoxCollider2D>();
            if (bgCollider != null)
            {
                float widthOfBgObject = bgCollider.size.x; // ��׶����� width�� �����ɴϴ�.
                Vector3 pos = collision.transform.position;

                pos.x += widthOfBgObject * numBgCount;  // ��׶��� ��ü�� �̵���ŵ�ϴ�.
                collision.transform.position = pos;
                Debug.Log("Updated Background position: " + pos);  // ����� �α� �߰�
            }
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            // ��ֹ��� �浹���� �� ���ο� ��ġ�� ����
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
            Debug.Log("Obstacle position updated: " + obstacle.transform.position);  // ����� �α� �߰�
        }
    }

}