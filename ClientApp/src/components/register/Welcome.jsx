import { Button } from "@mui/material";
import { Link } from "react-router-dom";
import * as React from "react";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import "./Welcome.scss";

const theme = createTheme();

const Welcome = () => {
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
          <div className="text">
            Welcome! Just a few quick questions so we can customize MyFitnessPal
            for you.
          </div>
          <Link to="/account/goals" style={{ textDecoration: "none" }}>
            <Button sx={{ mt: 2}} variant="contained" color="secondary">Continue</Button>
          </Link>
        </Box>
      </Container>
    </ThemeProvider>
  );
};

export default Welcome;
