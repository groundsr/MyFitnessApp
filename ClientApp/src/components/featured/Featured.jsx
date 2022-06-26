import "./featured.scss";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import { CircularProgressbar } from "react-circular-progressbar";
import "react-circular-progressbar/dist/styles.css";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import KeyboardArrowUpOutlinedIcon from "@mui/icons-material/KeyboardArrowUpOutlined";
import { useState, useEffect } from "react";
import { Button } from "@mui/material";

const Featured = (props) => {
  const [user, setUser] = useState({ ...props });
  const [userProgress, setUserProgress] = useState([]);
  const [userGoal, setUserGoal] = useState({});
  const [currentWeight, setCurrentWeight] = useState();
  const [startingWeight, setStartingWeight] = useState();

  useEffect(() => {
    setUser(props.user);
    setUserProgress(props.userProgress);
    setUserGoal(props.user.userGoal);
    setCurrentWeight(props.currentWeight);
    setStartingWeight(props.startingWeight);
  }, [props.user]);

  function isWhatPercentOf(numA, numB) {
    return (numA / numB) * 100;
  }

  return (
    <div className="featured">
      <div className="top">
        <h1 className="title">Weight changes</h1>
        <Button
          onClick={() =>
            console.log(
              isWhatPercentOf(
                currentWeight - startingWeight,
                userGoal.goalWeight - startingWeight
              )
            )
          }
        >
          asd
        </Button>
        <MoreVertIcon fontSize="small" />
      </div>
      <div className="bottom">
        <p className="title">How close you are for achieving your goal</p>
        {/* isWhatPercentOf(currentWeight-startingWeight,
        userGoal.goalWeight-startingWeight); */}
        <div className="featuredChart">
          <CircularProgressbar
            value={isWhatPercentOf(
              props.currentWeight - startingWeight,
              userGoal && userGoal.goalWeight - startingWeight
            )}
            text={`${Math.trunc(
              isWhatPercentOf(
                props.currentWeight - startingWeight,
                userGoal && userGoal.goalWeight - startingWeight
              )
            )}%`}
            strokeWidth={5}
          />
        </div>
        <p className="amount">
          {userGoal && userGoal.goalWeight - props.currentWeight} more kilograms to
          go!
        </p>
        <p className="desc">Your weight then versus now. You got this !</p>
        <div className="summary">
          <div className="item">
            <div className="itemTitle">Starting weight</div>
            <div className="itemResult negative">
              <KeyboardArrowDownIcon fontSize="small" />
              <div className="resultAmount">{startingWeight}</div>
            </div>
          </div>
          <div className="item">
            <div className="itemTitle">Current Weight</div>
            <div className="itemResult positive">
              <KeyboardArrowUpOutlinedIcon fontSize="small" />
              <div className="resultAmount">{props.currentWeight}</div>
            </div>
          </div>
          <div className="item">
            <div className="itemTitle">Goal weight</div>
            <div className="itemResult positive">
              <KeyboardArrowUpOutlinedIcon fontSize="small" />
              <div className="resultAmount">
                {userGoal && userGoal.goalWeight}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Featured;
