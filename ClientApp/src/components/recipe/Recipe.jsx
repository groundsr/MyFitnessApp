import { Button } from "@mui/material";
import React from "react";
import { useEffect, useState } from "react";
import { Paper } from "@mui/material";
import { useParams } from "react-router-dom";
import { Box } from "@mui/system";
import "./recipe.scss";

const Recipe = () => {
  const params = useParams();
  const [details, setDetails] = useState({});
  const [activeTab, setActiveTab] = useState("instructions");

  const fetchDetails = async () => {
    const data = await fetch(
      `https://api.spoonacular.com/recipes/${params.id}/information?apiKey=038d079565ff480b8db22222c57fd35c`
    );
    const detailData = await data.json();
    setDetails(detailData);
  };
  useEffect(() => {
    fetchDetails();
  }, [params.name]);

  return (
    <div className="recipeContainer">
      <Paper
        sx={{
          m: "auto",
          p: "2rem",
          display: "flex",
          width: 1100,
          boxShadow: 3,
        }}
      >
        <Box sx={{ width: 300 }}>
          <h2 className="recipeTitle">{details.title}</h2>
          <img className="img" src={details.image} alt="" />
        </Box>
        <Box sx={{ width: 700,ml: 7, }}>
          <Button variant="outlined" color="secondary" sx={{mb:2, mr:2}}
            className={activeTab === "instructions" ? "active" : ""}
            onClick={() => setActiveTab("instructions")}
          >
            Instructions
          </Button>
          <Button variant="outlined" color="secondary" sx={{mb:2, mr:2}}
            className={activeTab === "ingredients" ? "active" : ""}
            onClick={() => setActiveTab("ingredients")}
          >
            Ingredients
          </Button>
          {activeTab === "instructions" && (
            <div>
              <h4 dangerouslySetInnerHTML={{ __html: details.summary }}></h4>
              <h4
                dangerouslySetInnerHTML={{ __html: details.instructions }}
              ></h4>
            </div>
          )}
          {activeTab === "ingredients" && (
            <ul>
              {details.extendedIngredients.map((ingredient) => {
                return <li key={ingredient.id}>{ingredient.original}</li>
              })}
            </ul>
          )}
        </Box>
      </Paper>
    </div>
  );
};

export default Recipe;
