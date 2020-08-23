
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MontyHallButton : UdonSharpBehaviour
{
    public MontyHall montyHall;
    public GameObject montyHallGO;
    public int doorNumber = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (doorNumber == 1)
        {
            montyHall.ChooseDoor1();
        } 
        else if (doorNumber == 2)
        {
            montyHall.ChooseDoor2();
        }
        else if (doorNumber == 3)
        {
            montyHall.ChooseDoor3();
        }
    }

    void Start()
    {
        montyHallGO = GameObject.Find("MontyHall");
        montyHall = montyHallGO.GetComponent<MontyHall>();
    }
}
