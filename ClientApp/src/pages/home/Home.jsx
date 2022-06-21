import Sidebar from "../../components/sidebar/Sidebar";
import Navbar from "../../components/navbar/Navbar";
import "./home.scss";
import Widget from "../../components/widget/Widget";
import Featured from "../../components/featured/Featured";
import Chart from "../../components/chart/Chart";
import Table from "../../components/table/Table";
import DashboardCard from "../../components/dashboardcard/DashboardCard";

const Home = (props) => {
  return (
    <div className="home">
      <Sidebar name={props.name} />
      <div className="homeContainer">
        <Navbar name={props.name} />
        {/* <div className="widgets">
          <Widget type="user" />
          <Widget type="order" />
          <Widget type="earning" />
          <Widget type="balance" />
        </div> */}
        <div class="card">
          <DashboardCard />
        </div>
        <div className="charts">
          <Featured />
          <Chart title="User Progress (Last 6 months)" aspect={2 / 1} />
        </div>
        {/* <div className="listContainer">
          <div className="listTitle">Latest Transactions</div>
          <Table />
        </div> */}
      </div>
    </div>
  );
};

export default Home;
