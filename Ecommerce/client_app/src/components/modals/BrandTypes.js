import React, { useContext } from "react"
import {observer} from "mobx-react-lite";
import {Col} from "react-bootstrap";


const BrandTypes = observer(() => {
    return (
       <Col>
            <button>NVIDIA</button>
            <button>NVIDIA</button>
            <button>NVIDIA</button>

       </Col>
    );
});

export default BrandTypes; 