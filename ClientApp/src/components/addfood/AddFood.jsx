import React, { useEffect } from "react";
import "./addfood.scss";
import { Paper } from "@mui/material";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { IconButton } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import InputBase from "@mui/material/InputBase";

const AddFood = () => {
  const [input, setInput] = useState("");
  const navigate = useNavigate();
  const [details, setDetails] = useState({});


  const fetchDetails = async () => {
    const data = axios.get('https://localhost:44325/meal/get');
    console.log(data);
    
  }

  useEffect(() => {
    fetchDetails();
  },[]);

  const submitHandler = (e) => {
    e.preventDefault();
    navigate("/searched/" + input)
  }

  return (
    <>
      <div className="container">
        <div className="foodTitle">Add Food To Breakfast</div>
        <hr className="line"></hr>
        <div className="SearchLabel">Search our food database by name</div>
        <div>
            <Paper
            onSubmit={submitHandler}
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
      </div>
    </>
  );
};

export default AddFood;
