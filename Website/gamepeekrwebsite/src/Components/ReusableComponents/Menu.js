import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Menu = () => {
  const navigate = useNavigate();
  const [menuItems] = useState([
    { id: 1, title: 'Home' },
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
      case 'Home':
        navigate('/');
        break;
    } 
  }

  return (
    <ul style={menuStyle}>
      {menuItems.map((item) => (
        <li
          key={item.id}
          style={itemStyle}
          onClick={() => handleItemClick(item.title)} 
        >
          {item.title}
        </li>
      ))}
    </ul>
  );
};

export default Menu;
