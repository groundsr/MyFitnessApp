import React from "react";
import "./exercise.scss";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { DesktopDatePicker } from "@mui/x-date-pickers/DesktopDatePicker";
import { TextField } from "@material-ui/core";
import { useState } from "react";
import { styled } from "@mui/material/styles";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { Link } from "react-router-dom";
import { Button } from "@mui/material";
import { purple } from '@mui/material/colors';

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));

const Food = () => {
  const [value, setValue] = useState(new Date());

  const createData = (name, minutes, caloriesBurned) => {
    return { name, minutes, caloriesBurned };
  };

  const rows = [
    createData("Walking, 10.5 mins per km", 60, 480),
    createData("Running", 60, 900),
  ];

  const exercises = ["Cardiovascular", "Strength"];

  const ColorButton = styled(Button)(({ theme }) => ({
    color: theme.palette.getContrastText(purple[500]),
    backgroundColor: purple[700],
    '&:hover': {
      backgroundColor: purple[900],
    },
  }));

  return (
    <>
      <div className="tableContainer">
        <div className="exerciseTitle">
          <div style={{display: 'flex'}}>Your exercise Diary for : 
              <div className="date">
              <LocalizationProvider dateAdapter={AdapterDateFns}>
              <DesktopDatePicker
                label="Today"
                value={value}
                minDate={new Date("2017-01-01")}
                onChange={(newValue) => {
                  setValue(newValue);
                }}
                renderInput={(params) => <TextField {...params} />}
              />
            </LocalizationProvider>
              </div>
          </div>
          <div className="date">
            {/* <LocalizationProvider dateAdapter={AdapterDateFns}>
              <DesktopDatePicker
                label="Today"
                value={value}
                minDate={new Date("2017-01-01")}
                onChange={(newValue) => {
                  setValue(newValue);
                }}
                renderInput={(params) => <TextField {...params} />}
              />
            </LocalizationProvider> */}
            <Link style={{ textDecoration: "none" }} to="/exercise/add">
              <ColorButton variant="contained" color="secondary">Add exercise</ColorButton>
            </Link>
          </div>
          
        </div>
        {exercises.map((exercise) => (
          <TableContainer
            key={exercise}
            className="topExercise"
            sx={{ maxWidth: 1500 }}
            component={Paper}
          >
            <Table
              sx={{ minWidth: 600 }}
              size="small"
              aria-label="customized table"
            >
              <TableHead>
                <TableRow>
                  <StyledTableCell>{exercise} </StyledTableCell>
                  <StyledTableCell align="right">Minutes</StyledTableCell>
                  <StyledTableCell align="right">
                    Calories Burned
                  </StyledTableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {rows.map((row) => (
                  <StyledTableRow
                    key={row.name}
                    sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                  >
                    <StyledTableCell component="th" scope="row">
                      {row.name}
                    </StyledTableCell>
                    <StyledTableCell align="right">
                      {row.minutes}
                    </StyledTableCell>
                    <StyledTableCell align="right">
                      {row.caloriesBurned}
                    </StyledTableCell>
                  </StyledTableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        ))}
      </div>
    </>
  );
};

export default Food;
