using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryRestartButton : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene("NivelPrincipal");
    }
}
