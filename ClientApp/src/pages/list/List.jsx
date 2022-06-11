import "./list.scss"
import Sidebar from "../../components/sidebar/Sidebar"
import Navbar from "../../components/navbar/Navbar"
import Datatable from "../../components/datatable/Datatable"

const List = (props) => {
  return (
    <div className="list">
      <Sidebar name={props.name}/>
      <div className="listContainer">
        <Navbar name={props.name}/>
        <Datatable />
      </div>
    </div>
  )
}

export default List