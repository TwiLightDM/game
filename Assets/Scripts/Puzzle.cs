using UnityEngine;
using UnityEngine.UI;
public class Puzzle : MonoBehaviour
{
    public bool IsCompleted
    {
        get;
        private set;
    }
    
//название не менять
    public GameObject ClaimItem;
    private bool _itemSpawn;
    

    private GameObject _displayImage;

    void Start()
    {
        _itemSpawn = false;
        _displayImage = GameObject.Find("displayImage");
    }

    private void Update()
    {
        //если выполнили пазл, спавним ключ
        if (CompletePuzzle()&& !_itemSpawn)
        {
            
            var claimItem = Instantiate(ClaimItem, GameObject.Find("piece8").transform,false);
            claimItem.transform.localScale = new Vector3(15, 15, 15);
          
            _itemSpawn = true;
        }
        HideDisplay();
    }

    void HideDisplay()
    {
        // если курсор не на объекте или не нажата кнопка мышки
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            // объект не активен
            this.gameObject.SetActive(false);
        }
        // при возвращении назад объект не активен
        if (_displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.Normal)
        {
            this.gameObject.SetActive(false);
        }
    }

    bool CompletePuzzle()
    {
        if (IsCompleted) return true;
        IsCompleted = true;
        var puzzlePieces = FindObjectsOfType<PuzzlePiece>();
        foreach (PuzzlePiece puzzlePiece in puzzlePieces)
        {
            //если номер кусочка не соответствует номеру ячейки, то пазл не закончен
            if (int.Parse(puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1)) != 
                int.Parse(puzzlePiece.gameObject.GetComponent<Image>().sprite.name.ToString().Substring(puzzlePiece.gameObject.GetComponent<Image>().sprite.name.Length - 1))){
            
                IsCompleted = false;
            }
        }
        return IsCompleted;
    }
}
