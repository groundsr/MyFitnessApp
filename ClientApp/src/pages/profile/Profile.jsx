import "./profile.scss";
import Sidebar from "../../components/sidebar/Sidebar";
import Navbar from "../../components/navbar/Navbar";
import Chart from "../../components/chart/Chart";
import List from "../../components/table/Table";
import { useState } from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import { useEffect } from "react";
import axios from "axios";
import { IconButton } from "@mui/material";
import { InputAdornment } from "@mui/material";
import VisibilityIcon from "@mui/icons-material/Visibility";
import VisibilityOffIcon from "@mui/icons-material/VisibilityOff";

const Profile = (props) => {
  const [open, setOpen] = useState(false);
  const [user, setUser] = useState({ ...props.user });
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [id, setId] = useState();
  const [showPassword, setShowPassword] = useState(false);

  //Get user
  const getUser = async () => {
    const response = await axios.get("https://localhost:44325/api/user", {
      withCredentials: true,
    });
    setUser(response.data);
    setName(response.data.name);
    setEmail(response.data.email);
    setPassword(response.data.password);
    setId(response.data.id);
  };

  useEffect(() => {
    getUser();
    // setUser(props.user);
    // setName(props.user.name);
    // setEmail(props.user.email);
    // setId(props.user.id);
  }, []);

  const updateUser = async () => {
    await axios
      .put(`https://localhost:44325/Users/update/${id}`, {
        email,
        name,
        password,
        id,
      })
      .then((resp) => {
        console.log(resp.data);
        setUser({ ...resp.data });
        setName(resp.data.name);
        props.setName(resp.data.name);
      });

    handleClose();
  };

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleTogglePassword = () => {
    setShowPassword((showPassword) => !showPassword);
  };

  var UserActivity = ["Very Active", "Active", "Not so active", "Sedentary"];
  var Goal = ["Maintain weight", "Gain weight", "Lose weight"];

  return (
    <div className="single">
      <Sidebar name={props.name} setName={props.setName} />
      <div className="singleContainer">
        <Navbar name={props.name} setName={props.setName} />
        <div className="top">
          <div className="left">
            <div className="editButton" onClick={handleClickOpen}>
              Edit
            </div>
            <Dialog type="form" open={open} onClose={handleClose}>
              <DialogTitle>Edit user profile</DialogTitle>
              <DialogContent>
                <TextField
                  onChange={(e) => setName(e.target.value)}
                  autoFocus
                  defaultValue={name}
                  margin="dense"
                  id="name"
                  label="Name"
                  type="string"
                  fullWidth
                  variant="outlined"
                />
                <TextField
                  onChange={(e) => setEmail(e.target.value)}
                  autoFocus
                  defaultValue={email}
                  margin="dense"
                  id="email"
                  label="Email"
                  type="string"
                  fullWidth
                  variant="outlined"
                />
                <TextField
                  onChange={(e) => setPassword(e.target.value)}
                  autoFocus
                  defaultValue={password}
                  margin="dense"
                  id="password"
                  label="Password"
                  type={showPassword ? "text" : "password"}
                  fullWidth
                  variant="outlined"
                  InputProps={{
                    endAdornment: (
                      <InputAdornment position="end">
                        <IconButton
                          aria-label="toggle password visibility"
                          onClick={handleTogglePassword}
                        >
                          {showPassword ? (
                            <VisibilityIcon />
                          ) : (
                            <VisibilityOffIcon />
                          )}
                        </IconButton>
                      </InputAdornment>
                    ),
                  }}
                />
              </DialogContent>
              <DialogActions>
                <Button onClick={handleClose}>Cancel</Button>
                <Button onClick={updateUser}>Edit</Button>
              </DialogActions>
            </Dialog>
            <h1 className="title">Information</h1>
            <div className="item">
              <img
                src="https://corestrengthblog.files.wordpress.com/2013/04/fitman.png"
                alt=""
                className="itemImg"
              />
              <div className="details">
                <h1 className="itemTitle">{props.user.name}</h1>
                <div className="detailItem">
                  <span className="itemKey">Email:</span>
                  <span className="itemValue">{user.email}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">User Goal:</span>
                  <span className="itemValue">{Goal[props.userGoal.goal]}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">User Activity:</span>
                  <span className="itemValue">
                    {UserActivity[props.userGoal.userActivity]}
                  </span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Body Mass Index:</span>
                  <span className="itemValue">{props.userPlan.bmi}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Total Calories:</span>
                  <span className="itemValue">
                    {props.userPlan.totalCalories}
                  </span>
                </div>
              </div>
            </div>
          </div>
          <div className="right">
            <Chart
              user={user}
              aspect={3 / 1}
              title="User Progress (Last 6 Months)"
            />
          </div>
        </div>
        <div className="bottom">
          <h1 className="title">Nutrition (Last 7 days)</h1>
          <List name={props.name} user={props.user}/>
        </div>
      </div>
    </div>
  );
};

export default Profile;
