using System.Collections;

public class Easy3 : AbsLevel {

    public override void Initialize() {
        robotActions = (RobotActions)transform.GetComponent<RobotActions>();
        oreGoal = 1;
    }

    public override IEnumerator Play(string[] args) {
        for (int i=0; i < 3 && !CheckLevelFailed(); i++) {
            yield return robotActions.MoveFoward();
        }
        yield return robotActions.TurnLeft();
        for (int i=0; i < 2 && !CheckLevelFailed(); i++) {
            yield return robotActions.MoveFoward();
        }
        yield return robotActions.TurnRight();
        for (int i=0; i < 3 && !CheckLevelFailed(); i++) {
            yield return robotActions.MoveBackward();
        }
        if (CheckLevelFailed()) {
            yield return robotActions.BreakAnimation();
        }
        else {
            CheckLevelPassed();
        }
    }
}