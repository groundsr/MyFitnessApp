import Sidebar from '../../components/sidebar/Sidebar';
import Navbar from '../../components/navbar/Navbar';
import Exercise from '../../components/exercise/Exercise';
import "./exercisepage.scss";
import React from 'react'

const ExercisePage = (props) => {
    return (
        <div className="food">
          <Sidebar name={props.name}/>
          <div className="foodContainer">
            <Navbar name={props.name}/>
            <Exercise/>
          </div>
        </div>
      );
}

export default ExercisePage