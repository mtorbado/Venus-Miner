using System.Collections;

public class Medium1 : AbsLevel {

    public override void Initialize() {
        robotActions = (RobotActions)transform.GetComponent<RobotActions>();
        oreGoal = 3;
    }
    
    public override IEnumerator Play(string[] args) {
        while (!CheckLevelPassed() && !CheckLevelFailed()) {
            for (int i=0; i < 3 && !CheckLevelFailed(); i++) {
                yield return robotActions.MoveFoward();
            }
            if (robotActions.IsRockInFront(1) && !CheckLevelFailed()) {
                yield return robotActions.TurnRight();
            }
            for (int i=0; i < 3 && !CheckLevelFailed(); i++) {
                yield return robotActions.MoveFoward();
            }
        }
        if (CheckLevelFailed()) {
            yield return robotActions.BreakAnimation();
        }
    }
}