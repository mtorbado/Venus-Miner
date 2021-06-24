using System.Collections;

public class Challenge0 : AbsLevel {

    public override void Initialize() {
        robotActions = (RobotActions)transform.GetComponent<RobotActions>();
        oreGoal = 1;
    }

    public override IEnumerator Play(string[] args) {
        int[] imput = InputToInt(args);
        for (int i=0; i < imput[0] && !CheckLevelFailed(); i++) {
            if (robotActions.IsRockInFront(1)) {
                yield return robotActions.TurnRight();
            }
            yield return robotActions.MoveFoward();
        }
        if (CheckLevelFailed()) {
            yield return robotActions.BreakAnimation();
        }
        else {
            CheckLevelPassed();
        }
    }
}
