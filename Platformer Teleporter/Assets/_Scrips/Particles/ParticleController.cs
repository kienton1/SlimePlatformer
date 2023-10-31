using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private void FinishAnim()
    {
        Debug.Log("FinishAnim called");
        Destroy(gameObject);
    }
}
