import Sidebar from '../../components/sidebar/Sidebar';
import Navbar from '../../components/navbar/Navbar';
import React from 'react'
import Search from '../../components/recipe/Search';
import Searched from './Searched';

const RecipeHome = (props) => {
    return (
        <div className="food">
          <Sidebar name={props.name}/>
          <div className="foodContainer">
            <Navbar name={props.name}/>
            <Search/>
            <Searched/>
          </div>
        </div>
      );
}

export default RecipeHome