using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// This isn't perfect prediction, as the estimated time-to-target is based on where the target currently is,
/// not where they're going.
/// </summary>
public class PredictiveBulletMotion : MonoBehaviour
{
    public float inaccuracy = 3f;
    public float predictionSeconds = 1.0f;
    private float speed = 1.0f;
    private GameObject target;
    private Vector3 lastTargetPosition;
    private Vector3 targetDestination;
    private bool isFirstFrame = true;
    private bool isSecondFrame = false;

    

    // Start is called before the first frame update
    void Start()
    {
        SelectTarget();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstFrame)
        {
            lastTargetPosition = target.transform.position;
            isFirstFrame = false;
            isSecondFrame = true;
            return;
        }

        if (isSecondFrame)
        {
            CalculateDestination();
            CalculateBulletSpeed();
            isSecondFrame = false;
            //return;
        }


        transform.position = Vector3.MoveTowards(transform.position, targetDestination, Time.deltaTime * speed);
    }

    private float TargetSpeed()
    {
        return target.GetComponent<KillbotMovement>().speed;
    }

    private void CalculateDestination()
    {
        float jitterX = UnityEngine.Random.Range(-inaccuracy, inaccuracy);
        float jitterY = UnityEngine.Random.Range(-inaccuracy, inaccuracy);
        Vector3 adjustment = new Vector3(jitterX, jitterY, 0);
        Vector3 trajectory = (target.transform.position - lastTargetPosition) / Time.deltaTime;
        targetDestination = target.transform.position + (trajectory * predictionSeconds) + adjustment;
        //float timeToReach = Vector3.Distance(transform.position, target.transform.position) / speed;
        //targetDestination = target.transform.position + (trajectory * timeToReach);
    }

    private void CalculateBulletSpeed()
    {
        float distance = Vector3.Distance(transform.position, targetDestination);
        speed = distance / predictionSeconds;
    }

    private void SelectTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //target = enemies[0];
        System.Random random = new System.Random();
        int index = random.Next(0, enemies.Length);
        target = enemies[index];
    }
}
