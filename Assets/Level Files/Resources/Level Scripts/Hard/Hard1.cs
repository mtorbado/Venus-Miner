using System.Collections;

public class Hard1 : AbsLevel {

    public override void Initialize() {
        robotActions = (RobotActions)transform.GetComponent<RobotActions>();
        oreGoal = 3;
    }

    public override IEnumerator Play(string[] args) {
        int[] imput = InputToInt(args);
        for (int i=0; i < imput[0] && !CheckLevelFailed(); i++) {
            yield return robotActions.MoveFoward();
        }
        yield return robotActions.TurnRight();
        for (int i=0; i < imput[1] && !CheckLevelFailed(); i++) {
            yield return robotActions.MoveFoward();
        }
        yield return robotActions.TurnLeft();
        for (int i=0; i < imput[2] && !CheckLevelFailed(); i++) {
            yield return robotActions.MoveFoward();
        }
        yield return robotActions.TurnRight();
        for (int i=0; i < imput[3] && !CheckLevelFailed(); i++) {
            yield return robotActions.MoveFoward();
        }
        if (CheckLevelFailed()) {
            yield return robotActions.BreakAnimation();
        } else {
            CheckLevelPassed();
        }
    }
}