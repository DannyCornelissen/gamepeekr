import React from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Homepage from './Pages/Homepage';
import ReviewPage from './Pages/ReviewPage';
import AddReviewPage from './Pages/AddReviewPage';

function App() {
  return (
<BrowserRouter>
      <Routes>
        
        <Route path="/" element={<Homepage />}></Route>

        <Route path="/review/:id" element={<ReviewPage />}></Route>

        <Route path="/AddReviewPage" element={<AddReviewPage />}></Route>

      </Routes>
    </BrowserRouter>

  );
}

export default App;
