import Sidebar from '../../components/sidebar/Sidebar';
import Navbar from '../../components/navbar/Navbar';
import DashboardCard from '../../components/dashboardcard/DashboardCard';
import Food from '../../components/food/Food';
import "./foodpage.scss";
import React from 'react'

const FoodPage = () => {
    return (
        <div className="food">
          <Sidebar />
          <div className="foodContainer">
            <Navbar />
            <Food/>
          </div>
        </div>
      );
}

export default FoodPage