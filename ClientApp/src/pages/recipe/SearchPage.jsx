import Sidebar from "../../components/sidebar/Sidebar";
import Navbar from "../../components/navbar/Navbar";
import React from "react";
import Search from "../../components/recipe/Search";
import Searched from "../../components/recipe/Searched";

const SearchPage = (props) => {
  return (
    <div className="food">
      <Sidebar name={props.name} />
      <div className="foodContainer">
        <Navbar name={props.name} />
          <Search name={props.name} />
          <Searched name={props.name} />
      </div>
    </div>
  );
};

export default SearchPage;
