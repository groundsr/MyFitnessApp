import Sidebar from "../../components/sidebar/Sidebar";
import Navbar from "../../components/navbar/Navbar";
import Register from "../../components/register/Register";

const RegisterPage = (props) => {
  return (
    <div className="list">
      <Sidebar />
      <div className="listContainer">
        <Navbar />
        <Register
          sex={props.sex}
          birthday={props.birthday}
          height={props.height}
          kilosGoal={props.kilosGoal}
          weight={props.weight}
          userActivity={props.userActivity}
          weightGoal={props.weightGoal}
        />
      </div>
    </div>
  );
};

export default RegisterPage;
