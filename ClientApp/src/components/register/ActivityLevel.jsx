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

const theme = createTheme();

const ActivityLevel = () => {
  const [selectedIndex, setSelectedIndex] = React.useState(1);

  const handleListItemClick = (event, index) => {
    setSelectedIndex(index);
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
            alignItems: "center",
            justifyContent: "center",
            textAlign: "center",
            border: "2px",
          }}
        >
          <div className="text">What is your baseline activity level?</div>
          <List>
            <ListItem disablePadding>
              <ListItemButton
                selected={selectedIndex === 0}
                onClick={(event) => handleListItemClick(event, 0)}
              >
                <ListItemText primary="Not Very Active" secondary="Spend most of the day sitting" />
              </ListItemButton>
            </ListItem>
            <ListItem disablePadding>
              <ListItemButton
                selected={selectedIndex === 1}
                onClick={(event) => handleListItemClick(event, 1)}
              >
                <ListItemText primary="Lightly Active" secondary="Spend a good part of the day on your feet"/>
              </ListItemButton>
            </ListItem>
            <ListItem disablePadding>
              <ListItemButton
                selected={selectedIndex === 2}
                onClick={(event) => handleListItemClick(event, 2)}
              >
                <ListItemText primary="Active" secondary="Spend a good part of the day doing some physical activity"/>
              </ListItemButton>
            </ListItem>
            <ListItem disablePadding>
              <ListItemButton
                selected={selectedIndex === 3}
                onClick={(event) => handleListItemClick(event, 3)}
              >
                <ListItemText primary="Very Active" secondary="Spend a good part of the day doing heavy physical activity"/>
              </ListItemButton>
            </ListItem>
          </List>
          <Stack spacing={2} direction="row">
            <Link to="/account/goals" style={{ textDecoration: "none" }}>
              <Button sx={{ mt: 2 }} variant="outlined" color="secondary">
                Back
              </Button>
            </Link>
            <Link to="/account/personalinfo" style={{ textDecoration: "none" }}>
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

export default ActivityLevel;
