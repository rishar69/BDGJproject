using UnityEngine;
[System.Serializable]
public class Cooldown
{
    [SerializeField] private float cooldownTime;
    private float _nextExecutionTime;

    public bool IsCoolingDown => Time.time < _nextExecutionTime;
    public void StartCooldown() => _nextExecutionTime = Time.time + cooldownTime;
}