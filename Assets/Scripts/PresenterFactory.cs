using Zenject;
using System;

public class PresenterFactory
{
    private DiContainer _diContainer;

    public PresenterFactory(DiContainer diContainer) => _diContainer = diContainer;

    public IPresenter Get(TypeScene type)
    {
        switch (type)
        {
            

            default:
                throw new ArgumentException(nameof(type));
        }
    }
}
