using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public List<Button> btns = new List<Button>();


    [SerializeField] Button buttonAcak;


    public Sprite[] puzzles;
    private bool firstGuess, secondGuess;

    private string firstGuessPuzzle, secondGuessPuzzle;

    private int firstGuessIndex, secondGuessIndex;


    public List<Sprite> gamePuzzles = new List<Sprite>();
    private void Start(){
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        pengacakPuzzle(gamePuzzles);

        buttonAcak.onClick.AddListener(() => pengacakPuzzle(gamePuzzles));
    }


    void GetButtons(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for(int i= 0; i<objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
        }
    }

    void AddListeners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener( ()=>pickAPuzzle() );
        }
    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

            for (int i = 0; i < looper; i++){

            if (index == looper / 2){
                index = 0;
                }
            gamePuzzles.Add(puzzles[index]);
            btns[i].image.sprite = gamePuzzles[i];
            index++;
        }
    }


    public void pickAPuzzle()
    {
        SFXScript.sfx.Audio.PlayOneShot(SFXScript.sfx.click);
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (!firstGuess){

            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
        } else if (!secondGuess)
            {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            StartCoroutine(CheckIfThePuzzlesMatch());
            }
    }

    public void pengacakPuzzle(List<Sprite> List)
    {
        for (int i = 0; i < List.Count; i++)
        {
            Sprite temp = List[i];
            int randomIndex = Random.Range(i, List.Count);
            List[i] = List[randomIndex];
            List[randomIndex] = temp;
            btns[i].image.sprite = gamePuzzles[i];
            SFXScript.sfx.Audio.PlayOneShot(SFXScript.sfx.click);
        }
    }

    private void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/Tebakan");
    }

   


    public IEnumerator CheckIfThePuzzlesMatch(){
        yield return new WaitForSeconds(1f);

        if(firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(.2f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0,0,0,0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
        }
        else { }

        yield return new WaitForSeconds(.5f);
        firstGuess = secondGuess = false;

    }
}
