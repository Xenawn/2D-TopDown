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
                float widthOfBgObject = bgCollider.size.x; // 백그라운드의 width를 가져옵니다.
                Vector3 pos = collision.transform.position;

                pos.x += widthOfBgObject * numBgCount;  // 백그라운드 객체를 이동시킵니다.
                collision.transform.position = pos;
                Debug.Log("Updated Background position: " + pos);  // 디버깅 로그 추가
            }
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            // 장애물이 충돌했을 때 새로운 위치로 설정
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
            Debug.Log("Obstacle position updated: " + obstacle.transform.position);  // 디버깅 로그 추가
        }
    }

}