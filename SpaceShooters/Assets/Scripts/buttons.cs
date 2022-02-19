using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Buttons : MonoBehaviour
{
    public GameObject rocket, playAgain, login, register, ok;
    public AudioSource music;
    public Text highScore, nickName, error;
    public int high;
    public Score score;
    public Menu menu;
    //public string userName, password;
    public List<Data> leaderBoard = new List<Data>();
    public string file;
    public InputField user, key;
    bool newUser;
    public Data player = null;
    int position;
    public Text[] best, texts;
    bool playerExists = false;
    public Canvas canvas;
    public Canvas canvas2;

    bool Button() => Time.timeScale == 0.05f;
    public void NewUser()
    {
        foreach (var item in leaderBoard)
        {
            if(item.userName == user.text)
            {
                playerExists = true;
            }
        }
        if (!playerExists)
        {
            nickName.text = user.text;
            user.gameObject.SetActive(false);
            key.gameObject.SetActive(false);
            ok.SetActive(false);
            player = new Data(user.text, key.text, 0, 0.5f, new Color(158, 185, 255, 255), 0.5f, false);
            leaderBoard.Add(player);
            position = leaderBoard.IndexOf(player);
            Save.SaveData<Data>(leaderBoard, file);
        }
        else
        {
            playerExists = false;
            StartCoroutine(Error($"PLAYER NAMED {user.text} ALREADY EXISTS"));
        }
    }
    public void Toggle(bool toggle)
    {
        if (toggle)
        {
            Screen.SetResolution(1000, 2120, false);
            player = new Data(player.userName, player.password, player.score, player.volume, player.rgb, player.boltVolume, true);
            canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1000, 2120);
            canvas2.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1000, 2120);
        }
        else
        {
            Screen.SetResolution(1400, 2120, false);
            player = new Data(player.userName, player.password, player.score, player.volume, player.rgb, player.boltVolume, false);
            canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1400, 2120);
            canvas2.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1400, 2120);
        }
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
        if(user.text == "")
        {
            ok.SetActive(false);
            login.SetActive(true);
            register.SetActive(true);
        }
        else if (newUser)
        {
            NewUser();
        }
        else
        {
            bool playerExists = false;
            Data d = new Data(null, null, 0, 0, Color.white, 0, false);
            foreach (var item in leaderBoard)
            {
                if(user.text == item.userName)
                {
                    playerExists = true;
                    d = item;
                }
            }
            if (playerExists)
            {
                if (key.text == d.password)
                {
                    ok.SetActive(false);
                    position = leaderBoard.IndexOf(d);
                    player = d;
                    high = player.score;
                    menu.GetComponent<Menu>().LoadVolume(d.volume, d.boltVolume);
                    nickName.text = user.text;
                    Text(d.rgb);
                    user.gameObject.SetActive(false);
                    key.gameObject.SetActive(false);
                }
                else
                {
                    StartCoroutine(Error("WRONG PASSWORD"));
                }
            }
            else
            {
                StartCoroutine(Error($"{user.text} DOES NOT EXIST"));
            }
        }
    }
    void Text(Color color)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].color = color;
        }
    }
    public void Colors(GameObject color)
    {
        Color c = color.GetComponent<Image>().color;
        Text(c);
        player = new Data(player.userName, player.password, player.score, player.volume, c, player.boltVolume, player.slim);
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
        if(leaderBoard.Count != 0)
        {
            leaderBoard = leaderBoard.OrderByDescending(x => x.score).ToList();
        }
        if (score.score > high)
        {
            high = score.score;
            
        }
        highScore.text = $"HighScore: {high}"; 
        if (player.userName != "")
        {
            player = new Data(player.userName, player.password, high, menu.GetComponent<Menu>().volume, player.rgb, menu.GetComponent<Menu>().boltVolume, player.slim);
            leaderBoard[position] = player;
            leaderBoard = leaderBoard.OrderByDescending(x => x.score).ToList();
            for (int i = 0; i < best.Length; i++)
            {
                try
                {
                    best[i].text = $"{i + 1}. {leaderBoard[i].userName} | {leaderBoard[i].score}";
                }
                catch
                {
                    best[i].text = $"{i + 1}. - | -";
                }
            }
            Save.SaveData<Data>(leaderBoard, file);
        }
        yield return new WaitWhile(Button);
        StartCoroutine(Active());
    }
    IEnumerator Error(string text)
    {
        error.text = text;
        yield return new WaitForSecondsRealtime(2);
        error.text = "";
    }
}
