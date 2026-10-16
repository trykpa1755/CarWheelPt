using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceController : MonoBehaviour
{
    public static bool racing = false;
    public static int totalLaps = 1;
    public int timer = 3;

    public CheckPointController[] carsController;

    public Text startText;
    AudioSource audioSource;
    public AudioClip count;
    public AudioClip start;

    public GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        endPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        startText.gameObject.SetActive(false);
        Debug.Log("-----------------------");
        InvokeRepeating("CountDown", 3, 1);

        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
        carsController = new CheckPointController[cars.Length];
        for(int i = 0; i < cars.Length; i++)
        {
            carsController[i] = cars[i].GetComponent<CheckPointController>();
        }

    }

    private void LateUpdate()
    {
        int finishedLap = 0;
        foreach(CheckPointController controller in carsController)
        {
            if (controller.lap == totalLaps + 1) finishedLap++;
            if(finishedLap == carsController.Length && racing)
            {
                Debug.Log("FinishRace");
                racing = false;
                endPanel.SetActive(true);
            }
        }
    }
    
    void CountDown()
    {
        startText.gameObject.SetActive(true);
        if(timer != 0)
        {
            //Debug.Log("Rozpoczêcie wyœcigu za: " + timer);
            startText.text = timer.ToString();
            audioSource.PlayOneShot(count);
            timer--;
        }
        else
        {
            startText.text = "START!!!";
            audioSource.PlayOneShot(start);
            //Debug.Log("Start!");
            racing = true;
            CancelInvoke("CountDown");
            Invoke("HideStartText", 1);
        }
    }
    void HideStartText()
    {
        if (startText != null) startText.gameObject.SetActive(false);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

}
