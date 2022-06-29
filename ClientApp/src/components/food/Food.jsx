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
import DeleteIcon from "@mui/icons-material/Delete";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import SettingsSystemDaydreamOutlined from "@mui/icons-material/SettingsSystemDaydreamOutlined";

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

const Food = (props) => {
  const [value, setValue] = useState(new Date());
  const [diaries, setDiaries] = useState([]);
  const [todayDiary, setTodayDiary] = useState({});
  const [lunchMeals, setLunchMeals] = useState([]);
  const [breakfastMeals, setBreakfastMeals] = useState([]);
  const [mealType, setMealType] = useState("");
  const [mealId, setMealId] = useState();
  const [dinnerMeals, setDinnerMeals] = useState([]);
  const [open, setOpen] = React.useState(false);
  let breakfastMenu;
  let dinnerMenu;
  let lunchMenu;

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const getDiaries = async () => {
    await axios.get("https://localhost:44325/diary/get").then((response) => {
      setDiaries(response.data);
      console.log(response.data.at(-1));
      setTodayDiary(response.data.at(-1));
      // props.setTodayDiary(response.data.at(-1));
      setBreakfastMeals(response.data.at(-1).breakfast.breakfastMeals);
      setLunchMeals(response.data.at(-1).lunch.lunchMeals);
      setDinnerMeals(response.data.at(-1).dinner.dinnerMeals);
    });
  };

  const handleDelete = async () => {
    await axios
      .delete(
        `https://localhost:44325/Diary/deleteFoodFromDiary?userid=${props.userId}&MealType=${mealType}&mealId=${mealId}`
      )
      .then((response) => {
        console.log(response);
        setLunchMeals(response.data.lunch.lunchMeals);
        setBreakfastMeals(response.data.breakfast.breakfastMeals);
        setDinnerMeals(response.data.dinner.dinnerMeals);
        handleClose();
      })
      .catch((error) => {
        if (error.response) {
          alert(error.response.data);
        }
      });
  };

  useEffect(() => {
    getDiaries();
  }, []);

  const ColorButton = styled(Button)(({ theme }) => ({
    color: theme.palette.getContrastText(purple[500]),
    backgroundColor: purple[700],
    "&:hover": {
      backgroundColor: purple[900],
    },
  }));

  breakfastMenu = (
    <>
      {breakfastMeals &&
        breakfastMeals.map((row) => (
          <StyledTableRow
            key={row.mealId}
            sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
          >
            <StyledTableCell component="th" scope="row">
              {row.meal.name}
            </StyledTableCell>
            <StyledTableCell align="right">
              {row.actualCalories}
            </StyledTableCell>
            <StyledTableCell align="right">{row.actualFat}</StyledTableCell>
            <StyledTableCell align="right">{row.actualCarbs}</StyledTableCell>
            <StyledTableCell align="right">{row.actualProtein}</StyledTableCell>
            <StyledTableCell align="right">{row.quantity}</StyledTableCell>
            <StyledTableCell align="center">
              <DeleteIcon
                sx={{ cursor: "pointer" }}
                onClick={() => {
                  handleClickOpen();
                  setMealType("Breakfast");
                  setMealId(row.mealId);
                }}
              />
              <Dialog
                open={open}
                onClose={handleClose}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
                BackdropProps={{ style: { backgroundColor: "transparent" } }}
              >
                <DialogContent>
                  Are you sure you want to delete this entry?
                </DialogContent>
                <DialogActions>
                  <Button onClick={handleClose}>Disagree</Button>
                  <Button onClick={handleDelete} autoFocus>
                    Agree
                  </Button>
                </DialogActions>
              </Dialog>
            </StyledTableCell>
          </StyledTableRow>
        ))}
    </>
  );
  lunchMenu = (
    <>
      {lunchMeals &&
        lunchMeals.map((row) => (
          <StyledTableRow
            key={row.mealId}
            sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
          >
            <StyledTableCell component="th" scope="row">
              {row.meal.name}
            </StyledTableCell>
            <StyledTableCell align="right">
              {row.actualCalories}
            </StyledTableCell>
            <StyledTableCell align="right">{row.actualFat}</StyledTableCell>
            <StyledTableCell align="right">{row.actualCarbs}</StyledTableCell>
            <StyledTableCell align="right">{row.actualProtein}</StyledTableCell>
            <StyledTableCell align="right">{row.quantity}</StyledTableCell>
            <StyledTableCell align="center">
              <DeleteIcon
                sx={{ cursor: "pointer" }}
                onClick={() => {
                  handleClickOpen();
                  setMealType("Lunch");
                  setMealId(row.mealId);
                }}
              />
              <Dialog
                open={open}
                onClose={handleClose}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
                BackdropProps={{ style: { backgroundColor: "transparent" } }}
              >
                <DialogContent>
                  Are you sure you want to delete this entry?
                </DialogContent>
                <DialogActions>
                  <Button onClick={handleClose}>Disagree</Button>
                  <Button onClick={handleDelete} autoFocus>
                    Agree
                  </Button>
                </DialogActions>
              </Dialog>
            </StyledTableCell>
          </StyledTableRow>
        ))}
    </>
  );
  dinnerMenu = (
    <>
      {dinnerMeals &&
        dinnerMeals.map((row) => (
          <StyledTableRow
            key={row.mealId}
            sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
          >
            <StyledTableCell component="th" scope="row">
              {row.meal.name}
            </StyledTableCell>
            <StyledTableCell align="right">
              {row.actualCalories}
            </StyledTableCell>
            <StyledTableCell align="right">{row.actualFat}</StyledTableCell>
            <StyledTableCell align="right">{row.actualCarbs}</StyledTableCell>
            <StyledTableCell align="right">{row.actualProtein}</StyledTableCell>
            <StyledTableCell align="right">{row.quantity}</StyledTableCell>
            <StyledTableCell align="center">
              <DeleteIcon
                sx={{ cursor: "pointer" }}
                onClick={() => {
                  handleClickOpen();
                  setMealType("Dinner");
                  setMealId(row.mealId);
                }}
              />
              <Dialog
                open={open}
                onClose={handleClose}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
                BackdropProps={{ style: { backgroundColor: "transparent" } }}
              >
                <DialogContent>
                  Are you sure you want to delete this entry?
                </DialogContent>
                <DialogActions>
                  <Button onClick={handleClose}>Disagree</Button>
                  <Button onClick={handleDelete} autoFocus>
                    Agree
                  </Button>
                </DialogActions>
              </Dialog>
            </StyledTableCell>
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
            <Button onClick={() => console.log(todayDiary)}>asd</Button>
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
                <StyledTableCell align="right">
                  Quantity&nbsp;(g)
                </StyledTableCell>
                <StyledTableCell align="center">Delete entry</StyledTableCell>
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
                <StyledTableCell className="mealTitle">Lunch </StyledTableCell>
                <StyledTableCell align="right">Calories</StyledTableCell>
                <StyledTableCell align="right">Fat&nbsp;(g)</StyledTableCell>
                <StyledTableCell align="right">Carbs&nbsp;(g)</StyledTableCell>
                <StyledTableCell align="right">
                  Protein&nbsp;(g)
                </StyledTableCell>
                <StyledTableCell align="right">
                  Quantity&nbsp;(g)
                </StyledTableCell>
                <StyledTableCell align="center">Delete entry</StyledTableCell>
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
                <StyledTableCell className="mealTitle">Dinner </StyledTableCell>
                <StyledTableCell align="right">Calories</StyledTableCell>
                <StyledTableCell align="right">Fat&nbsp;(g)</StyledTableCell>
                <StyledTableCell align="right">Carbs&nbsp;(g)</StyledTableCell>
                <StyledTableCell align="right">
                  Protein&nbsp;(g)
                </StyledTableCell>
                <StyledTableCell align="right">
                  Quantity&nbsp;(g)
                </StyledTableCell>
                <StyledTableCell align="center">Delete entry</StyledTableCell>
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
