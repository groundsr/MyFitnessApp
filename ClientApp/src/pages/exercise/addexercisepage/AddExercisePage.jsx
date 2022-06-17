import React from 'react'
import AddExercise from '../../../components/exercise/addexercise/AddExercise';
import Sidebar from '../../../components/sidebar/Sidebar';
import Navbar from '../../../components/navbar/Navbar';
import "./addexercisepage.scss"

const AddFoodPage = (props) => {
  return (
    <div className="exercise">
    <Sidebar name={props.name}/>
    <div className="exerciseContainer">
      <Navbar name={props.name}/>
      <AddExercise/>
    </div>
  </div>
  )
}

export default AddFoodPage