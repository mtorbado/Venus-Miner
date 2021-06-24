using System.Collections;

public class Challenge1 : AbsLevel {

    public override void Initialize() {
        robotActions = (RobotActions)transform.GetComponent<RobotActions>();
        oreGoal = 1;
    }

    public override IEnumerator Play(string[] args) {
        int[] imput = InputToInt(args);
        int i = imput[0]; 
        while (!CheckLevelPassed() && !CheckLevelFailed()) {
            if (robotActions.IsRockInFront(1) && !CheckLevelFailed()) {
                yield return robotActions.TurnLeft();
            }
            for (int j=0; j < imput[1] && !CheckLevelFailed(); i++) {
                yield return robotActions.MoveFoward();
                CheckFail();
                yield return robotActions.MoveFoward();
            }
            if (robotActions.IsRockInFront(1) && !CheckLevelFailed()) {
                yield return robotActions.TurnLeft();
            }
            for (int j=0; j < i && !CheckLevelFailed(); i++) {
                yield return robotActions.MoveFoward();
                CheckFail();
                yield return robotActions.MoveFoward();
            }
            i--;
        }
        if (CheckLevelFailed()) {
            yield return robotActions.BreakAnimation();
        }


    }

    private IEnumerator CheckFail() {
        if(CheckLevelFailed()) {
            yield return robotActions.BreakAnimation();
        }
    }
}