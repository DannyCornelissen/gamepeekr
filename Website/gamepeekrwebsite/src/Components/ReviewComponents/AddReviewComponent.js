import React, { useState } from "react";
import APILink from '../ReusableComponents/Config';
import { Navigate } from 'react-router-dom';
import { Alert } from 'react-bootstrap';
import {auth} from '../../Utils/firebase.utils'
import {PostData} from '../DataAccessComponents/GamePeekrAPICalls';
import { GetAll } from "../DataAccessComponents/GamePeekrAPICalls";

function AddReviewComponent() {
  const [postData, setPostData] = useState({
    title: "",
    reviewText: "",
    rating: 0,
    game: "",
    userId:auth.currentUser.uid
  });
  const [navigation, setNavigation] = useState(false);
  const [errorAlert, setErrorAlert] = useState(null);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setPostData({
      ...postData,
      [name]: value
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try 
    {
      await PostData(postData, `${APILink}/api/Review`);
      setNavigation(true);
    } 
    catch (error)
    {
      console.log(error.response.status)
      if (error.response.status === 400)
       {
        const reviewCheck = error.response.data;
        const response = await GetAll(`${APILink}/api/ReviewStatusEnum/${reviewCheck}`);
        switch (response) {
          case "BadTitle":
            setErrorAlert("Title is too long");
            break;
          case "BadReviewText":
            setErrorAlert("The review text is too long");
            break;
          case "BadTitleAndReviewText":
            setErrorAlert("Title and review text are too long");
            break;
          default:
            setErrorAlert("An unknown error occurred");
        }
      }
      else if(error.response.status === 401)
      {
        setErrorAlert("You are not authorised to perform this action")
      }
      else
      {
        setErrorAlert("We are having some problems try again later")
      }
    }
  };

  if (navigation || auth.currentUser == null) {
    return <Navigate to={"/"} />;
  } 
  else {
    return (
      <div className="container mt-4">
        <h1 className="mb-4">Post a Review</h1>

        {errorAlert && (
          <Alert variant="danger" onClose={() => setErrorAlert(null)} dismissible>
            {errorAlert}
          </Alert>
        )}

        <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <label htmlFor="title" className="form-label">
              Title
            </label>
            <input
              type="text"
              id="title"
              name="title"
              value={postData.title}
              onChange={handleChange}
              className="form-control"
            />
          </div>
          <div className="mb-3">
            <label htmlFor="reviewText" className="form-label">
              Review Text
            </label>
            <textarea
              id="reviewText"
              name="reviewText"
              value={postData.reviewText}
              onChange={handleChange}
              className="form-control"
            />
          </div>
          <div className="mb-3">
            <label htmlFor="rating" className="form-label">
              Rating
            </label>
            <input
              type="number"
              id="rating"
              name="rating"
              value={postData.rating}
              onChange={handleChange}
              className="form-control"
              min="0"
              max="10"
            />
          </div>
          <div className="mb-3">
            <label htmlFor="game" className="form-label">
              Game
            </label>
            <input
              type="text"
              id="game"
              name="game"
              value={postData.game}
              onChange={handleChange}
              className="form-control"
            />
          </div>
          <button type="submit" className="btn btn-primary">
            Submit
          </button>
        </form>
      </div>
    );
  }
}

export default AddReviewComponent;
