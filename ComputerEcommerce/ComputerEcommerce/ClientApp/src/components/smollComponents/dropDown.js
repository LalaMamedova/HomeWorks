import * as React from 'react';

export default function DropDown() {
    const [open, setOpen] = React.useState(false);

    const handleOpen = () => {
        setOpen(!open);
    };

    return (
        <div>
            <button onClick={handleOpen}>Dropdown</button>
            {open ? <div>Is Open</div> : <div>Is Closed</div>}
        </div>
    );
}

