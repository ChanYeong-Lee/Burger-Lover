using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartEffect : MonoBehaviour
{
    public GameObject directionalLight;
    public List<GameObject> interiorLights;
    public List<GameObject> signBoardLight;

    public float effectTime = 3.0f;
    public float delayTime1 = 1.0f;
    public float delayTime2 = 1.0f;

    private void Start()
    {
        StartCoroutine(StartCoroutine());
    }

    private IEnumerator StartCoroutine()
    {
        Quaternion startAngle = Quaternion.Euler(200.0f, 0.0f, 0.0f);
        Quaternion endAngle = Quaternion.Euler(170.0f, 0.0f, 0.0f);

        directionalLight.transform.rotation = startAngle;

        foreach (GameObject light in interiorLights)
        {
            light.SetActive(false);
        }

        foreach (GameObject light in signBoardLight)
        {
            light.SetActive(false);
        }

        float startTime = 0.0f;
        while (true)
        {
            directionalLight.transform.rotation = Quaternion.Lerp(startAngle, endAngle, startTime / effectTime);

            startTime += Time.deltaTime;
            if (startTime >= effectTime)
            {
                break;
            }

            yield return null;
        }

        directionalLight.transform.rotation = endAngle;

        yield return new WaitForSeconds(delayTime1);
        foreach (GameObject light in interiorLights)
        {
            light.SetActive(true);
        }

        yield return new WaitForSeconds(delayTime2);
        foreach (GameObject light in signBoardLight)
        {
            light.SetActive(true);
        }
    }
}
