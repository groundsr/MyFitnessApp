import Sidebar from "../../components/sidebar/Sidebar"
import Navbar from "../../components/navbar/Navbar"
import PersonalInfo from "../../components/register/PersonalInfo"
const PersonalInfoPage = () => {
  return (
    <div className="list">
      <Sidebar/>
      <div className="listContainer">
        <Navbar/>
        <PersonalInfo/>
      </div>
    </div>
  )
}

export default PersonalInfoPage