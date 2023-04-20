using SeveriTommaso.UnrealDefense.Api;

public interface IEntity {
    string Name { get; }
    IPosition Position { get; set; }
    IWorld ParentWorld { get; set; }
    long TimeSinceLastAction { get; }
    void UpdateState(long elapsed);
    void ResetElapsedTime();
    void IncrementTime(long elapsed);
}