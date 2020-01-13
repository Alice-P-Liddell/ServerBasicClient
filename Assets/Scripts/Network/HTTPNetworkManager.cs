using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HTTPNetworkManager : MonoBehaviour
{
    static HTTPNetworkManager instance;
    
    public static HTTPNetworkManager Instance
    {
        get
        {
            if (!instance)  //instance에 할당된 값이 없으면 하이러키에서 찾아서 할당
            {
                instance = GameObject.FindObjectOfType(typeof(HTTPNetworkManager)) as HTTPNetworkManager;
                if (!instance)  //하이러키에도 HTTPNetworkManager가 없으면 새로 만들어서 instance에 할당
                {
                    GameObject container = new GameObject();
                    container.name = "HTTPNetworkManager";
                    instance = container.AddComponent(typeof(HTTPNetworkManager)) as HTTPNetworkManager;
                }
            }
            return Instance;
        }
    }

    public void SignIn(string username, string password)
    {
        SignInData signInData = new SignInData(username, password);
        var postData = JsonUtility.ToJson(signInData);

        StartCoroutine(SendPostRequest(postData, HTTPNetworkConstant.signInRequestURL));
    }

    public void AddScore(int score)
    {
        AddScoreData addScoreData = new AddScoreData(score);
        var postData = JsonUtility.ToJson(addScoreData);

        StartCoroutine(SendPostRequest(postData, HTTPNetworkConstant.addScoreRequestURL));
    }

    IEnumerator SendPostRequest(string data, string requestURL)
    {
        UnityWebRequest www = UnityWebRequest.Put(HTTPNetworkConstant.serverURL + requestURL, data);

        www.method = "Post";
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            var headers = www.GetResponseHeaders();
            Debug.Log(www.downloadHandler.text);
        }
    }

    /*
    IEnumerator SendSignInRequest(string username, string password)
    {
        SignInData signInData = new SignInData();
        signInData.username = username;
        signInData.password = password;

        var postData = JsonUtility.ToJson(signInData);

        UnityWebRequest www = UnityWebRequest.Put("localhost:3000/users/signin", postData);
        www.method = "Post";
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            var headers = www.GetResponseHeaders();
            Debug.Log(www.downloadHandler.text);
        }
    }

    IEnumerator SendAddScoreRequest(int score)
    {
        AddScoreData addScoreData = new AddScoreData();
        addScoreData.score = score;

        var postData = JsonUtility.ToJson(addScoreData);
        //유니티가 만들어놓은 JsonUtility.ToJson()을 사용해서 Json을 생성할 때에는
        //struct나 class를 선언해줘야 한다는 귀찮음이 있지만,
        //JsonUtility를 사용하지 않고도 아래와 같이 Json을 생성할 수 있다.
        //var data = new { username = "홍길동", password = "hong1234" };
        //참고로 자바스크립트 문법에서는 훨씬 간단히 res.json({message:'Hi there'});로 생성할 수 있다.

        UnityWebRequest www = UnityWebRequest.Put("localhost:3000/users/addscore", postData);
        www.method = "Post";
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            var headers = www.GetResponseHeaders();
            Debug.Log(www.downloadHandler.text);
        }
    }
    */
}
