import React from "react";
import { useState } from "react";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Grid } from "@mui/material";
import { styled } from "@mui/material/styles";
import Paper from "@mui/material/Paper";
import { Link } from "@mui/material";

const Searched = () => {
  const [searchedRecipes, setSearchedRecipes] = useState([]);
  let params = useParams();

  const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#fff",
    margin: 3,
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: "center",
    color: theme.palette.text.secondary,
  }));

  useEffect(() => {
    getSearched(params.search);
  }, [params.search]);

  const getSearched = async (name) => {
    const data = await fetch(
      `https://api.spoonacular.com/recipes/complexSearch?apiKey=da31a1a24a434b84bbc2052ce48b504f&query=${name}`
    );
    const recipes = await data.json();
    setSearchedRecipes(recipes.results);
  };
  return (
    <Grid sx={{ m: 2 }} container spacing={2}>
      {searchedRecipes.map((recipe) => {
        return (
          <Link to={"/recipe/" + recipe.id}>
            <Grid item xs={3}>
              <Item key={recipe.id}>
                <img src={recipe.image} alt=""></img>
                <h4>{recipe.title}</h4>
              </Item>
            </Grid>
          </Link>
        );
      })}
    </Grid>
  );
};

export default Searched;
