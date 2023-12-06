using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class ChaserBulletMotion : MonoBehaviour
{
    private GameObject target;
    public float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        SelectTarget();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    }

    void LastUpdate()
    {
        
    }

    private void SelectTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        target = enemies[0];
    }
}
