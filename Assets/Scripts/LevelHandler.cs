using UnityEngine.UI;
using UnityEngine;
using Random = System.Random;

public class LevelHandler : MonoBehaviour
{
    private GameGrid gameGrid;
    [SerializeField] private Button[] buttons;
    [SerializeField] private Text sunEnergy;
    [SerializeField] public Sprite peaSprite, sunSprite;
    [SerializeField] public PlantController peaObject, sunObject;
    public ProjectileHandler sunPrefab;
    public static int SunCount = 100;
    public static readonly Plant[] Plants = new Plant[5];
    [SerializeField] private float sunCooldown = 10;
    private float countdown;
    private readonly Random rand = new Random();

    private void Start()
    {
        Plants[0] = new PeaShooter(peaSprite, peaObject);
        Plants[1] = new PeaShooter(peaSprite, peaObject);
        Plants[2] = new Sunflower(sunSprite, sunObject);
        init();
    }

    private void Update()
    {
        if (countdown > 0)
            countdown -= Time.deltaTime;
        else
        {
            var sun = Instantiate(sunPrefab, new Vector3(getRandomFloat(-1.95f, 21.57f), 25f,
                getRandomFloat(-2.34f, 41.21f)), Quaternion.identity);
            sun.name = "Sun";
            sun.isNaturalSun = true;
            countdown = sunCooldown;
        }

        sunEnergy.text = SunCount.ToString();
        if (!Input.GetMouseButtonDown(0)) return;
        if (getObjectOnMouse() == null || getObjectOnMouse().name != "Sun") return;
        Destroy(getObjectOnMouse());
        SunCount += 50;
    }

    private void init()
    {
        sunEnergy.text = SunCount.ToString();
        countdown = sunCooldown;
        for (int i = 0; i < 5; i++)
        {
            if (i < 3)
                buttons[i].image.sprite = Plants[i].Sprite;
            else
                buttons[i].image.color = Color.clear;
        }
    }

    private static GameObject getObjectOnMouse()
    {
        if (Camera.main is null) return null;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out var hit, 100) ? hit.transform.gameObject : null;
    }

    private float getRandomFloat(float min, float max)
    {
        return (float) (rand.NextDouble() * max) + min;
    }
}