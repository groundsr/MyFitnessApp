import Sidebar from "../../components/sidebar/Sidebar";
import Navbar from "../../components/navbar/Navbar";
import PersonalInfo from "../../components/register/PersonalInfo";
const PersonalInfoPage = (props) => {
  return (
    <div className="list">
      <Sidebar />
      <div className="listContainer">
        <Navbar />
        <PersonalInfo
          setSex={props.setSex}
          setBirthday={props.setBirthday}
          setHeight={props.setHeight}
          setKilosGoal={props.setKilosGoal}
          setWeight={props.setWeight}
        />
      </div>
    </div>
  );
};

export default PersonalInfoPage;
