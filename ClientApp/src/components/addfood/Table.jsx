import React from "react";
import { DataGrid } from "@mui/x-data-grid";
import { Button, Link } from "@mui/material";

const Table = ({ data }) => {
  let dataRows = data.map((item) => ({
    id: item.id,
    name: item.name,
    protein: item.protein,
    calories: item.calories,
    fat: item.fat,
    carbs: item.carbohydrates,
    quantity: 0,
  }));

  
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
      headerName: "Quantity(100g)",
      editable: true,
      width: 170,
      headerAlign: "center",
      align: "center",
    },
    {
        id:7, field: "add", headerName: "Add to diary", width: 200, headerAlign: "center", align: "center",
        renderCell: () => {
            
            return <Button variant="contained">Add</Button>
        }
    },
  ];
  return (
    <div style={{ height: 400, width: "90%" }}>
      <div style={{ flexGrow: 1 }}>
        <DataGrid
          autoHeight
          sx={{ mt: 4 }}
          rows={dataRows}
          columns={columns}
          pageSize={5}
          rowsPerPageOptions={[5]}
        />
      </div>
    </div>
  );
};

export default Table;
