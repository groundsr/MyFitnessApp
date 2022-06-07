import React from "react";
import "./addfood.scss";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import SearchIcon from '@mui/icons-material/Search';

const AddFood = () => {
  return (
    <>
      <div className="container">
        <div className="foodTitle">Add Food To Breakfast</div>
        <hr className="line"></hr>
        <div className="SearchLabel">Search our food database by name</div>
        <div>
            <TextField
              id="outlined-search"
              label="Search field"
              type="search"
            />
            <SearchIcon className="search"/>
        </div>
      </div>
    </>
  );
};

export default AddFood;
