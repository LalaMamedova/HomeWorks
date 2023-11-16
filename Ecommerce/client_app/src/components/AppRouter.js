import {Route,Routes,Navigate} from "react-router-dom";
import {authRoute,publicRoute } from '../utilits/route';
import { useContext,useState } from "react";
import { Context } from "..";
import NaviBar from "./modals/NavBar";
import '../css/index.css'


const AppRouter = () => { 
    const {user} = useContext(Context);
    const [mode, setMode] = useState(false);

    return (
        <div className="App" id={mode ? 'light' : 'dark'}>
          <NaviBar  mode={mode} setMode={setMode}/>

          <main >
            <Routes>

              {user.isAuto &&  authRoute.map(({ path, element }) => (
                  <Route key={path} path={path} element={element} />
                ))}

              {!user.isAuto && publicRoute.map(({ path, element }) => (
                  <Route key={path} path={path} element={element} />
                ))}

              <Route path="/*" element={<Navigate to="/" />} />
            </Routes>
          </main>
        </div>
      );
}
export default AppRouter;