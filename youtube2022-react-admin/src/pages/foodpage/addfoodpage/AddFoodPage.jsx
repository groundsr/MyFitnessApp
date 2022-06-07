import React from 'react'
import AddFood from '../../../components/addfood/AddFood';
import Sidebar from '../../../components/sidebar/Sidebar';
import Navbar from '../../../components/navbar/Navbar';
import "./addfoodpage.scss"

const AddFoodPage = () => {
  return (
    <div className="food">
    <Sidebar />
    <div className="foodContainer">
      <Navbar />
      <AddFood/>
    </div>
  </div>
  )
}

export default AddFoodPage