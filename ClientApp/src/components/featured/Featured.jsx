import "./featured.scss";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import { CircularProgressbar } from "react-circular-progressbar";
import "react-circular-progressbar/dist/styles.css";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import KeyboardArrowUpOutlinedIcon from "@mui/icons-material/KeyboardArrowUpOutlined";

const Featured = () => {
  return (
    <div className="featured">
      <div className="top">
        <h1 className="title">Weight changes</h1>
        <MoreVertIcon fontSize="small" />
      </div>
      <div className="bottom">
        <p className="title">How close you are for achieving your goal</p>
        <div className="featuredChart">
          <CircularProgressbar value={70} text={"70%"} strokeWidth={5} />
        </div>
        <p className="amount">3 more kilograms to go!</p>
        <p className="desc">
          Your weight then versus now. You got this !
        </p>
        <div className="summary">
          <div className="item">
            <div className="itemTitle">Starting weight</div>
            <div className="itemResult negative">
              <KeyboardArrowDownIcon fontSize="small"/>
              <div className="resultAmount">85kg</div>
            </div>
          </div>
          <div className="item">
            <div className="itemTitle">Current Weight</div>
            <div className="itemResult positive">
              <KeyboardArrowUpOutlinedIcon fontSize="small"/>
              <div className="resultAmount">98kg</div>
            </div>
          </div>
          <div className="item">
            <div className="itemTitle">Goal weight</div>
            <div className="itemResult positive">
              <KeyboardArrowUpOutlinedIcon fontSize="small"/>
              <div className="resultAmount">101kg</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Featured;
