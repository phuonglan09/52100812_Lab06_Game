using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class StartMenuScript : MonoBehaviour
{
    public GameObject exitButton;
    public GameObject title;
    public GameObject startButton;

    // Hàm được gọi khi nhấn nút "Start" trong menu
    public void StartGame()
    {
        //SceneManager.LoadScene("Scenes/lab05");
        StartCoroutine(ChangeLevel());
    }

    IEnumerator ChangeLevel()
    {
        // Lấy tham chiếu tới FaderScript
        FaderScript fader = GameObject.FindObjectOfType<FaderScript>();

        // Bắt đầu fading và lưu thời gian fading
        float fadeTime = fader.BeginFade(1);

        // Đợi cho thời gian fading
        yield return new WaitForSeconds(fadeTime);

        // Load scene "Play"
        SceneManager.LoadScene("Play");
    }

    // Hàm được gọi khi nhấn nút "Exit" trong menu
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}