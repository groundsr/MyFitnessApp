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
import { Summarize } from "@mui/icons-material";
import Chip from "@mui/material/Chip";

const List = () => {
  const [DiaryDetails, SetDiaryDetails] = useState([]);

  const fetchDetails = async () => {
    const data = axios
      .get("https://localhost:44325/diary/get")
      .then((response) => {
        SetDiaryDetails(response.data);
      });
  };

  useEffect(() => {
    fetchDetails();
  }, []);

  // let dataRows = data.map((item) => ({
  //   id: item.id,
  //   name: item.name,
  //   protein: item.protein,
  //   calories: item.calories,
  //   fat: item.fat,
  //   carbs: item.carbohydrates,
  //   quantity: 0,
  // }));
  const calculateMacro = (meal) => {
    DiaryDetails.map((diary) => {
      meal = diary.lunch.meals.reduce(
        (totalProtein, meal) => totalProtein + meal.protein,
        0
      );
    });
    return meal;
  };

  const tableRows = DiaryDetails.map((diary) => ({
    id: diary.id,
    creationDate: diary.creationDate,
    totalCalories: diary.totalCalories,
    protein: calculateMacro(diary.dinner),
  }));

  const rows = [
    {
      id: 1143155,
      product: "Acer Nitro 5",
      img: "https://m.media-amazon.com/images/I/81bc8mA3nKL._AC_UY327_FMwebp_QL65_.jpg",
      customer: "John Smith",
      date: "1 March",
      amount: 785,
      method: "Cash on Delivery",
      status: "Approved",
    },
    {
      id: 2235235,
      product: "Playstation 5",
      img: "https://m.media-amazon.com/images/I/31JaiPXYI8L._AC_UY327_FMwebp_QL65_.jpg",
      customer: "Michael Doe",
      date: "1 March",
      amount: 900,
      method: "Online Payment",
      status: "Pending",
    },
    {
      id: 2342353,
      product: "Redragon S101",
      img: "https://m.media-amazon.com/images/I/71kr3WAj1FL._AC_UY327_FMwebp_QL65_.jpg",
      customer: "John Smith",
      date: "1 March",
      amount: 35,
      method: "Cash on Delivery",
      status: "Pending",
    },
    {
      id: 2357741,
      product: "Razer Blade 15",
      img: "https://m.media-amazon.com/images/I/71wF7YDIQkL._AC_UY327_FMwebp_QL65_.jpg",
      customer: "Jane Smith",
      date: "1 March",
      amount: 920,
      method: "Online",
      status: "Approved",
    },
    {
      id: 2342355,
      product: "ASUS ROG Strix",
      img: "https://m.media-amazon.com/images/I/81hH5vK-MCL._AC_UY327_FMwebp_QL65_.jpg",
      customer: "Harold Carol",
      date: "1 March",
      amount: 2000,
      method: "Online",
      status: "Pending",
    },
  ];
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
              <TableCell className="tableCell">85</TableCell>
              <TableCell className="tableCell">40</TableCell>
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
