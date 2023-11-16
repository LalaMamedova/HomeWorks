import React, { useContext } from "react"
import {observer} from 'mobx-react-lite'
import { Context } from "../..";
import {Col,Row} from 'react-bootstrap';
import DeviceItem from "./DeviceItem";
import '../../css/deviceitem.css'


const DeviceList = observer(()=>{
    const {computer} = useContext(Context);

    return (
           <Row className="d-flex">{
                    computer._computer.map(device=>(
                        <DeviceItem device={device}></DeviceItem>
                ))
            }
            </Row>
    )
});
export default DeviceList;