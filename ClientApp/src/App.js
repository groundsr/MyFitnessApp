import Home from "./pages/home/Home";
import RecipeHome from "./pages/recipe/RecipeHome";
import LoginPage from "./pages/login/LoginPage";
import { useState, useEffect } from "react";
import List from "./pages/list/List";
import Single from "./pages/profile/Profile";
import New from "./pages/new/New";
import Dashboard from "./pages/dashboard/Dashboard";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { productInputs, userInputs } from "./formSource";
import "./style/dark.scss";
import { useContext } from "react";
import { DarkModeContext } from "./context/darkModeContext";
import FoodPage from "./pages/foodpage/FoodPage";
import AddFoodPage from "./pages/foodpage/addfoodpage/AddFoodPage";
import AddExercisePage from "./pages/exercise/addexercisepage/AddExercisePage";

import RegisterPage from "./pages/register/RegisterPage";
import WelcomePage from "./pages/register/WelcomePage";
import ActivityLevelPage from "./pages/register/ActivityLevelPage";
import WeightGoalPage from "./pages/register/WeightGoalPage";
import PersonalInfoPage from "./pages/register/PersonalInfoPage";
import ExercisePage from "./pages/exercise/ExercisePage";
import Searched from "./components/recipe/Searched";
import SearchPage from "./pages/recipe/SearchPage";
import RecipePage from "./pages/recipe/RecipePage";
import Profile from "./pages/profile/Profile";
import axios from "axios";

function App() {
  const { darkMode } = useContext(DarkModeContext);
  const [name, setName] = useState("");
  const [userId, setUserId] = useState();
  const [user, setUser] = useState({});
  const [userGoal, setUserGoal] = useState({});
  const [userPlan, setUserPlan] = useState({});
  const [diaries, setDiaries] = useState([]);
  const [todayDiary, setTodayDiary] = useState({});

  useEffect(() => {
    (async () => {
      const response = await fetch("https://localhost:44325/api/user", {
        headers: { "Content-Type": "application/json" },
        credentials: "include",
      });

      const content = await response.json();
      setUserId(content.id);
      setUserPlan(content.userGoal.userPlan);
      setUserGoal(content.userGoal);
      setName(content.name);
      setUser(content);
    })();
  }, [name]);

  useEffect(() => {
    axios.get("https://localhost:44325/diary/get").then((response) => {
      setDiaries(response.data);
      setTodayDiary(
        response.data ? response.data.at(-1) : console.log("loading")
      );
    });
  }, []);

  return (
    <div className={darkMode ? "app dark" : "app"}>
      <BrowserRouter>
        <Routes>
          <Route path="/">
            <Route
              index
              element={
                <Home
                  name={name}
                  setName={setName}
                  user={user}
                  setUser={setUser}
                />
              }
            />
            <Route
              path="login"
              element={<LoginPage name={name} setName={setName} />}
            />
            <Route path="account">
              <Route index element={<WelcomePage />} />
              <Route path="goals" element={<WeightGoalPage />} />
              <Route path="activity-level" element={<ActivityLevelPage />} />
              <Route path="personalinfo" element={<PersonalInfoPage />} />
              <Route path="register" element={<RegisterPage name={name} />} />
            </Route>
            <Route path="users">
              <Route index element={<List name={name} setName={setName} />} />
              <Route
                path=":userId"
                element={<Single name={name} setName={setName} />}
              />
              <Route
                path="new"
                element={
                  <New inputs={userInputs} name={name} title="Add New User" />
                }
              />
            </Route>
            <Route path="products">
              <Route index element={<List name={name} />} />
              <Route path=":productId" element={<Single name={name} />} />
              <Route
                path="new"
                element={
                  <New
                    inputs={productInputs}
                    name={name}
                    title="Add New Product"
                  />
                }
              />
            </Route>
            {/* <Route path="home">
              <Route index element={<Dashboard name={name} setName={setName}/>} />
            </Route> */}
            <Route path="food">
              <Route
                index
                element={<FoodPage name={name} todayDiary={todayDiary} setTodayDiary={setTodayDiary} setName={setName} />}
              />
              <Route
                path=":add"
                element={
                  <AddFoodPage
                    userId={userId}
                    diaries={diaries}
                    todayDiary={todayDiary}
                    setTodayDiary={setTodayDiary}
                    name={name}
                    setName={setName}
                  />
                }
              />
            </Route>
            <Route path="exercise">
              <Route
                index
                element={<ExercisePage name={name} setName={setName} />}
              />
              <Route
                path=":add"
                element={<AddExercisePage name={name} setName={setName} />}
              />
            </Route>
            <Route path="recipes">
              <Route
                index
                element={<RecipeHome name={name} setName={setName} />}
              />
            </Route>
            <Route
              path="/recipe/:id"
              element={<RecipePage name={name} setName={setName} />}
            />
            <Route
              path="profile"
              element={
                <Profile
                  name={name}
                  setName={setName}
                  user={user}
                  userGoal={userGoal}
                  userPlan={userPlan}
                />
              }
            />
            <Route
              path="searched/:search"
              element={<SearchPage name={name} setName={setName} />}
            />
          </Route>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
