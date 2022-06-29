import React from "react";
import { DataGrid } from "@mui/x-data-grid";
import { Button, Link } from "@mui/material";
import { styled } from "@mui/material/styles";
import { purple } from "@mui/material/colors";
import { useEffect, useState } from "react";
import axios from "axios";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import FormControlLabel from "@mui/material/FormControlLabel";
import Radio from "@mui/material/Radio";
import RadioGroup from "@mui/material/RadioGroup";
import FormControl from "@mui/material/FormControl";
import { Navigate, useNavigate } from "react-router-dom";

const Table = (props) => {
  const [todayDiary, setTodayDiary] = useState({});
  const [user, setUser] = useState({});
  const navigate = useNavigate();
  const [quantity, setQuantity] = useState();
  const [foodId, setFoodId] = useState();
  const [mealType, setMealType] = useState("");
  const [open, setOpen] = React.useState(false);

  const handleChange = (e) => {
    setMealType(e.target.value);
  };

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };
  let dataRows = props.data.map((item) => ({
    id: item.id,
    name: item.name,
    protein: item.protein,
    calories: item.calories,
    fat: item.fat,
    carbs: item.carbohydrates,
    quantity: 0,
  }));

  const ColorButton = styled(Button)(({ theme }) => ({
    color: theme.palette.getContrastText(purple[500]),
    backgroundColor: purple[700],
    "&:hover": {
      backgroundColor: purple[900],
    },
  }));

  const addFoodToDiary = () => {
    axios
      .post(
        `https://localhost:44325/Diary/addFoodToDiary?userId=${props.userId}&MealType=${mealType}&mealId=${foodId}&quantity=${quantity}`
      )
      .then((response) => {
        console.log(response);
        props.setTodayDiary(response.data);
        handleClose();
        navigate("/food/");
      })
      .catch((error) => {
        if (error.response) {
          alert(error.response.data);
        }
      });
  };

  useEffect(() => {
    setTodayDiary(props.todayDiary);
    setUser(props.user);
  }, [props.todayDiary, props.user]);

  const handleRowEditCommit = React.useCallback((params) => {
    setFoodId(params.id);
    setQuantity(params.value);
    console.log(params.id);
  }, []);

  const columns = [
    {
      id: 1,
      flex: 1,
      field: "name",
      headerName: "Food",
      minWidth: 200,
      headerAlign: "begin",
    },
    { id: 2, field: "calories", headerName: "Calories", width: 170 },
    { id: 3, field: "fat", headerName: "Fat", width: 170 },
    { id: 4, field: "protein", headerName: "Protein", width: 170 },
    { id: 5, field: "carbs", headerName: "Carbs", width: 170 },
    {
      id: 6,
      field: "quantity",
      headerName: "Quantity(g)",
      editable: true,
      width: 170,
      headerAlign: "center",
      align: "center",
    },
    {
      id: 7,
      field: "add",
      headerName: "Add to diary",
      width: 200,
      headerAlign: "center",
      align: "center",
      renderCell: () => {
        return (
          <div>
            <ColorButton onClick={handleClickOpen} variant="contained">
              Add
            </ColorButton>
            <Dialog
              type="form"
              open={open}
              onClose={handleClose}
              BackdropProps={{ style: { backgroundColor: "transparent" } }}
            >
              <DialogTitle>Add this food to :</DialogTitle>
              <DialogContent sx={{ display: "grid", justifyContent: "center" }}>
                <Button onClick={() => console.log(mealType)}>check</Button>
                <FormControl>
                  <RadioGroup
                    aria-labelledby="demo-controlled-radio-buttons-group"
                    name="controlled-radio-buttons-group"
                    onChange={handleChange}
                    value={mealType}
                  >
                    <FormControlLabel
                      value="Breakfast"
                      control={<Radio />}
                      label="Breakfast"
                    />
                    <FormControlLabel
                      value="Lunch"
                      control={<Radio />}
                      label="Lunch"
                    />
                    <FormControlLabel
                      value="Dinner"
                      control={<Radio />}
                      label="Dinner"
                    />
                  </RadioGroup>
                </FormControl>
              </DialogContent>
              <DialogActions>
                <Button onClick={handleClose}>Cancel</Button>
                <Button onClick={addFoodToDiary}>Add</Button>
              </DialogActions>
            </Dialog>
          </div>
        );
      },
    },
  ];
  return (
    <>
      <Button onClick={() => console.log(props.userId)}>asd</Button>
      <div style={{ height: 400, width: "90%" }}>
        <div style={{ flexGrow: 1 }}>
          <DataGrid
            autoHeight
            sx={{ mt: 4 }}
            rows={dataRows}
            columns={columns}
            pageSize={5}
            rowsPerPageOptions={[5]}
            onCellEditCommit={handleRowEditCommit}
          />
        </div>
      </div>
    </>
  );
};

export default Table;
