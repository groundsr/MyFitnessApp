import "./table.scss";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import axios from "axios";
import { useEffect } from "react";
import { useState } from "react";
import Chip from "@mui/material/Chip";

const List = (props) => {
  const [DiaryDetails, SetDiaryDetails] = useState([]);

  const fetchDetails = async () => {
    const data = axios
      .get(
        `https://localhost:44325/diary/getdiariesforuser/${props.user.id}`
      )
      .then((response) => {
        SetDiaryDetails(response.data);
        console.log(response.data);
      });
  };

  useEffect(() => {
    fetchDetails();
  }, [props.user]);

  const tableRows = DiaryDetails.map((diary) => ({
    id: diary.id,
    creationDate: diary.creationDate,
    totalCalories:
      diary.breakfast.calories + diary.lunch.calories + diary.dinner.calories,
    protein:
      diary.breakfast.totalProtein +
      diary.lunch.totalProtein +
      diary.dinner.totalProtein,
    fat:
      diary.breakfast.totalFat + diary.lunch.totalFat + diary.dinner.totalFat,
    carbs:
      diary.breakfast.totalCarbohydrates +
      diary.lunch.totalCarbohydrates +
      diary.dinner.totalCarbohydrates,
  }));

  return (
    <TableContainer component={Paper} className="table">
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell className="tableCell">Date</TableCell>
            <TableCell className="tableCell">Total Calories</TableCell>
            <TableCell className="tableCell">Protein</TableCell>
            <TableCell className="tableCell">Carbohydrates</TableCell>
            <TableCell className="tableCell">Fat</TableCell>
            <TableCell className="tableCell">Status</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {tableRows.map((row) => (
            <TableRow key={row.id}>
              <TableCell className="tableCell">{row.creationDate}</TableCell>
              <TableCell className="tableCell">{row.totalCalories}</TableCell>
              <TableCell className="tableCell">{row.protein}</TableCell>
              <TableCell className="tableCell">{row.carbs}</TableCell>
              <TableCell className="tableCell">{row.fat}</TableCell>
              <TableCell className="tableCell">
                <Chip label="good" color="success" variant="outlined" />
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default List;
