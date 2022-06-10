import Sidebar from "../../components/sidebar/Sidebar"
import Navbar from "../../components/navbar/Navbar"
import Register from "../../components/register/Register"

const RegisterPage = () => {
  return (
    <div className="list">
      <Sidebar/>
      <div className="listContainer">
        <Navbar/>
        <Register/>
      </div>
    </div>
  )
}

export default RegisterPage