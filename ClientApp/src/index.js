import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import { DarkModeContextProvider } from "./context/darkModeContext";

ReactDOM.render(
  <React.Fragment>
    <DarkModeContextProvider>
      <App />
    </DarkModeContextProvider>
  </React.Fragment>,
  document.getElementById("root")
);
