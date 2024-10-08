using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SolarSystemManager : MonoBehaviour
{
    public static SolarSystemManager singleton; // static means variable can be accessed by all instances of this

    [Header("Planets")]
    [SerializeField] List<Planet> planets;

    [SerializeField] int planetsColonized = 0;
    [SerializeField] ScreenFader hyperJumpScreenFader;
    bool colonizedEntireSystem = false;

    [Header("Text")]
    [SerializeField] NoticeText jumpText;

    void Awake()
    {
        if (singleton == null) // if no one has claimed it,  i am the one solar system manager
        {
            singleton = this;
        }
        else
        {
            Debug.LogError("Multiple solar system managers detected!! >:|");
            Destroy(this.gameObject); // we only need one solar system manager!
        }
    }

    public void RegisterPlanet (Planet p)
    {
        planets.Add(p);
    }

    public void ReportPlanetColonization(){
        planetsColonized += 1;

        if (planetsColonized == planets.Count){
            // Debug.Log("We won!");
            colonizedEntireSystem = true;
            jumpText.ShowText();
        }
    }

    public void JumpAwayFromSystem()
    {
        if(!colonizedEntireSystem){
            return; // only allowed to jump once errthing colonized
        }

        hyperJumpScreenFader.FadeToColor();
        StartCoroutine(DelayLeaveLevelAfterJump());
    }

    IEnumerator DelayLeaveLevelAfterJump(){
        // while(!hyperJumpScreenFader.DoneFadingToColor()){
        //     yield return null;
        // }

        yield return new WaitUntil(()=>hyperJumpScreenFader.DoneFadingToColor()); // same as while loop above

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // load the scene
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
