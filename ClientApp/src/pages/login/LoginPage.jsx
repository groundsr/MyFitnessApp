import Sidebar from "../../components/sidebar/Sidebar"
import Navbar from "../../components/navbar/Navbar"
import Login from "../../components/login/Login"

const LoginPage = (props) => {
  return (
    <div className="list">
      <Sidebar/>
      <div className="listContainer">
        <Navbar/>
        <Login name={props.name} setName={props.setName}/>
      </div>
    </div>
  )
}

export default LoginPage