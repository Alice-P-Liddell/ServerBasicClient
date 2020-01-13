using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInManager : MonoBehaviour
{
    void Start()
    {
        SignIn();
        //AddScore();
    }

    public void SignIn()
    {
        HTTPNetworkManager.Instance.SignIn("goya1", "goya1234");
    }

    public void AddScore()
    {
        HTTPNetworkManager.Instance.AddScore(12);
    }
}
