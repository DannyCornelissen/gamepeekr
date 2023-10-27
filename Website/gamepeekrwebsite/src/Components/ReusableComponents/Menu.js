import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCirclePlus } from '@fortawesome/free-solid-svg-icons';

const Menu = () => {
  const navigate = useNavigate();
  const [menuItems] = useState([
    { id: 1, title: 'Home' },
    {id: 2, title: "Add new review ", icon: faCirclePlus}
  ]);

  const menuStyle = {
    listStyle: 'none',
    margin: '0',
    padding: '0',
    backgroundColor: '#333',
  };

  const itemStyle = {
    display: 'inline-block',
    margin: '10px',
    padding: '5px 10px',
    background: 'none',
    color: 'white',
    borderRadius: '5px',
    cursor: 'pointer',
  };

  const handleItemClick = (title) => {
    switch(title)
    {
      case 1:
        navigate('/');
        break;
      case 2:
        navigate('/AddReviewPage')
        break;
    } 
  }

  return (
    <ul style={menuStyle}>
      {menuItems.map((item) => (
        <li
          key={item.id}
          style={itemStyle}
          onClick={() => handleItemClick(item.id)} 
        >
          {item.title}
          {item.icon && 
          (
           <FontAwesomeIcon icon={item.icon} style={{ marginRight: '2px' }} />
          )}
        </li>
      ))}
    </ul>
  );
};

export default Menu;
