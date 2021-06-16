using UnityEngine;
using UnityEngine.UI;
using RPG.SceneManagement;
using TMPro;


namespace RPG.UI
{
    public class SaveLoadUI : MonoBehaviour 
    {
        [SerializeField] Transform contentRoot;
        [SerializeField] GameObject buttonPrefab;

        private void OnEnable() 
        {
            SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();
            if (savingWrapper ==null) return;
                        
            foreach (Transform child in contentRoot)
            {
                Destroy(child.gameObject);
            }
            
            
            foreach (string save in savingWrapper.ListSaves())
            {
                GameObject buttonInstance = Instantiate(buttonPrefab, contentRoot);
                TMP_Text textComp = buttonInstance.GetComponentInChildren<TMP_Text>();
                textComp.text = save;
                Button button = buttonInstance.GetComponentInChildren<Button>();
                button.onClick.AddListener(()=>
                {
                    savingWrapper.LoadGame(save);
                });
            }


            
            
            
        }
        
    } 
    
}