using UnityEngine;
using UnityEngine.UI;

public class ItemRequestUI : MonoBehaviour {

    [SerializeField] GameObject mainIcon;
    [SerializeField] GameObject[] materials;
    [SerializeField] Slider timeLeft;

	private void Start()
	{
        timeLeft.value = 1f;
	}

	public void UpdateUI(ItemRequest item, float timeRatio)
    {
        mainIcon.GetComponent<Image>().overrideSprite = item.icon;
        timeLeft.value = timeRatio;

        // TODO: should also assign the materials
    }

}
