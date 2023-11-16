import { Navigate } from "react-router-dom";
import Signin from "../pages/Signin";
import Signup from "../pages/Signup";
import Shop from "../pages/Shop";
import { DEVICE_ROUTE, SHOP_ROUTE, SIGNIN_ROUTE, SIGNUP_ROUTE } from "./const";
import DevicePage from "../pages/DevicePage";

export const authRoute = [
    {
        path: '/',
        element: <Navigate to={SHOP_ROUTE} replace />,
    },
];

export const publicRoute = [
    {
        path: '/',
        element: <Navigate to={SHOP_ROUTE} replace />,
    },
    {
        path: SIGNIN_ROUTE,
        element: <Signin/>
    },
    {
        path: SIGNUP_ROUTE,
        element: <Signup/>
    },
    {
        path: SHOP_ROUTE,
        element: <Shop/>
    },
    {
        path: DEVICE_ROUTE + '/:id',
        element: <DevicePage/>
    },
];