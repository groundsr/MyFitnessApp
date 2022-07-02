import Sidebar from "../../components/sidebar/Sidebar"
import Navbar from "../../components/navbar/Navbar"
import WeightGoal from "../../components/register/WeightGoal"
const WeightGoalPage = (props) => {
  return (
    <div className="list">
      <Sidebar/>
      <div className="listContainer">
        <Navbar/>
        <WeightGoal setWeightGoal={props.setWeightGoal}/>
      </div>
    </div>
  )
}

export default WeightGoalPage