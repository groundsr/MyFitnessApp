import React, { useEffect } from "react";
import "./addexercise.scss";
import { Paper } from "@mui/material";
import axios from "axios";
import { useState } from "react";
import { IconButton } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import InputBase from "@mui/material/InputBase";
import Table from "./Table";


const AddExercise = () => {
  const [input, setInput] = useState("");
  const [searchedExercise, setSearchedExercise] = useState([]);

  const fetchDetails = async () => {
    const data = axios
      .get("https://localhost:44325/exercise/get")
      .then((response) => {
        setSearchedExercise(response.data);
      });
  };

  useEffect(() => {
    fetchDetails();
  },[]);


  const search = (data) => {
    return data.filter(item => item.name.toLowerCase().includes(input));
  }

  return (
    <>
      <div className="container">
        <div className="foodTitle">Add Exercise</div>
        <hr className="line"></hr>
        <div className="SearchLabel">Search our exercise database by name</div>
        <div>
          <Paper
            onSubmit={fetchDetails}
            component="form"
            sx={{
              mt: 2,
              p: "2px 4px",
              display: "flex",
              alignItems: "center",
              width: 400,
            }}
          >
            <InputBase
              sx={{ ml: 1, flex: 1 }}
              placeholder={"Search..."}
              onChange={(e) => setInput(e.target.value)}
              type="text"
              value={input}
            />
            <IconButton type="submit" sx={{ p: "10px" }} aria-label="search">
              <SearchIcon />
            </IconButton>
          </Paper>
        </div>
        <Table data={search(searchedExercise)}/>
      </div>
    </>
  );
};

export default AddExercise;
