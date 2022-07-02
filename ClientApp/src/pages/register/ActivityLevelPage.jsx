import Sidebar from "../../components/sidebar/Sidebar"
import Navbar from "../../components/navbar/Navbar"
import ActivityLevel from "../../components/register/ActivityLevel"
const ActivityLevelPage = (props) => {
  return (
    <div className="list">
      <Sidebar/>
      <div className="listContainer">
        <Navbar/>
        <ActivityLevel userActivity={props.userActivity} setUserActivity={props.setUserActivity}/>
      </div>
    </div>
  )
}

export default ActivityLevelPage