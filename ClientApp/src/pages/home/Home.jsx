import Sidebar from "../../components/sidebar/Sidebar";
import Navbar from "../../components/navbar/Navbar";
import "./home.scss";
import Featured from "../../components/featured/Featured";
import Chart from "../../components/chart/Chart";
import DashboardCard from "../../components/dashboardcard/DashboardCard";
import axios from "axios";
import { useState, useEffect } from "react";
import { Button } from "@mui/material";

const Home = (props) => {
  const [id, setId] = useState();
  const [user, setUser] = useState({ ...props.user });
  const [userProgress, setUserProgress] = useState({ ...props.userProgress });
  const [userGoal, setUserGoal] = useState({});
  const [userPlan, setUserPlan] = useState({});
  const [currentWeight, setCurrentWeight] = useState();
  const [startingWeight, setStartingWeight] = useState();
  const url = "https://localhost:44325/users/get";

  useEffect(() => {
    setUser(props.user);
    setUserProgress(props.user.userProgresses);
    setUserGoal(props.user.userGoal);
    // setUserPlan(props.user.userGoal.userPlan ? props.user.userGoal.userPlan : console.log("loading.."));
    setCurrentWeight(
      props.user.userProgresses
        ? props.user.userProgresses.at(-1).currentWeight
        : console.log("loading...")
    );
    setStartingWeight(
      props.user.userProgresses
        ? props.user.userProgresses[0].currentWeight
        : console.log("loading")
    );
  }, [props.user]);

  return (
    <div className="home">
      <Sidebar name={props.name} setName={props.setName} user={props.user} />
      <div className="homeContainer">
        <Navbar name={props.name} />
        <div className="card">
          <DashboardCard
            user={user}
            setUser={setUser}
            userProgress={userProgress}
            userGoal={userGoal}
            userPlan={userPlan}
            currentWeight={currentWeight}
            setCurrentWeight={setCurrentWeight}
          />
        </div>
        <div className="charts">
          <Featured
            user={user}
            userProgress={userProgress}
            currentWeight={currentWeight}
            startingWeight={startingWeight}
          />
          <Chart
            user={user}
            currentWeight={currentWeight}
            title="User Progress (Last year)"
            aspect={2 / 1}
          />
        </div>
      </div>
    </div>
  );
};

export default Home;
