using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float rotationSpeed = 90f;
    int count = 0;
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
        Quaternion originalRotation = transform.rotation;

        
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
                Debug.Log("count:" + (count%6+1));//�ؿ���
                break;
                
            }
            yield return null;
        }
            transform.rotation= originalRotation*Quaternion.Euler(-90, 0,0);
    }
}
