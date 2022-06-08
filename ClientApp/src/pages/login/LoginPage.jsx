import Sidebar from "../../components/sidebar/Sidebar"
import Navbar from "../../components/navbar/Navbar"
import Login from "../../components/login/Login"

const LoginPage = () => {
  return (
    <div className="list">
      <Sidebar/>
      <div className="listContainer">
        <Navbar/>
        <Login/>
      </div>
    </div>
  )
}

export default LoginPage