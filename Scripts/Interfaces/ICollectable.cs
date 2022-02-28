using UnityEngine;
public interface ICollectable
{
    public void Collect(Transform collectable);
    public void Drop(Transform collectable);

}
