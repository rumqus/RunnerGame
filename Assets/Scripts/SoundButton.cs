using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    private Image currentSprite;
    [SerializeField] private Sprite OnSoundSprite;
    [SerializeField] private Sprite OffSounfSprite;
    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponent<Button>().image;
    }

    public void OnOffSound()
    {
        // something that on\off sound
        ChangeSprite();
    }


    private void ChangeSprite()
    {
        if (currentSprite.sprite.name == OnSoundSprite.name)
        {
            currentSprite.sprite = OffSounfSprite;
            Debug.Log("off");
        }
        else if (currentSprite.sprite.name == OffSounfSprite.name)
        {
            currentSprite.sprite = OnSoundSprite;
            Debug.Log("on");
        }
        FindObjectOfType<AudioManager>().SoundPlay("button");
        Debug.Log(currentSprite.sprite.name);
    }
}