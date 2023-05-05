using UnityEngine;

public class SwapNum : MonoBehaviour
{

    int x = 1;
    int a = 2, b = 3;

    private void Start()
    {

        Test(x);
        Debug.Log("Outside method " + x); //x = 1

        Test(ref x);
        Debug.Log("Outside method " + x); //x = 2

        Swap();
        Debug.Log("a : " + a + " b :" + b); //a = 3 b = 2 

        Swap(a, b);
        Debug.Log("a : " + a + " b :" + b); //a = 2 b = 3 

        Swap(ref a, ref b);
        Debug.Log("a : " + a + " b :" + b); //a = 3 b = 2

    }

    void Test(int z) => z++;

    void Test(ref int z) => z++;

    void Swap()
    {
        a = b;
        b = a;
    }

    void Swap(int num1, int num2)
    {
        int c = num1; //2
        a = num2; //3
        b = c; //2
    }

    void Swap(ref int num1, ref int num2)
    {
        int c = num1; //2
        a = num2; //3
        b = c; //2  
        //b = num1; //3
    }
}