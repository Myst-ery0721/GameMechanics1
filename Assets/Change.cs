using UnityEngine;

public class Change : MonoBehaviour
{

    public GameObject[] maleHairOptions;
    public GameObject[] maleTorsoOptions;
    public GameObject[] malePantsOptions;


    public GameObject[] femaleHairOptions;
    public GameObject[] femaleTorsoOptions;
    public GameObject[] femalePantsOptions;


    public GameObject maleModel;
    public GameObject femaleModel;

    private int currentHairIndex = 0;
    private int currentTorsoIndex = 0;
    private int currentPantsIndex = 0;

    private GameObject currentModel; 
    private GameObject[] currentHairOptions;
    private GameObject[] currentTorsoOptions;
    private GameObject[] currentPantsOptions;

    private void Start()
    {
   
        SwitchModel(true);  
        ActivateOnlyOne(currentHairOptions, currentHairIndex);
        ActivateOnlyOne(currentTorsoOptions, currentTorsoIndex);
        ActivateOnlyOne(currentPantsOptions, currentPantsIndex);
    }

    public void NextHair()
    {
        currentHairIndex = (currentHairIndex + 1) % currentHairOptions.Length;
        ActivateOnlyOne(currentHairOptions, currentHairIndex);
    }

    public void PreviousHair()
    {
        currentHairIndex = (currentHairIndex - 1 + currentHairOptions.Length) % currentHairOptions.Length;
        ActivateOnlyOne(currentHairOptions, currentHairIndex);
    }

    public void NextTorso()
    {
        currentTorsoIndex = (currentTorsoIndex + 1) % currentTorsoOptions.Length;
        ActivateOnlyOne(currentTorsoOptions, currentTorsoIndex);
    }

    public void PreviousTorso()
    {
        currentTorsoIndex = (currentTorsoIndex - 1 + currentTorsoOptions.Length) % currentTorsoOptions.Length;
        ActivateOnlyOne(currentTorsoOptions, currentTorsoIndex);
    }

    public void NextPants()
    {
        currentPantsIndex = (currentPantsIndex + 1) % currentPantsOptions.Length;
        ActivateOnlyOne(currentPantsOptions, currentPantsIndex);
    }

    public void PreviousPants()
    {
        currentPantsIndex = (currentPantsIndex - 1 + currentPantsOptions.Length) % currentPantsOptions.Length;
        ActivateOnlyOne(currentPantsOptions, currentPantsIndex);
    }

 
    public void SwitchGender()
    {
        if (currentModel == maleModel)
        {
            SwitchModel(false); 
        }
        else
        {
            SwitchModel(true); 
        }
    }


    private void SwitchModel(bool isMale)
    {

        maleModel.SetActive(false);
        femaleModel.SetActive(false);


        if (isMale)
        {
            maleModel.SetActive(true);
            currentModel = maleModel;
            currentHairOptions = maleHairOptions;
            currentTorsoOptions = maleTorsoOptions;
            currentPantsOptions = malePantsOptions;
        }
        else
        {
            femaleModel.SetActive(true);
            currentModel = femaleModel;
            currentHairOptions = femaleHairOptions;
            currentTorsoOptions = femaleTorsoOptions;
            currentPantsOptions = femalePantsOptions;
        }

        // Reset to default 
        currentHairIndex = 0;
        currentTorsoIndex = 0;
        currentPantsIndex = 0;

        ActivateOnlyOne(currentHairOptions, currentHairIndex);
        ActivateOnlyOne(currentTorsoOptions, currentTorsoIndex);
        ActivateOnlyOne(currentPantsOptions, currentPantsIndex);

        Debug.Log($"Switched to {(isMale ? "Male" : "Female")} model.");
    }

    private void ActivateOnlyOne(GameObject[] options, int activeIndex)
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].SetActive(i == activeIndex);
        }
    }
}
