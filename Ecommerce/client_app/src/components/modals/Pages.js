import React, { useContext } from "react"
import {Pagination} from "react-bootstrap";
import {observer} from "mobx-react-lite";


const Pages = observer(() => {
    return (
        <Pagination className="mt-3">
            {pages.map(page =>
                <Pagination.Item
                    key={page}
                    active={device.page === page}
                    onClick={() => device.setPage(page)}
                >
                    {page}
                </Pagination.Item>
            )}
        </Pagination>
    );
});

export default Pages; 