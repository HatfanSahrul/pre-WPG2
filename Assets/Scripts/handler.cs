using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handler : MonoBehaviour
{
    // public GameObject int_button_i, int_button_e;
    public float randRotate;
    public float submarineSpeed;
    public float countRotate;
    public float countLeak;
    public float countWire;
    public float limRot, limLeak, limWire;

    public int inLeak, inWire; 

    public bool isElecticOn1, isElecticOn2;

    public GameObject lvr1, lvr2;
    public GameObject compas;
    public GameObject[] wires, leaks;

    void Start(){
        hide();
        isElecticOn1=true;
        isElecticOn2=true;
        countRotate=countLeak=countWire=40f;

    }

    void Update(){
        isElecticOn1=lvr1.GetComponent<Lever>().isOn;
        isElecticOn2=lvr2.GetComponent<Lever>().isOn;
    }
    void generateDegree(){
        randRotate=Random.Range(10f, 60f);
    }

    void hide(){
        foreach(var item in wires){
            item.SetActive(false);
        }
        foreach(var item in leaks){
            item.SetActive(false);
        }
    }

    void randomize(){
        countLeak-=Time.deltaTime*1;
        countWire-=Time.deltaTime*1;
        countRotate-=Time.deltaTime*1;

        if(countLeak<=0){
            inLeak=Random.Range(0, 8);
            leaks[inLeak].SetActive(true);
            countLeak=Random.Range(5f, limLeak);
        }
        if(countWire<=0){
            inWire=Random.Range(0, 8);
            wires[inWire].SetActive(true);
            countWire=Random.Range(5f, limWire);
        }
        if(countRotate<=0){
            
        }
    }
}
