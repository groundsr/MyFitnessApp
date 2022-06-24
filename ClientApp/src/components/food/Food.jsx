import React from "react";
import "./food.scss";
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
import { purple } from "@mui/material/colors";
import { Button } from "@mui/material";
import axios from "axios";
import { useEffect } from "react";

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: "rgb(35, 7, 56)",
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
  const [diaries, setDiaries] = useState([]);
  const [todayDiary, setTodayDiary] = useState({});
  const [lunch, setLunch] = useState({});
  const [lunchMeals, setLunchMeals] = useState([]);
  const [breakfast, setBreakfast] = useState({});
  const [breakfastMeals, setBreakfastMeals] = useState([]);
  const [dinner, setDinner] = useState({});
  const [dinnerMeals, setDinnerMeals] = useState([]);
  let breakfastMenu;
  let dinnerMenu;
  let lunchMenu;

  const createData = (name, calories, fat, carbs, protein) => {
    return { name, calories, fat, carbs, protein };
  };

  const getdiary = () => {
    console.log(todayDiary);
    console.log(lunch);
    console.log(lunchMeals);
  };

  function getFormattedDate(date) {
    let year = date.getFullYear();
    let month = (1 + date.getMonth()).toString().padStart(2, "0");
    let day = date.getDate().toString().padStart(2, "0");

    return month + "/" + day + "/" + year;
  }

  const getDiaries = async () => {
    await axios.get("https://localhost:44325/diary/get").then((response) => {
      setDiaries(response.data);
    });
  };

  const getTodayDiary = () => {
    diaries.map((diary) => {
      var creationDate = getFormattedDate(new Date(diary.creationDate));
      var currentDate = getFormattedDate(new Date());
      if (creationDate == currentDate) {
        setTodayDiary(diary);
        console.log("equal", diary);
        setLunch(diary.lunch);
        setLunchMeals(diary.lunch.meals);
        setDinner(diary.dinner);
        setDinnerMeals(diary.dinner.meals);
        setBreakfast(diary.breakfast);
        setBreakfastMeals(diary.breakfast.meals);
      } else {
        console.log("not equal");
      }
    });
  };

  useEffect(() => {
    getDiaries();
  }, []);

  useEffect(() => {
    getTodayDiary();
  }, [diaries]);

  const meals = ["Breakfast", "Lunch", "Dinner"];

  const ColorButton = styled(Button)(({ theme }) => ({
    color: theme.palette.getContrastText(purple[500]),
    backgroundColor: purple[700],
    "&:hover": {
      backgroundColor: purple[900],
    },
  }));

  breakfastMenu = (
    <>
      {breakfastMeals.map((row) => (
        <StyledTableRow
          key={row.name}
          sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
        >
          <StyledTableCell component="th" scope="row">
            {row.name}
          </StyledTableCell>
          <StyledTableCell align="right">{row.calories}</StyledTableCell>
          <StyledTableCell align="right">{row.fat}</StyledTableCell>
          <StyledTableCell align="right">{row.carbohydrates}</StyledTableCell>
          <StyledTableCell align="right">{row.protein}</StyledTableCell>
        </StyledTableRow>
      ))}
    </>
  );
  lunchMenu = (
    <>
      {lunchMeals.map((row) => (
        <StyledTableRow
          key={row.name}
          sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
        >
          <StyledTableCell component="th" scope="row">
            {row.name}
          </StyledTableCell>
          <StyledTableCell align="right">{row.calories}</StyledTableCell>
          <StyledTableCell align="right">{row.fat}</StyledTableCell>
          <StyledTableCell align="right">{row.carbohydrates}</StyledTableCell>
          <StyledTableCell align="right">{row.protein}</StyledTableCell>
        </StyledTableRow>
      ))}
    </>
  );
  dinnerMenu = (
    <>
      {dinnerMeals.map((row) => (
        <StyledTableRow
          key={row.name}
          sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
        >
          <StyledTableCell component="th" scope="row">
            {row.name}
          </StyledTableCell>
          <StyledTableCell align="right">{row.calories}</StyledTableCell>
          <StyledTableCell align="right">{row.fat}</StyledTableCell>
          <StyledTableCell align="right">{row.carbohydrates}</StyledTableCell>
          <StyledTableCell align="right">{row.protein}</StyledTableCell>
        </StyledTableRow>
      ))}
    </>
  );

  return (
    <>
      <div className="tableContainer">
        <div className="foodTitle">
          <div style={{ display: "flex" }}>
            Your food Diary for :
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
            {/* <ColorButton onClick={getdiary} sx={{ mr: 3 }}>
              diary
            </ColorButton> */}
            <Link style={{ textDecoration: "none" }} to="/food/add">
              <ColorButton variant="contained" color="secondary">
                Add food
              </ColorButton>
            </Link>
          </div>
        </div>
        <TableContainer
          className="topMeal"
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
                <StyledTableCell className="mealTitle">
                  Breakfast{" "}
                </StyledTableCell>
                <StyledTableCell align="right">Calories</StyledTableCell>
                <StyledTableCell align="right">Fat&nbsp;(g)</StyledTableCell>
                <StyledTableCell align="right">Carbs&nbsp;(g)</StyledTableCell>
                <StyledTableCell align="right">
                  Protein&nbsp;(g)
                </StyledTableCell>
              </TableRow>
            </TableHead>
            <TableBody>{breakfastMenu}</TableBody>
          </Table>
        </TableContainer>
        <TableContainer
          className="topMeal"
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
                <StyledTableCell className="mealTitle">
                  Lunch{" "}
                </StyledTableCell>
                <StyledTableCell align="right">Calories</StyledTableCell>
                <StyledTableCell align="right">Fat&nbsp;(g)</StyledTableCell>
                <StyledTableCell align="right">Carbs&nbsp;(g)</StyledTableCell>
                <StyledTableCell align="right">
                  Protein&nbsp;(g)
                </StyledTableCell>
              </TableRow>
            </TableHead>
            <TableBody>{lunchMenu}</TableBody>
          </Table>
        </TableContainer>
        <TableContainer
          className="topMeal"
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
                <StyledTableCell className="mealTitle">
                  Dinner{" "}
                </StyledTableCell>
                <StyledTableCell align="right">Calories</StyledTableCell>
                <StyledTableCell align="right">Fat&nbsp;(g)</StyledTableCell>
                <StyledTableCell align="right">Carbs&nbsp;(g)</StyledTableCell>
                <StyledTableCell align="right">
                  Protein&nbsp;(g)
                </StyledTableCell>
              </TableRow>
            </TableHead>
            <TableBody>{dinnerMenu}</TableBody>
          </Table>
        </TableContainer>
      </div>
    </>
  );
};

export default Food;
