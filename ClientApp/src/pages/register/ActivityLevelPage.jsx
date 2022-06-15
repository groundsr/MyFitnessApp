import Sidebar from "../../components/sidebar/Sidebar"
import Navbar from "../../components/navbar/Navbar"
import ActivityLevel from "../../components/register/ActivityLevel"
const ActivityLevelPage = () => {
  return (
    <div className="list">
      <Sidebar/>
      <div className="listContainer">
        <Navbar/>
        <ActivityLevel/>
      </div>
    </div>
  )
}

export default ActivityLevelPage