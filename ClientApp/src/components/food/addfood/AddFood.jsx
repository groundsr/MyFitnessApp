import React, { useEffect } from "react";
import "./addfood.scss";
import { Button, Paper } from "@mui/material";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { IconButton } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import InputBase from "@mui/material/InputBase";
import Table from "./Table";

const AddFood = (props) => {
  const [input, setInput] = useState("");
  const [searchedFood, setSearchedFood] = useState([]);
  const [diaries, setDiaries] = useState([]);
  const [todayDiary, setTodayDiary] = useState({});

  const fetchDetails = async () => {
    const data = axios
      .get("https://localhost:44325/meal/get")
      .then((response) => {
        setSearchedFood(response.data);
      });
  };

  useEffect(() => {
    fetchDetails();
    setDiaries(props.diaries);
    setTodayDiary(props.todayDiary);
  }, [props.user, props.diaries, props.todayDiary]);

  const search = (data) => {
    return data.filter((item) => item.name.toLowerCase().includes(input));
  };

  return (
    <>
      <div className="addFoodContainer">
        <div className="foodTitle">Add Food To Breakfast</div>
        <Button onClick={() => console.log(props.userId)}>asd</Button>
        <hr className="line"></hr>
        <div className="SearchLabel">Search our food database by name</div>
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
              className="searchTest"
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
        <Table
          data={search(searchedFood)}
          userId={props.userId}
          setTodayDiary={props.setTodayDiary}
          todayDiary={todayDiary}
        />
      </div>
    </>
  );
};

export default AddFood;
