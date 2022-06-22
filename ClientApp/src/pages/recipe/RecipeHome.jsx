import Sidebar from "../../components/sidebar/Sidebar";
import Navbar from "../../components/navbar/Navbar";
import React from "react";
import Search from "../../components/recipe/Search";
import "./home.scss";

const RecipeHome = (props) => {
  return (
    <div className="food">
      <Sidebar name={props.name} setName={props.setName}/>
      <div className="foodContainer">
        <Navbar name={props.name} setName={props.setName}/>
          <Search />
      </div>
    </div>
  );
};

export default RecipeHome;
