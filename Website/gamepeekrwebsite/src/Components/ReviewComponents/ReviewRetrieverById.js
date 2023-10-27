import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import APILink from '../ReusableComponents/Config';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faThumbsUp, faStar } from '@fortawesome/free-solid-svg-icons';
import { Alert } from 'react-bootstrap';

function ReviewRetrieverById() {
  const { id } = useParams();
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(false)
  const [errorAlert, setErrorAlert] = useState(null);

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await fetch(`${APILink}/api/Review/${id}`);
        if (!response.ok) {
          setError(true);
          throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const incomingData = await response.json();
        setData(incomingData);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching data:', error);
        setLoading(false);
        setError(true);
        setErrorAlert("We had some problems retrieving this review, try again later");
      }
    }

    fetchData();
  }, [id]);

  if (loading) {
    return (
      <div className="container mt-5">
        <div className="text-center">Loading...</div>
      </div>
    );
  }

  if(error)
  {
    return(
      <div>
              {errorAlert && (
        <Alert variant="danger">
          {errorAlert}
        </Alert>
      )}
      </div>

    )
  }

  return (
    <div className="container mt-5">
      <h1 className="display-4">{data.title}</h1>
      <div className="row align-items-center text-decoration-underline text-secondary">
        <div className="col" >
          <p className="lead ">
            <FontAwesomeIcon icon={faThumbsUp} className="mr-2" />
            {' '} 
            Likes: {data.likes}
          </p>
        </div>
        <div className="col">
          <p className="lead">
            <FontAwesomeIcon icon={faStar} className="mr-2" />
            {' '} 
            Rating: {data.rating}
          </p>
        </div>
      </div>
      <p className="lead">{data.reviewText}</p>
    </div>
  );
}

export default ReviewRetrieverById;
