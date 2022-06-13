import Home from "./pages/home/Home";
import LoginPage from "./pages/login/LoginPage";
import {useState,useEffect} from "react";
import List from "./pages/list/List";
import Single from "./pages/single/Single";
import New from "./pages/new/New";
import Dashboard from "./pages/dashboard/Dashboard";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { productInputs, userInputs } from "./formSource";
import "./style/dark.scss";
import { useContext } from "react";
import { DarkModeContext } from "./context/darkModeContext";
import FoodPage from "./pages/foodpage/FoodPage";
import AddFoodPage from "./pages/foodpage/addfoodpage/AddFoodPage";
import RegisterPage from "./pages/register/RegisterPage";

function App() {
  const { darkMode } = useContext(DarkModeContext);
  const [name,setName] = useState('');

  useEffect(() => {
    (
      async () => {
        const response = await fetch('https://localhost:44325/api/user', {
          headers: {'Content-Type': 'application/json'},
          credentials: 'include',
        });

        const content = await response.json();
        setName(content.name);
      }
    )();
  });

  return (
    <div className={darkMode ? "app dark" : "app"}>
      <BrowserRouter>
        <Routes>
          <Route path="/">
            <Route index element={<Home name={name} setName={setName}/>} />
            <Route path="login" element={<LoginPage name={name}/>} />
            <Route path="register" element={<RegisterPage name={name}/>} />
            <Route path="users">
              <Route index element={<List name={name}/>} />
              <Route path=":userId" element={<Single name={name}/>} />
              <Route
                path="new"
                element={<New inputs={userInputs} name={name} title="Add New User" />}
              />
            </Route>
            <Route path="products">
              <Route index element={<List name={name}/>} />
              <Route path=":productId" element={<Single name={name}/>} />
              <Route
                path="new"
                element={<New inputs={productInputs} name={name} title="Add New Product" />}
              />
            </Route>
            <Route path="home">
              <Route index element={<Dashboard name={name}/>} />
            </Route>
            <Route path="food">
              <Route index element={<FoodPage name={name}/>} />
              <Route path=":add" element={<AddFoodPage name={name}/>} />
            </Route>
          </Route>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
