using UnityEngine.UI;

public class HealthBarHandler
{
    private Image _healthBar;

    public HealthBarHandler(Image image) 
    {
        _healthBar = image;
    }

    public void UpdateHealthBar(int currentHP, int maxHP)
    {
        _healthBar.fillAmount = (float)currentHP / (float)maxHP;
    }
}
