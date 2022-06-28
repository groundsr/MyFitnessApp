import * as React from "react";
import "./dashboardcard.scss";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import { useState } from "react";
import Pie from "../pie/Pie";
import Button from "@mui/material/Button";
import { Box } from "@mui/system";
import axios from "axios";
import ModeEditIcon from "@mui/icons-material/ModeEdit";
import ThumbUpAltIcon from "@mui/icons-material/ThumbUpAlt";
import ThumbDownAltIcon from "@mui/icons-material/ThumbDownAlt";
import { Link } from "react-router-dom";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import { useEffect } from "react";

const DashboardCard = (props) => {
  const [open, setOpen] = useState(false);
  const [id, setId] = useState();
  const [user, setUser] = useState({ ...props.user });
  const [userProgress, setUserProgress] = useState({});
  const [userGoal, setUserGoal] = useState({});
  const [userPlan, setUserPlan] = useState({});
  const [currentWeight, setCurrentWeight] = useState();
  const url = "https://localhost:44325/users/get";

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const updateBodyweight = async () => {
    await axios
      .post(
        `https://localhost:44325/Users/setWeight/${id}?weight=${currentWeight}`
      )
      .then((response) => {
        console.log(response.data.userProgresses);
        console.log(response.data);
        setCurrentWeight(response.data.userProgresses.at(-1).currentWeight);
        props.setUser((prevUser) => ({ ...prevUser, ...response.data }));
        props.setCurrentWeight(
          response.data.userProgresses.at(-1).currentWeight
        );
      });
    handleClose();
  };

  useEffect(() => {
    setUser(props.user);
    setUserGoal(props.user.userGoal);
    console.log(props.user.userGoal);
    setUserPlan(props.userGoal ? props.userGoal.userPlan : console.log("loading"));
    setUserProgress(props.userProgress);
    setCurrentWeight(props.currentWeight);
  }, [props.user]);

  return (
    <>
      <div className="dashboardContainer">
        <Grid container spacing={2}>
          <Grid item className="left" xs={9}>
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
              <Button onClick={() => console.log(userPlan)}>asd</Button>
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
                <Grid sx={{ marginLeft: 2 }} item xs>
                  <img
                    src="https://corestrengthblog.files.wordpress.com/2013/04/fitman.png"
                    alt=""
                  />
                </Grid>
                <Grid item xs={7}>
                  <div className="upperHalf">
                    <div className="Remaining">
                      Calories remaining:
                      <div className="Calories">{userPlan && userPlan.totalCalories}</div>
                      <div className="Calories"></div>
                    </div>
                    <div className="buttons">
                      <Link to="/food/add" style={{ textDecoration: "none" }}>
                        <div className="button">
                          <Button color="secondary" variant="outlined">
                            Add food
                          </Button>
                        </div>
                      </Link>
                      <Link
                        to="/exercise/add"
                        style={{ textDecoration: "none" }}
                      >
                        <div className="button">
                          <Button color="secondary" variant="outlined">
                            Add exercise
                          </Button>
                        </div>
                      </Link>
                    </div>
                  </div>
                  <hr></hr>
                  <div className="lowerHalf">
                    <Grid container className="count" spacing={2}>
                      <Grid item className="countItem" xs={2}>
                      {userPlan && userPlan.totalCalories}
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
          </Grid>
          <Grid item className="right" xs={3}>
            <Paper
              sx={{
                p: 2,
                height: "89%",
                alignItems: "center",
                flexGrow: 1,
                boxShadow: 1,
                backgroundColor: (theme) =>
                  theme.palette.mode === "dark" ? "#1A2027" : "#fff",
              }}
            >
              <div className="topInfo">Information</div>
              <Button onClick={() => console.log(user.bmi)}>asd</Button>
              <div className="middleInfo">
                <div className="bmi">
                  Current BMI : <span>{user.bmi}</span>
                  <span>
                    {user.bmi > 25 || user.bmi < 18 ? (
                      <ThumbDownAltIcon className="icon" />
                    ) : (
                      <ThumbUpAltIcon className="icon" />
                    )}
                    {/* <ThumbUpAltIcon className="icon" /> */}
                  </span>
                </div>
                <div className="bw">
                  Current bodyweight : <span> {props.currentWeight}kg</span>
                  <span>
                    <ModeEditIcon
                      onClick={handleClickOpen}
                      className="editIcon"
                    />
                  </span>
                  <Dialog type="form" open={open} onClose={handleClose}>
                    <DialogTitle>Edit your current bodyweight</DialogTitle>
                    <DialogContent>
                      <TextField
                        onChange={(e) => setCurrentWeight(e.target.value)}
                        autoFocus
                        defaultValue={props.currentWeight}
                        margin="dense"
                        id="currentWeight"
                        label="Current weight"
                        type="string"
                        fullWidth
                        variant="outlined"
                      />
                    </DialogContent>
                    <DialogActions>
                      <Button onClick={handleClose}>Cancel</Button>
                      <Button onClick={updateBodyweight}>Edit</Button>
                    </DialogActions>
                  </Dialog>
                </div>
              </div>
              <div className="bottomInfo">
                <div className="amount">Body type based on your BMI</div>
                <div className="desc">
                  BMI is not reliable for children, elderly adults or pregnant
                  women!
                </div>
                <div className="summary">
                  <div className="item">
                    <div className="itemTitle">Underweight</div>
                    <div className="itemResult positive">
                      <div className="resultAmount">Less than 18</div>
                    </div>
                  </div>
                  <div className="item">
                    <div className="itemTitle">Normal</div>
                    <div className="itemResult positive">
                      <div className="resultAmount">18-25</div>
                    </div>
                  </div>
                  <div className="item">
                    <div className="itemTitle">Overweight</div>
                    <div className="itemResult positive">
                      <div className="resultAmount">More than 25</div>
                    </div>
                  </div>
                </div>
              </div>
            </Paper>
          </Grid>
        </Grid>
      </div>
    </>
  );
};

export default DashboardCard;
