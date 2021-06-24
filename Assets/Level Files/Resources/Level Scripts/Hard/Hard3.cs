using System.Collections;

public class Hard3 : AbsLevel {

    public override void Initialize() {
        robotActions = (RobotActions)transform.GetComponent<RobotActions>();
        oreGoal = 1;
    }

    public override IEnumerator Play(string[] args) {
        int[] imput = InputToInt(args);
        for (int i=0; i < 5 && !CheckLevelFailed(); i++) {
            yield return robotActions.MoveFoward();
        }
        yield return robotActions.TurnLeft();
        for (int i=0; i < imput[0] && !CheckLevelFailed(); i++) {
            yield return robotActions.MoveBackward();
        }
        if (CheckLevelFailed()) {
            yield return robotActions.BreakAnimation();
        } else {
            CheckLevelPassed();
        }
    }
}