import React, { useEffect,useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCirclePlus } from '@fortawesome/free-solid-svg-icons';
import {auth} from '../../Utils/firebase.utils';
import logGoogleUser from '../AuthenticationComponents/LoginComponent';
import SignOutUser from '../AuthenticationComponents/LogoutComponent';

const Menu = () => {
  const [menuItems, setMenuItems] = useState([]);
  const navigate = useNavigate();
  
  useEffect(() => {
    if (auth.currentUser != null) {
      setMenuItems([
        { id: 1, title: 'Home' },
        { id: 2, title: 'Add new review', icon: faCirclePlus },
        { id: 4, title: 'Logout' },
        { id: 5, title: <div>{auth.currentUser.displayName} <img id='UserImage' alt='userimg' style={UserImage} height='30px' width='30px' src={auth.currentUser.photoURL} /></div>}
      ]);
    } else {
      setMenuItems([
        { id: 1, title: 'Home' },
        { id: 3, title: 'Login' },
      ]);
    }
  }, [auth.currentUser]);

  const menuStyle = {
    listStyle: 'none',
    margin: '0',
    padding: '0',
    backgroundColor: '#333',
    display: 'flex',
    justifyContent: 'space-between',
  };

  const UserImage ={
    borderRadius: '100px',
  };

  const containerStyle = {
    display: 'flex',
    alignItems: 'center',
  };

  const itemStyle = {
    margin: '10px',
    padding: '5px 10px',
    background: 'none',
    color: 'white',
    borderRadius: '5px',
    cursor: 'pointer',
  };

  const handleItemClick = async(id) => {
    switch (id) {
      case 1:
        navigate('/');
        break;
      case 2:
        navigate('/AddReviewPage');
        break;
      case 3:
        await logGoogleUser();
        navigate('/')
        break;
      case 4:
        await SignOutUser();
        navigate('/')
        break;
      case 5:
        navigate('/user')
    }
  };

  return (
    <ul style={menuStyle}>
      <div style={containerStyle}>
        {menuItems.map(
          (item) =>
            item && ( 
              <li
                key={item.id}
                style={{
                  ...itemStyle,
                  ...(item.icon && { display: 'flex', alignItems: 'center' }),
                }}
                onClick={() => handleItemClick(item.id)}
              >
                {item.title}
                {item.icon && (
                  <FontAwesomeIcon icon={item.icon} style={{ marginLeft: '2px' }} />
                )}
              </li>
            )
        )}
      </div>
    </ul>
  );
};

export default Menu;
