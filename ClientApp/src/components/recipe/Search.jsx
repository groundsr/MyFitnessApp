import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { InputBase } from "@mui/material";
import { IconButton } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import { Paper } from "@mui/material";
// import "./search.scss";

const Search = () => {
  const [input, setInput] = useState("");
  const navigate = useNavigate();

  const submitHandler = (e) => {
    e.preventDefault();
    navigate("/searched/" + input);
  };

  return (
    <div className="container">
      <Paper
        onSubmit={submitHandler}
        component="form"
        sx={{
          m: 'auto',
          p: "2px 4px",
          display: "flex",
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
  );
};

export default Search;
