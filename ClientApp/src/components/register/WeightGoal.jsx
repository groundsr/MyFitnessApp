import { Button, Stack } from "@mui/material";
import { Link } from "react-router-dom";
import * as React from "react";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import "./Welcome.scss";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";
import { useState } from "react";

const theme = createTheme();

const WeightGoal = (props) => {
  console.log(props);
  const [selectedIndex, setSelectedIndex] = useState(1);
  // const [weightGoal, setWeightGoal] = useState();

  const handleListItemClick = (event, index) => {
    setSelectedIndex(index);
  };
  return (
    <ThemeProvider theme={theme}>
      <Container maxWidth="xs">
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
            alignItems: "center",
            justifyContent: "center",
            textAlign: "center",
            border: "2px",
          }}
        >
          <div className="text">What is your weight goal?</div>
        <Button onClick={() => console.log(props.weightGoal)}>aasd</Button>

          <List>
            <ListItem disablePadding>
              <ListItemButton
                selected={selectedIndex === 0}
                onClick={(event) => {
                  handleListItemClick(event, 0);
                  props.setWeightGoal("Cut");
                }}
              >
                <ListItemText primary="Lose weight" />
              </ListItemButton>
            </ListItem>
            <ListItem disablePadding>
              <ListItemButton
                selected={selectedIndex === 1}
                onClick={(event) => {
                  handleListItemClick(event, 1);
                  props.setWeightGoal("Maintain");
                }}
              >
                <ListItemText primary="Maintain weight" />
              </ListItemButton>
            </ListItem>
            <ListItem disablePadding>
              <ListItemButton
                selected={selectedIndex === 2}
                onClick={(event) => {
                  handleListItemClick(event, 2);
                  props.setWeightGoal("Gain");
                }}
              >
                <ListItemText primary="Gain weight" />
              </ListItemButton>
            </ListItem>
          </List>
          <Stack spacing={2} direction="row">
            <Link to="/account" style={{ textDecoration: "none" }}>
              <Button sx={{ mt: 2 }} variant="outlined" color="secondary">
                Back
              </Button>
            </Link>
            <Link
              to="/account/activity-level"
              style={{ textDecoration: "none" }}
            >
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

export default WeightGoal;
