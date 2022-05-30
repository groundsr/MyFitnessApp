import "./dashboard.scss";
import Sidebar from "../../components/sidebar/Sidebar";
import Navbar from "../../components/navbar/Navbar";
import DashboardCard from "../../components/dashboardcard/DashboardCard";

const Dashboard = () => {
  return (
    <div className="home">
      <Sidebar />
      <div className="homeContainer">
        <Navbar />
        <DashboardCard />
      </div>
    </div>
  );
};

export default Dashboard;
