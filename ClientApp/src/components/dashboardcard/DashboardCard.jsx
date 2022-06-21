import * as React from "react";
import "./dashboardcard.scss";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import { useState } from "react";
import Pie from "../pie/Pie";
import Button from "@mui/material/Button";
import { Box } from "@mui/system";
import axios from "axios";

const DashboardCard = () => {
  const [user, setUser] = useState({});
  const [userGoal, setUserGoal] = useState({});
  const [userPlan, setUserPlan] = useState({});
  const url = "https://localhost:44325/users/get";

  const getUserData = () => {
    axios
      .get(`${url}`)
      .then((response) => {
        const data = response.data[0];
        setUser(data);
        setUserGoal(data.userGoal);
        setUserPlan(data.userGoal.userPlan);
      })
      .catch((error) => console.error(`Error: ${error}`));
  };

  React.useEffect(() => {
    getUserData();
  }, []);

  return (
    <>
      <div className="dashboardContainer">
        <Box
          sx={{
            p: 2,
            margin: "auto",
            maxWidth: "95%",
            flexGrow: 1,
            // backgroundColor: 'rgb(50, 167, 225)'
            backgroundColor: "rgb(64, 71, 74)",
          }}
        >
          <div className="title">Your daily summary</div>
        </Box>
        <Paper
          sx={{
            p: 2,
            margin: "auto",
            maxWidth: "95%",
            flexGrow: 1,
            boxShadow: 1,
            backgroundColor: (theme) =>
              theme.palette.mode === "dark" ? "#1A2027" : "#fff",
          }}
        >
          <Grid container>
            <Grid sx={{marginLeft: 2}} item xs>
              <img
                src="https://corestrengthblog.files.wordpress.com/2013/04/fitman.png"
                alt=""
              />
            </Grid>
            <Grid item xs={8}>
              <div className="upperHalf">
                <div className="Remaining">
                  Calories remaining:
                  {/* <div className="Calories">{userPlan.totalCalories}</div> */}
                  <div className="Calories">2710</div>
                </div>
                <div className="buttons">
                  <div className="button">
                    <Button color="secondary" variant="outlined">
                      Add food
                    </Button>
                  </div>
                  <div className="button">
                    <Button color="secondary" variant="outlined">
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
                    0 <div>Food</div>
                  </Grid>
                  <Grid item xs={1}>
                    -
                  </Grid>
                  <Grid item xs={2}>
                    0 <div>Exercise</div>
                  </Grid>
                  <Grid item xs={1}>
                    =
                  </Grid>
                  <Grid item xs={2}>
                    0 <div>Net</div>
                  </Grid>
                </Grid>
              </div>
            </Grid>
            <Grid item xs>
              <Pie percentage={85} colour="blueviolet" />
            </Grid>
          </Grid>
        </Paper>
      </div>
    </>
  );
};

export default DashboardCard;
