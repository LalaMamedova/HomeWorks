import React,{useContext} from 'react'
import CategoryBar from '../components/modals/CategoryBar'
import DeviceList from '../components/modals/DeviceList'
import BrandTypes from '../components/modals/BrandTypes'
import { Context } from "..";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import '../css/shop.css'

const Shop = () => {
    const {computer} = useContext(Context);
    
    return (
        <Container className='shop-container-div'>
        <Row>
            <Col className="mt-4 col-2">
                <CategoryBar/>
            </Col>
            <Col className="mt-4">
                <BrandTypes/>
                <DeviceList />
            </Col>
        </Row>
    </Container>
    
     
    )
}
export default Shop;