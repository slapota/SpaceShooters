using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Buttons : MonoBehaviour
{
    public GameObject rocket, playAgain, login, register, ok;
    public AudioSource music;
    public Text highScore, nickName;
    public int high;
    public Score score;
    public Menu menu;
    //public string userName, password;
    public List<Data> leaderBoard = new List<Data>();
    public string file;
    public InputField user, key;
    bool newUser;
    Data player;
    int position;
    public Text[] best, texts;

    bool Button() => Time.timeScale == 0.05f;
    public void NewUser()
    {
        player = new Data(user.text, key.text, 0, 0.5f);
        leaderBoard.Add(player);
        position = leaderBoard.IndexOf(player);
        Save.SaveData<Data>(leaderBoard, file);
    }
    private void Start()
    {
        nickName.text = user.text;
        leaderBoard = Save.Load<Data>(file);
        leaderBoard = leaderBoard.OrderByDescending(x => x.score).ToList();
        for (int i = 0; i < best.Length; i++)
        {
            try
            {
                best[i].text = $"{i+1}. {leaderBoard[i].userName} | {leaderBoard[i].score}";
            }
            catch
            {
                best[i].text = $"{i+1}. - | -";
            }
        }
        ok.SetActive(false);
        StartCoroutine(Active());
        music.Play();
    }
    public void Ok()
    {
        ok.SetActive(false);
        if (newUser)
        {
            nickName.text = user.text;
            user.gameObject.SetActive(false);
            key.gameObject.SetActive(false);
            NewUser();
        }
        else
        {
            foreach (var item in leaderBoard)
            {
                if (user.text == item.userName)
                {
                    if (key.text == item.password)
                    {
                        position = leaderBoard.IndexOf(item);
                        player = item;
                        high = player.score;
                        menu.GetComponent<Menu>().LoadVolume(item.volume);
                        nickName.text = user.text;
                        user.gameObject.SetActive(false);
                        key.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    void Update()
    {
        music.volume = menu.GetComponent<Menu>().volume;
    }
    public void Colors(Button color)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].color = color.GetComponent<Renderer>().material.color;
        }
    }
    public void PlayAgain()
    {
        rocket.SetActive(false);
        rocket.transform.position = new Vector3(0, -4, 0);
        rocket.SetActive(true);
        Time.timeScale = 1;
        score.score = 0;
        GameObject[] asteroids = FindObjectsOfType<GameObject>();
        foreach (var item in asteroids)
        {
            if(item.name.Contains("Clone"))
            {
                Destroy(item);
            }
        }
    }
    public void Login(GameObject a)
    {
        login.SetActive(false);
        register.SetActive(false);
        ok.SetActive(true);
        if(a == register)
        {
            newUser = true;
        }
        else
        {
            newUser = false;
        }
    }

    IEnumerator Active()
    {
        highScore.text = "";
        playAgain.SetActive(false);
        rocket.SetActive(true);
        yield return new WaitUntil(Button);
        playAgain.SetActive(true);
        if(player != null)
        {
            player = new Data(player.userName, player.password, high, menu.GetComponent<Menu>().volume);
        }
        leaderBoard[position] = player;
        if(score.score > high)
        {
            high = score.score;
            if(player != null)
            {
                leaderBoard = leaderBoard.OrderByDescending(x => x.score).ToList();
                for (int i = 0; i < best.Length; i++)
                {
                    try
                    {
                        best[i].text = $"{i+1}. {leaderBoard[i].userName} | {leaderBoard[i].score}";
                    }
                    catch
                    {
                        best[i].text = $"{i+1}. - | -";
                    }
                }
                Save.SaveData<Data>(leaderBoard, file);
            }
        }
        highScore.text = $"HighScore: {high}";
        yield return new WaitWhile(Button);
        StartCoroutine(Active());
    }
}
