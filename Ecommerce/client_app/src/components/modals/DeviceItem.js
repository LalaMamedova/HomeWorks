import React from 'react';
import {Card, Col,Image} from "react-bootstrap";
import {useNavigate} from "react-router-dom"
import '../../css/deviceitem.css'
import { DEVICE_ROUTE } from '../../utilits/const';

const DeviceItem = ({device}) => {

    const navigate = useNavigate();

    return (
        <Col id="device-cards" md={4} className={"mt-5"} >
            <Card id="device-card" onClick={() => navigate(DEVICE_ROUTE + '/' + device.id)} >

                    <div>{device.name}</div>
                    <div id='img-div' className="d-flex">
                        <Image src={device.img}></Image>
                    </div>

                    <p>{device.id}</p>
                    <div>{device.GPU}</div>
            </Card>
        </Col>
    );
};

export default DeviceItem;