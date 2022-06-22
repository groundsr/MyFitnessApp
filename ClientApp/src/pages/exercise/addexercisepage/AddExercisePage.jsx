import React from 'react'
import AddExercise from '../../../components/exercise/addexercise/AddExercise';
import Sidebar from '../../../components/sidebar/Sidebar';
import Navbar from '../../../components/navbar/Navbar';
import "./addexercisepage.scss"

const AddFoodPage = (props) => {
  return (
    <div className="exercise">
    <Sidebar name={props.name} setName={props.setName}/>
    <div className="exerciseContainer">
      <Navbar name={props.name} setName={props.setName}/>
      <AddExercise/>
    </div>
  </div>
  )
}

export default AddFoodPage