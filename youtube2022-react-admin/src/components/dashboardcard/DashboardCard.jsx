import * as React from "react";
import "./dashboardcard.scss";
import { styled } from "@mui/material/styles";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import { useState } from "react";
import Pie from "../pie/Pie";
import Button from "@mui/material/Button";
import axios from "axios";
import Progress from "react-circle-progress-bar";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import ButtonBase from "@mui/material/ButtonBase";

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#fff",
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: "center",
  color: theme.palette.text.secondary,
}));

const DashboardCard = () => {
  const [random, setRandom] = useState({
    percentage: 0,
    colour: "hsl(0, 0%, 0%)",
  });

  const generateRandomValues = () => {
    const rand = (n) => Math.random() * n;
    setRandom({
      percentage: rand(100),
      colour: `hsl(${rand(360)}, ${rand(50) + 50}%, ${rand(30) + 20}%)`,
    });
  };

  const url = 'https://localhost:44325/weatherforecast';

  const getData = () => {
    axios.get(`${url}`)
    .then((response) =>{
      const data = response.data[0].temperatureC;
      console.log(data);
    })
    .catch(error => console.error(`Error: ${error}`));
  }

  React.useEffect(() => {
    getData();
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
          <img src="https://media.istockphoto.com/photos/cheers-picture-id504402647?k=20&m=504402647&s=612x612&w=0&h=Vw_QpmzOYi1Z3dBznff-S66btru0G9VOXcJI5TPRNrI=" />
        </Grid>
        <Grid item xs={7}>
          <div className="upperHalf">
            <div className="Remaining">
              Calories remaining:
              <div className="Calories">2500</div>
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
          <div class="lowerHalf">
            <Grid container className="count" spacing={2}>
              <Grid item className="countItem" xs={2}>
                2710
                <span className="span">Goal</span>
              </Grid>
              <span class="vl"></span>
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
