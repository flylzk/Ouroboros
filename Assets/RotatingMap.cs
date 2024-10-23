using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 90f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RotateMap());
        }
    }

    private IEnumerator RotateMap()
    {
        int count = 1;
        float targetAngle = 90f; // Ŀ����ת�Ƕ�
        float totalRotation = 0f; // ��ǰ��ת�Ƕ�
        float duration = targetAngle / rotationSpeed; // �������ʱ��
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float angleThisFrame = rotationSpeed * Time.deltaTime;
                transform.Rotate(-angleThisFrame, 0,0 );

            totalRotation += angleThisFrame; // ��������ת�Ƕ�
            elapsedTime += Time.deltaTime; // ���¾���ʱ��
            if (totalRotation >= targetAngle)
            {
                count++;
                break;
            }
            yield return null;
        }
            transform.rotation= Quaternion.Euler( 120,0, 0);
    }
}
