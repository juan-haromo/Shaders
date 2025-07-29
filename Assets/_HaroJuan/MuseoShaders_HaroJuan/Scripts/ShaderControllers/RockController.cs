using UnityEngine;

public class RockController : MonoBehaviour
{
    public Material rockMat;
    int matVersion = 0;

    public void ChangeMat()
    {
        Debug.Log("MatVer");
        rockMat.SetFloat("_Direction", matVersion);
        matVersion++;
        matVersion %= 3;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ChangeMat();
        }
    }
}
