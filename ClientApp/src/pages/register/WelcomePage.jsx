import Sidebar from "../../components/sidebar/Sidebar"
import Navbar from "../../components/navbar/Navbar"
import Welcome from "../../components/register/Welcome"
const WelcomePage = () => {
  return (
    <div className="list">
      <Sidebar/>
      <div className="listContainer">
        <Navbar/>
        <Welcome/>
      </div>
    </div>
  )
}

export default WelcomePage