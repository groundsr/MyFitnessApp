import React from "react";
import { useState } from "react";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { styled } from "@mui/material/styles";
import Paper from "@mui/material/Paper";
import { Link } from "react-router-dom";
import "./searched.scss";

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
      `https://api.spoonacular.com/recipes/complexSearch?apiKey=038d079565ff480b8db22222c57fd35c&query=${name}&number=12`
    );
    const recipes = await data.json();
    setSearchedRecipes(recipes.results);
  };
  return (
    <div className="grid">
      {searchedRecipes.map((recipe) => {
        return (
          <Link to={"/recipe/" + recipe.id}>
            <div className="card" key={recipe.id}>
              <img src={recipe.image} alt=""/>
              <h3>{recipe.title}</h3>
            </div>
          </Link>
        );
      })}
      </div>
  );
};

export default Searched;
