import React from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Homepage from './Pages/Homepage';
import ReviewPage from './Pages/ReviewPage';
import AddReviewPage from './Pages/AddReviewPage';
import UserInfoPage from './Pages/UserInfoPage';
function App() {
  return (
<BrowserRouter basename='/gamepeekr'>
      <Routes>
        
        <Route path="/" element={<Homepage />}></Route>

        <Route path="/review/:id" element={<ReviewPage />}></Route>

        <Route path="/AddReviewPage" element={<AddReviewPage/>}></Route>

        <Route path="/User" element={<UserInfoPage/>}></Route>

      </Routes>
    </BrowserRouter>

  );
}

export default App;
