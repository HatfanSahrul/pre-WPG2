using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handler : MonoBehaviour
{
    // public GameObject int_button_i, int_button_e;
    public float randRotate;
    
    public float submarineSpeed;

    public bool isElecticOn1, isElecticOn2;

    public GameObject compas;
    public GameObject[] wires;

    void Start(){
        isElecticOn1=true;
        isElecticOn2=true;
    }

    void generateDegree(){
        randRotate=Random.Range(10f, 60f);
    }
}
