import React, { useEffect, useState } from 'react';
import { Navigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import APILink from '../ReusableComponents/Config';
import { Alert } from 'react-bootstrap';

function ReviewRetriever() {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [redirection, setRedirection] = useState(false);
  const [redirectionId, setRedirectionId] = useState(0);
  const [error, setError] = useState(false)
  const [errorAlert, setErrorAlert] = useState(false)
  
  useEffect(() => {
    async function fetchData() {
      try {
        const response = await fetch(`${APILink}/api/Review`);
        if (!response.ok) {
          setError(true)
          throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const incomingData = await response.json();
        setData(incomingData);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching data:', error);
        setLoading(false);
        setError(true)
        setErrorAlert("We hade some issues retrieving the reviews. Try again later")
      }
    }

    fetchData();
  }, []);

  function handleRowClick(id) {
    setRedirection(true);
    setRedirectionId(id);
  }

  if (loading) {
    return <div className="container">Loading...</div>;
  }

  if(error)
  {
    return (
      <div>
        {errorAlert && (
          <Alert variant="danger">
            {errorAlert}
          </Alert>
       )}
      </div>
    )
  }

  if (redirection) {
    return <Navigate to={`/review/${redirectionId}`} />;
  }

  return (
    <div className="container">
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Title</th>
            <th>Game</th>
            <th>Likes</th>
            <th>Rating</th>
          </tr>
        </thead>
        <tbody>
          {data.map((item) => (
            <tr
              key={item.id}
              onClick={() => handleRowClick(item.id)}
              style={{ cursor: 'pointer' }}
            >
              <td>{item.title}</td>
              <td>{item.game}</td>
              <td>{item.likes}</td>
              <td>{item.rating}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ReviewRetriever;
