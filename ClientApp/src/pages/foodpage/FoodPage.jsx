import Sidebar from '../../components/sidebar/Sidebar';
import Navbar from '../../components/navbar/Navbar';
import Food from '../../components/food/Food';
import "./foodpage.scss";
import React from 'react'

const FoodPage = (props) => {
    return (
        <div className="food">
          <Sidebar name={props.name} setName={props.setName}/>
          <div className="foodContainer">
            <Navbar name={props.name} setName={props.setName}/>
            <Food/>
          </div>
        </div>
      );
}

export default FoodPage