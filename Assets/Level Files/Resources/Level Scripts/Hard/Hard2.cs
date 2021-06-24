using System.Collections;

public class Hard2 : AbsLevel {

    public override void Initialize() {
        robotActions = (RobotActions)transform.GetComponent<RobotActions>();
        oreGoal = 1;
    }

    public override IEnumerator Play(string[] args) {
        int[] imput = InputToInt(args);
        for (int i=0; i < imput[0] && !CheckLevelFailed(); i++) {
            yield return robotActions.MoveFoward();
        }
        for (int i=0; i < imput[1] && !CheckLevelFailed(); i++) {
            yield return robotActions.TurnRight();
            yield return robotActions.MoveFoward();
            if (CheckLevelFailed()) break;
            yield return robotActions.TurnLeft();
            yield return robotActions.MoveFoward();
        }
        for (int i=0; i < imput[2] && !CheckLevelFailed(); i++) {
            yield return robotActions.MoveFoward();
        }
        if (CheckLevelFailed()) {
            yield return robotActions.BreakAnimation();
        } else {
            CheckLevelPassed();
        }
    }
}