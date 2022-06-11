import "./dashboard.scss";
import Sidebar from "../../components/sidebar/Sidebar";
import Navbar from "../../components/navbar/Navbar";
import DashboardCard from "../../components/dashboardcard/DashboardCard";

const Dashboard = (props) => {
  return (
    <div className="home">
      <Sidebar name={props.name}/>
      <div className="homeContainer">
        <Navbar name={props.name}/>
        <DashboardCard />
      </div>
    </div>
  );
};

export default Dashboard;
