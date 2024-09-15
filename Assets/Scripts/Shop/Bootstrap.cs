using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ShopView shopView;
    private AudioManager _audioManager;
    private LvlFactory _lvlFactory;

    [Inject]
    private void Construct(AudioManager audioManager, LvlFactory lvlFactory)
    {
        _audioManager = audioManager;
        _lvlFactory = lvlFactory;
    }

    private void Start()
    {
        ShopPresenter shopPresenter = new ShopPresenter();
        shopPresenter.Initialize(shopView, _audioManager, _lvlFactory);
    }
}
