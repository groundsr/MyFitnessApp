import React from "react";
import AddFood from "../../../components/food/addfood/AddFood";
import Sidebar from "../../../components/sidebar/Sidebar";
import Navbar from "../../../components/navbar/Navbar";
import "./addfoodpage.scss";

const AddFoodPage = (props) => {
  return (
    <div className="food">
      <Sidebar name={props.name} setName={props.setName} />
      <div className="foodContainer">
        <Navbar name={props.name} setName={props.setName} />
        <AddFood diaries={props.diaries} userId={props.userId} todayDiary={props.todayDiary} setTodayDiary={props.setTodayDiary}/>
      </div>
    </div>
  );
};

export default AddFoodPage;
