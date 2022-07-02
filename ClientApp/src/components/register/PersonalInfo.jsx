import { Button, Stack } from "@mui/material";
import { Link } from "react-router-dom";
import * as React from "react";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import "./Welcome.scss";
import Radio from "@mui/material/Radio";
import RadioGroup from "@mui/material/RadioGroup";
import FormControlLabel from "@mui/material/FormControlLabel";
import FormControl from "@mui/material/FormControl";
import { DesktopDatePicker } from "@mui/x-date-pickers/DesktopDatePicker";
import TextField from "@mui/material/TextField";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";

const theme = createTheme();

const PersonalInfo = (props) => {
  const [value, setValue] = React.useState(new Date("2000-01-01:11:54"));
  console.log(props);

  const handleChange = (newValue) => {
    setValue(newValue);
    props.setBirthday(newValue);
  };

  return (
    <ThemeProvider theme={theme}>
      <Container maxWidth="sm">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 12,
            bgcolor: "background.paper",
            boxShadow: 3,
            borderRadius: 2,
            p: 6,
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
            textAlign: "center",
            border: "2px",
          }}
        >
          <div className="personalText">Please select your sex</div>
          <Button onClick={() => console.log(props.sex)}>asd</Button>
          <FormControl>
            <RadioGroup
              row
              aria-labelledby="demo-row-radio-buttons-group-label"
              name="row-radio-buttons-group"
            >
              <FormControlLabel
                value="female"
                control={<Radio />}
                onChange={() => props.setSex("F")}
                label="Female"
              />
              <FormControlLabel
                value="male"
                control={<Radio />}
                label="Male"
                onChange={() => props.setSex("M")}
              />
            </RadioGroup>
          </FormControl>
          <div className="personalText">When were you born?</div>
          <LocalizationProvider dateAdapter={AdapterDateFns}>
            <DesktopDatePicker
              label="MM/dd/yyyy"
              inputFormat="MM/dd/yyyy"
              value={value}
              onChange={handleChange}
              renderInput={(params) => <TextField {...params} />}
            />
          </LocalizationProvider>
          <div className="personalText">How tall are you?</div>
          <TextField
            id="outlined-required"
            onChange={(e) => props.setHeight(e.target.value)}
            label="Height"
          />
          <div className="personalText">How much do you weigh?</div>
          <TextField
            id="outlined-required"
            onChange={(e) => props.setWeight(e.target.value)}
            label="Current weight"
          />
          <div className="personalText">What's your goal weight?</div>
          <TextField
            id="outlined-required"
            onChange={(e) => props.setKilosGoal(e.target.value)}
            label="Goal weight"
          />
          <Stack
            spacing={2}
            direction="row"
            sx={{
              display: "flex",
              alignItems: "center",
              justifyContent: "center",
            }}
          >
            <Link
              to="/account/activity-level"
              style={{ textDecoration: "none" }}
            >
              <Button sx={{ mt: 2 }} variant="outlined" color="secondary">
                Back
              </Button>
            </Link>
            <Link to="/account/register" style={{ textDecoration: "none" }}>
              <Button sx={{ mt: 2 }} variant="contained" color="secondary">
                Next
              </Button>
            </Link>
          </Stack>
        </Box>
      </Container>
    </ThemeProvider>
  );
};

export default PersonalInfo;
