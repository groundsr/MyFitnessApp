import * as React from "react";
import "./dashboardcard.scss";
import { styled } from "@mui/material/styles";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import { useState } from "react";
import Pie from "../pie/Pie";
import Button from "@mui/material/Button";
import axios from "axios";

const DashboardCard = () => {
  const [user, setUser] = useState({});
  const [userGoal, setUserGoal] = useState({});
  const [userPlan, setUserPlan] = useState({});
  const url = "https://localhost:44325/users/get";
  const url2 = "https://localhost:44325/usergoals/get";
  const url3 = "https://localhost:44325/userplans/get";

  const getUserData = () => {
    axios
      .get(`${url}`)
      .then((response) => {
        const data = response.data[0];
        setUser(data);
        console.log(data);
        setUserGoal(data.userGoal);
        setUserPlan(data.userGoal.userPlan);
      })
      .catch((error) => console.error(`Error: ${error}`));
  };

  React.useEffect(() => {
    getUserData();
  }, []);

  return (
      <Paper
        sx={{
          p: 2,
          margin: "auto",
          marginTop: 4,
          maxWidth: 1200,
          flexGrow: 1,
          backgroundColor: (theme) =>
            theme.palette.mode === "dark" ? "#1A2027" : "#fff",
        }}
      >
        <Grid container spacing={2}>
          <Grid item xs>
            <img src="https://corestrengthblog.files.wordpress.com/2013/04/fitman.png" />
          </Grid>
          <Grid item xs={7}>
            <div className="upperHalf">
              <div className="Remaining">
                Calories remaining:
                <div className="Calories">{userPlan.totalCalories}</div>
              </div>
              <div className="buttons">
                <div className="button">
                  <Button color="success" variant="outlined">
                    Add food
                  </Button>
                </div>
                <div className="button">
                  <Button variant="outlined" color="success">
                    Add exercise
                  </Button>
                </div>
              </div>
            </div>
            <hr></hr>
            <div className="lowerHalf">
              <Grid container className="count" spacing={2}>
                <Grid item className="countItem" xs={2}>
                  2710
                  <span className="span">Goal</span>
                </Grid>
                <span className="vl"></span>
                <Grid item xs={2}>
                  210 <div>Food</div>
                </Grid>
                <Grid item xs={1}>
                  -
                </Grid>
                <Grid item xs={2}>
                  <div>Exercise</div>
                </Grid>
                <Grid item xs={1}>
                  =
                </Grid>
                <Grid item xs={2}>
                  210 <div>Net</div>
                </Grid>
              </Grid>
            </div>
          </Grid>
          <Grid item xs>
            <Pie percentage={85} colour="green" />
          </Grid>
        </Grid>
      </Paper>
  );
};

export default DashboardCard;
