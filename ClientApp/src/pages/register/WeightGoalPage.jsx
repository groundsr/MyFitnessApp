import Sidebar from "../../components/sidebar/Sidebar"
import Navbar from "../../components/navbar/Navbar"
import WeightGoal from "../../components/register/WeightGoal"
const WeightGoalPage = () => {
  return (
    <div className="list">
      <Sidebar/>
      <div className="listContainer">
        <Navbar/>
        <WeightGoal/>
      </div>
    </div>
  )
}

export default WeightGoalPage