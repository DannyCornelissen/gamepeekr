import React from 'react';
import Menu from '../Components/ReusableComponents/Menu';
import Head from '../Components/ReusableComponents/Head';
import { auth } from '../Utils/firebase.utils';
import { Navigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

const UserInfoPage = () => {
  const user = auth.currentUser;
  if (user == null) {
    return <Navigate to={'/'} />;
  } else {
    return (
      <html>
        <Head title={user.displayName} description='This is the userPage'></Head>
        <body>
          <div>
            <Menu />
            <header className="mt-3">
              <h1>{user.displayName}</h1>
            </header>
            <div className="mt-3">
            <img src={user.photoURL} height="200px" width="200px" className="img-fluid" alt="User" />
              <div className="card">
                <div className="card-body">
                  <h5 className="card-title">User Information</h5>
                  <p className="card-text">
                    <strong>Name:</strong> {user.displayName} <br />
                    <strong>Email:</strong> {user.email} <br />
                  </p>
                </div>
              </div>
            </div>
          </div>
        </body>
      </html>
    );
  }
};

export default UserInfoPage;
