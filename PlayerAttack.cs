using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons = new List<Weapon>();
    [SerializeField] private GameObject _weaponContainer;
    [SerializeField] private float _healthPoints;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private GameObject _gameOverPanel;

    public Weapon _currentWeapon;
    public float HealthPoints { get { return _healthPoints; } set { _healthPoints = value; } }
    public List<Weapon> Weapons { get => _weapons; set => _weapons = value; }

    public Action ChangeWeapon;

    private void OnEnable()
    {
        Attack.Attacked += ChangeSliderValue;
    }

    private void OnDisable()
    {
        Attack.Attacked -= ChangeSliderValue;
    }

    private void Start()
    {
        SetWeapon(WeaponType.pistol);
        _healthSlider.maxValue = _healthPoints;
        ChangeSliderValue();
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - new Vector2(_weaponContainer.transform.position.x, 
                                                        _weaponContainer.transform.position.y);
        _weaponContainer.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

        _currentWeapon.CheckShootButtonPress(direction);
    }

    public void SetWeapon(WeaponType weaponType)
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            if (_weapons[i]._weaponType == weaponType)
            {
                _currentWeapon = null;
                _currentWeapon = _weapons[i];
                _currentWeapon.gameObject.SetActive(true);
                ChangeWeapon?.Invoke();
            }
            else
            {
                _weapons[i].gameObject.SetActive(false);
            }
        }
    }

    private void ChangeSliderValue()
    {
        _healthSlider.value = _healthPoints;
        if (_healthPoints <= 0)
        {
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

//—делать систему магазина дл€ пистолета (магазина с пул€ми)
//»грок может выстрелить с задержкой в 1-2 секунды 10 пуль. «атем идЄт перезар€дка 3-4 секунды, и снова игрок выстреливает 10 пуль. 
//» игрока должна быть возможность перезар€дитьс€ по кнопке на экарне. “ак же на экране дожно отображатьс€ сколько патронов в магазине и сколько всего патронов в инвентаре.

//ƒобавить узи
//ƒобавить дополнительно абсолютно любое оружие

//ƒоделать смену оружи€. 
//‘ункци€ SetWeapon должна сравнивать передаваемый тип с типами всех пушек. ≈сли тип совпал, то включаем это оружие. ≈сли не совпал, выключаем его

//ѕридумать еще 2 вида оружи€

//Ќайти спрайт дл€ игрока
//ƒобавить еще одно оружие(работает по спец кнопке, вызывает бомбардировку с небес)

//сделать базового врага, который будет идти влево(медленно), как только рассто€ние от врага до игрока будет меньше определЄнного, то враг начинает атаковать игрока и отнимать здоровье раз в несколько секунд
//добавить здоровье и bar игроку, как только здоровье доходит до нул€ выводитс€ панель конца игры

//ƒоделать WaveController. —делать так, чтобы нова€ волна начиналась, когда мы убили всех врагов из предыдущей