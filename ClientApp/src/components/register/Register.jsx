import * as React from "react";
import { useState, useRef } from "react";
import { Navigate } from "react-router-dom";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import axios from "axios";
import { useEffect } from "react";
import { useStateWithCallback } from "./useStateWithCallback";

function Copyright(props) {
  return (
    <Typography
      variant="body2"
      color="text.secondary"
      align="center"
      {...props}
    >
      {"Copyright © "}
      <Link color="inherit" href="https://mui.com/">
        Your Website
      </Link>{" "}
      {new Date().getFullYear()}
      {"."}
    </Typography>
  );
}

const theme = createTheme();

const SignUp = (props) => {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [redirect, setRedirect] = useState(false);
  const [weightGoal, setWeightGoal] = useState();
  const [userActivity, setUserActivity] = useState();
  const [sex, setSex] = useState("");
  const [birthday, setBirthday] = useState(new Date());
  const [height, setHeight] = useState(1);
  const [weight, setWeight] = useState(1);
  const [kilosGoal, setKilosGoal] = useState(1);
  const [age, setAge] = useState(1);
  const [totalCalories, setTotalCalories] = useState();
  const [protein, setProtein] = useState();
  const [fat, setFat] = useState();
  const [carbs, setCarbs] = useState();
  const [bmi, setBmi] = useState();
  const [basalMetabolicRate, setBasalMetabolicRate] = useState();
  const [tdee, setTdee] = useState();
  const [goalInt, setGoalInt] = useState();
  const [activityInt, setActivityInt] = useState();
  const [userPlan, setUserPlan] = useState({});
  const [userPlanId, setUserPlanId] = useState(1);
  const [userGoal, setUserGoal] = useState({});
  const [userGoalId, setUserGoalId] = useState(1);

  React.useEffect(() => {
    setWeightGoal(props.weightGoal);
    setUserActivity(props.userActivity);
    setSex(props.sex);
    setBirthday(props.birthday);
    setHeight(props.height);
    setWeight(props.weight);
    setKilosGoal(props.kilosGoal);
    setAge(getAge(props.birthday));
  }, [
    props.weightGoal,
    props.userActivity,
    props.sex,
    props.birthday,
    props.height,
    props.weight,
    props.kilosGoal,
  ]);

  useEffect(() => {
    setBasalMetabolicRate(
      66 + 13.7 * weight + 5 * height - 6.8 * getAge(birthday)
    );

    if (userActivity == "VeryActive") {
      setTdee(basalMetabolicRate * 1.75);
    } else if (userActivity == "Active") {
      setTdee(basalMetabolicRate * 1.55);
    } else if (userActivity == "LightlyActive") {
      setTdee(basalMetabolicRate * 1.375);
    } else if (userActivity == "Sedentary") {
      setTdee(basalMetabolicRate * 1.2);
    }

    if (weightGoal == "Gain") {
      setGoalInt(1);
    } else if (weightGoal == "Cut") {
      setGoalInt(2);
    } else {
      setGoalInt(0);
    }

    if (userActivity == "VeryActive") {
      setActivityInt(0);
    } else if (userActivity == "Active") {
      setActivityInt(1);
    } else if (userActivity == "LightlyActive") {
      setActivityInt(2);
    } else {
      setActivityInt(3);
    }
  }, [
    age,
    weight,
    height,
    birthday,
    basalMetabolicRate,
    weightGoal,
    userActivity,
  ]);

  useEffect(() => {
    if (weightGoal == "Gain") {
      if (sex == "M") {
        setTotalCalories(tdee + 500);
        setProtein(weight * 1.8);
        setFat(weight * 0.8);
        setCarbs((tdee + 500 - (weight * 1.8 * 4 + weight * 0.8 * 9)) / 4);
      } else {
        setTotalCalories(tdee + 250);
        setProtein(weight * 1.8);
        setFat(weight * 0.8);
        setCarbs((tdee + 250 - (weight * 1.8 * 4 + weight * 0.8 * 9)) / 4);
      }
    }
    if (weightGoal == "Cut") {
      if (sex == "M") {
        setTotalCalories(0.9 * tdee);
        setProtein(weight * 1.8);
        setFat(weight * 0.8);
        setCarbs((tdee * 0.9 - (weight * 1.8 * 4 + weight * 0.8 * 9)) / 4);
      } else {
        setTotalCalories(0.75 * tdee);
        setProtein(weight * 1.8);
        setFat(weight * 0.8);
        setCarbs((tdee * 0.75 - (weight * 1.8 * 4 + weight * 0.8 * 9)) / 4);
      }
    }
    if (weightGoal == "Maintain") {
      if (sex == "M") {
        console.log(tdee);
        setTotalCalories(tdee + 200);
        setProtein(weight * 1.8);
        setFat(weight * 0.8);
        setCarbs((tdee + 200 - (weight * 1.8 * 4 + weight * 0.8 * 9)) / 4);
      } else {
        setTotalCalories(tdee);
        setProtein(weight * 1.8);
        setFat(weight * 0.8);
        setCarbs((tdee - (weight * 1.8 * 4 + weight * 0.8 * 9)) / 4);
      }
    }
    if ((tdee - (weight * 1.8 * 4 + weight * 0.8 * 9)) / 4 < 0) {
      setTotalCalories(
        tdee + (-(tdee - (weight * 1.8 * 4 + weight * 0.8 * 9)) / 4) * 4 + 400
      );
      setCarbs(100);
    }
    setBmi(parseInt((weight / ((height / 100) * (height / 100))).toFixed(1)));
  }, [tdee, userPlanId]);

  function getAge(dateString) {
    var today = new Date();
    var birthDate = new Date(dateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }
    return age;
  }

  useEffect(() => {
    console.log("plan id", userPlanId);
    if (userPlanId !== 1) {
      console.log(userPlanId);
      axios
        .post("https://localhost:44325/UserGoals/create", {
          Goal: goalInt,
          GoalWeight: kilosGoal,
          UserActivity: activityInt,
          UserPlanId: userPlanId,
        })

        .then((response) => {
          setUserGoal(response.data);
          setUserGoalId(response.data.id);
        });
    }
  }, [userPlanId]);

  useEffect(() => {
    console.log("goal id", userGoalId);
    if (userGoalId !== 1) {
      axios
        .post("https://localhost:44325/api/register", {
          Name: name,
          Email: email,
          Password: password,
          Birthday: birthday,
          Sex: sex,
          Height: height,
          Weight: weight,
          UserGoalId: userGoalId,
          Bmi: bmi,
        })
        .then((response) => {
          if (response.status == 201) {
            console.log("SUCCESS");
            setRedirect(true);
          } else {
            alert("user could not be created");
          }
        });
    }
  }, [userGoalId, totalCalories]);

  const handleSubmit = async (event) => {
    event.preventDefault();
    const resp = await axios
      .post("https://localhost:44325/UserPlans/create", {
        bmi: bmi,
        totalCalories: parseInt(totalCalories),
        totalCarbs: parseInt(carbs),
        totalProtein: parseInt(protein),
        totalFat: parseInt(fat),
      })
      .then((response) => {
        console.log(response.data);
        setUserPlan(response.data);
        setUserPlanId(response.data.id);
      })
      .catch((error) => {
        console.log(error.response.data);
      });
  };

  if (redirect) {
    return <Navigate to="/login" />;
  }

  return (
    <ThemeProvider theme={theme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Sign up
          </Typography>
          <Button onClick={() => console.log(totalCalories)}>total</Button>
          <Button onClick={() => console.log(weight)}>weight</Button>
          <Button onClick={() => console.log(carbs)}>carbs</Button>
          <Button onClick={() => console.log(height)}>height</Button>
          <Button onClick={() => console.log(sex)}>sex</Button>
          <Button onClick={() => console.log(tdee)}>tdee</Button>
          <Button onClick={() => console.log(basalMetabolicRate)}>basal</Button>
          <Button onClick={handleSubmit}>submit</Button>

          <Box
            component="form"
            noValidate
            onSubmit={handleSubmit}
            sx={{ mt: 3 }}
          >
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  id="name"
                  label="Name"
                  name="name"
                  autoComplete="family-name"
                  onChange={(e) => setName(e.target.value)}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  id="email"
                  label="Email Address"
                  name="email"
                  autoComplete="email"
                  onChange={(e) => setEmail(e.target.value)}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  name="password"
                  label="Password"
                  type="password"
                  id="password"
                  autoComplete="new-password"
                  onChange={(e) => setPassword(e.target.value)}
                />
              </Grid>
            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign Up
            </Button>
            <Grid container justifyContent="flex-end">
              <Grid item>
                <Link href="#" variant="body2">
                  Already have an account? Sign in
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
        {/* <Copyright sx={{ mt: 5 }}  */}
      </Container>
    </ThemeProvider>
  );
};

export default SignUp;
