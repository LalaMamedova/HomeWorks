import React, { useContext } from "react"
import {observer} from 'mobx-react-lite'
import { Context } from "../..";
import '../../css/btns.css'
import '../../css/categorybar.css'

const CategoryBar = observer(()=>{
    const {computer} = useContext(Context);

    return(
        <div id='category-bar-div'>{
                computer._type.map(type=>(
                    <li>
                        <button className="side-bar-btn">{type.name}</button>
                    </li>
                ))
            }

        </div>
    )
});

export default CategoryBar;


